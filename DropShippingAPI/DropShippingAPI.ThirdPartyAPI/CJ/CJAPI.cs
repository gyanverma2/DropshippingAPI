using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DropShippingAPI.ThirdPartyAPI.CJ
{
    public class CJAPI : ICJAPI
    {
        public readonly HttpClient HttpClient;
        public CJAPI(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public async Task<Category> GetCategoryAsync(Pagination p)
        {
            HttpContent data = new StringContent(JsonConvert.SerializeObject(p), Encoding.UTF8, "application/json");
            var response = await HttpClient.PostAsync("commodity/getCategory", data);
            if (!response.IsSuccessStatusCode) throw new Exception("Failed to get category from API");

            var responseContent = await response.Content.ReadAsStringAsync();
            if (responseContent == null) return null;
            return JsonConvert.DeserializeObject<Category>(responseContent);
        }

        public async Task<Product> GetProductByCategoryAsync(ProductRequest p)
        {
            HttpContent data = new StringContent(JsonConvert.SerializeObject(p), Encoding.UTF8, "application/json");
            var response = await HttpClient.PostAsync("commodity/getCommodity", data);
            if (!response.IsSuccessStatusCode) throw new Exception("Failed to get product by category from API");

            var responseContent = await response.Content.ReadAsStringAsync();
            if (responseContent == null) return null;
            return JsonConvert.DeserializeObject<Product>(responseContent);
        }
        public async Task<ProductDetails> GetProductDetailsAsync(string pId)
        {
            var data = new StringContent("{\"pid\" : "+ pId + "}", Encoding.UTF8, "application/json");
            var response = await HttpClient.PostAsync("commodity/detail", data);
            if (!response.IsSuccessStatusCode) throw new Exception("Failed to get product details from API");

            var responseContent = await response.Content.ReadAsStringAsync();
            if (responseContent == null) return null;
            return JsonConvert.DeserializeObject<ProductDetails>(responseContent);
        }
    }
}
