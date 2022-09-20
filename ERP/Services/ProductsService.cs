using ERP.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace ERP.Services
{

    public class ProductsService
    {
        HttpClient httpClient;
        List<Product> productList = new();

        public ProductsService()
        {
            this.httpClient = new HttpClient();
        }

        public async Task<List<Product>> GetProducts()
        {
            if (productList?.Count > 0)
                return productList;
            
            var response = await httpClient.GetAsync(Constants.productsEndpoint);

            if (response.IsSuccessStatusCode)
            {
                productList = await response.Content.ReadFromJsonAsync<List<Product>>();
            }

            return productList;
        }

        public async Task<Product> GetProduct(string id)
        {
            var response = await httpClient.GetAsync($"{Constants.productsEndpoint}/{id}");

            if (response.IsSuccessStatusCode)
            {
                Product product = await response.Content.ReadFromJsonAsync<Product>();
                return product;
            }
            else
            {
                return null;
            }
        }
    }
}
