namespace ERP.Services;

public class ApiService : RestServiceBase, IApiService
{
    public ApiService(IConnectivity connectivity) : base(connectivity)
    {
        SetBaseURL(Constants.apiEndpoint);
    }

    public async Task DeleteCartItem(int cartItemID)
    {
        var cartUri = "/cart";

        await DeleteAsync($"{cartUri}/{cartItemID}");
    }

    public async Task<int> GetCartCount()
    {
        var resourceUri = "/cart";

        var result = await GetAsync<List<CartItemAPI>>(resourceUri);

        return result.Count;
    }

    public async Task<CartItemAPI> GetCartItem(int cartItemID)
    {
        var resourceUri = $"/cart/{cartItemID}";

        var result = await GetAsync<CartItemAPI>(resourceUri);

        return result;
    }

    public async Task<List<CartItemAPI>> GetCartItems()
    {
        var resourceUri = "/cart";

        var result = await GetAsync<List<CartItemAPI>>(resourceUri);

        if (result.Count == 0)
        {
            throw new EmptyCartException();
        }

        return result;
    }

    public async Task<List<string>> GetCategories()
    {
        var resourceUri = "/products";

        var result = await GetAsync<List<Product>>(resourceUri);

        var categories = new List<string>();

        foreach (var item in result)
        {
            if (!categories.Contains(item.category))
            {
                categories.Add(item.category);
            }
        }

        return categories;
    }

    public async Task<Product> GetProduct(int productID)
    {
        var resourceUri = $"/products/{productID}";

        var result = await GetAsync<Product>(resourceUri);

        return result;
    }

    public async Task<List<Product>> GetProducts()
    {
        var resourceUri = "/products";

        var result = await GetAsync<List<Product>>(resourceUri);

        return result;
    }

    public async Task<List<Product>> GetProducts(string search)
    {
        if (search == "")
        {
            throw new EmptySearchException();
        }

        var resourceUri = $"/products/search/{search}";

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

        var resourceUri = $"/products/search/{search}/{filter}";

        var result = await GetAsync<List<Product>>(resourceUri);

        if (result.Count == 0)
        {
            throw new EmptySearchException();
        }

        return result;
    }

    public async Task PostCartItem(int productId)
    {
        var cartUri = "/cart";

        await PostAsync(cartUri, new CartItemAPI
        {
            productId = productId,
            quantity = 1,
        });
    }
}
