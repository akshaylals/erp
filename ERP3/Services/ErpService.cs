using ERP3.Models;

namespace ERP3.Services
{
    public class ErpService : RestServiceBase, IApiService
    {
        public ErpService(IConnectivity connectivity) : base(connectivity)
        {
            SetBaseURL(Constants.apiEndpoint);
        }

        public async Task DeleteCartItem(int cartItemID)
        {
            var cartUri = "cart";

            var cartItem = await GetAsync<CartItemAPI>($"{cartUri}/{cartItemID}");

            if (cartItem != null)
            {
                if (cartItem.Quantity == 1)
                {
                    await DeleteAsync($"{cartUri}/{cartItemID}");
                }
                else
                {
                    cartItem.Quantity--;

                    await PutAsync($"{cartUri}/{cartItemID}", cartItem);
                }
            }
        }

        public async Task<int> GetCartCount()
        {
            var resourceUri = "cart";

            var result = await GetAsync<List<CartItemAPI>>(resourceUri);

            return result.Count;
        }

        public async Task<CartItemAPI> GetCartItem(string cartItemID)
        {
            var resourceUri = $"cart/{cartItemID}";

            var result = await GetAsync<CartItemAPI>(resourceUri);

            return result;
        }

        public async Task<List<CartItemAPI>> GetCartItems()
        {
            var resourceUri = "cart";

            var result = await GetAsync<List<CartItemAPI>>(resourceUri);

            if (result.Count == 0)
            {
                throw new EmptyCartException();
            }

            return result;
        }

        public async Task<Product> GetProduct(string productID)
        {
            var resourceUri = $"products/{productID}";

            var result = await GetAsync<Product>(resourceUri);

            return result;
        }

        public async Task<List<Product>> GetProducts()
        {
            var resourceUri = "products";

            var result = await GetAsync<List<Product>>(resourceUri);

            return result;
        }

        public async Task<List<Product>> GetProducts(string search)
        {
            if (search == "")
            {
                throw new EmptySearchException();
            }

            var resourceUri = $"products?title_like={search}";

            var result = await GetAsync<List<Product>>(resourceUri);

            if (result.Count == 0)
            {
                throw new EmptySearchException();
            }

            return result;
        }

        public async Task<List<Product>> GetProducts(string search, string filter)
        {
            if (search == "")
            {
                throw new EmptySearchException();
            }

            var resourceUri = $"products?title_like={search}&category_like={filter}";

            var result = await GetAsync<List<Product>>(resourceUri);

            if (result.Count == 0)
            {
                throw new EmptySearchException();
            }

            return result;
        }

        public async Task PostCartItem(int productId)
        {
            var cartUri = "cart";

            var cartItems = await GetAsync<List<CartItemAPI>>($"{cartUri}?product={productId}");

            if (cartItems.Count > 0)
            {
                cartItems[0].Quantity++;

                await PutAsync($"{cartUri}/{cartItems[0].Id}", cartItems[0]);
            }
            else
            {
                CartItemAPI item = new();
                item.Product = productId;
                item.Quantity = 1;

                await PostAsync(cartUri, item);
            }
        }
    }
}
