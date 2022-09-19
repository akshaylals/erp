using ERP.Models;
using System.Net.Http.Json;

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
    }
}
