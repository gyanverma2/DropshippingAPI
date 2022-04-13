FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["DropShippingAPI.API/DropShippingAPI.API.csproj", "DropShippingAPI.API/"]
RUN dotnet restore "DropShippingAPI.API/DropShippingAPI.API.csproj"
COPY . .
WORKDIR "/src/DropShippingAPI.API"
RUN dotnet build "DropShippingAPI.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "DropShippingAPI.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DropShippingAPI.API.dll"]
