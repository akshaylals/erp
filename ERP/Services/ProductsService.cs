using ERP.Models;
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
    }
}
