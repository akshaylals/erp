using ERP.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using Debug = System.Diagnostics.Debug;

namespace ERP.Services
{

    public class CartService
    {
        HttpClient httpClient;
        List<Product> cartProductList = new();

        public CartService()
        {
            this.httpClient = new HttpClient();
        }

        public async Task<List<Product>> GetCartProducts()
        {
            if (cartProductList?.Count > 0)
                return cartProductList;

            var response = await httpClient.GetAsync(Constants.cartEndpoint);

            if (response.IsSuccessStatusCode)
            {
                cartProductList = await response.Content.ReadFromJsonAsync<List<Product>>();
            }

            return cartProductList;
        }

        public async Task PostCartProduct(string id)
        {
            var response = await httpClient.GetAsync($"{Constants.productsEndpoint}/{id}");

            if (response.IsSuccessStatusCode)
            {
                Product product = await response.Content.ReadFromJsonAsync<Product>();
                var productj = JsonConvert.SerializeObject(product);
                var buffer = System.Text.Encoding.UTF8.GetBytes(productj);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var result = await httpClient.PostAsync(Constants.cartEndpoint, byteContent);
            }
        }
    }
}
