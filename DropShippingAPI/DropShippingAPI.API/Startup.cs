using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DropShippingAPI.DataAccess.Impl;
using DropShippingAPI.DataAccess.Interface;
using DropShippingAPI.Manager.Impl;
using DropShippingAPI.Manager.Interface;
using DropShippingAPI.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using DropShippingAPI.ThirdPartyAPI;
using DropShippingAPI.ThirdPartyAPI.CJ;
using System;

namespace DropShippingAPI.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
           {
               options.AddPolicy("AllowAllHeaders",
                  builder =>
                  {
                      builder.AllowAnyOrigin()
                 .AllowAnyHeader()
                 .AllowAnyMethod();
                  });
           });
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddSingleton<IConfiguration>(Configuration);
            string connectionString = Configuration.GetConnectionString("MySQLDatabase");
            services.AddMvc(option => option.EnableEndpointRouting = false).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddTransient(_ => new MySqlDatabase(connectionString));
            services.AddSwaggerDocument(c => c.Title = "DropShippingAPI");

            services.AddTransient<ICurrentUserService, CurrentUserService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddHttpClient<ICJAPI, CJAPI>(c =>
            {
                c.BaseAddress = new Uri(Configuration.GetValue<string>("APIUrl:CJAPI"));
                c.DefaultRequestHeaders.TryAddWithoutValidation("CJ-Access-Token", Configuration.GetValue<string>("APIUrl:CJAPI_Key"));
            });
            #region Dependency
            services.AddTransient<IShoppingManager, ShoppingManager>();
            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("AllowAllHeaders");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }


            app.UseAuthentication();

            app.UseOpenApi();
            app.UseSwaggerUi3(c => c.DocumentTitle = "DropShippingAPI");
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}

