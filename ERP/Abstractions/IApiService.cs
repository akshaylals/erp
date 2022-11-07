using ERP.MVVM.Models;

namespace ERP.Abstractions
{
    public interface IApiService
    {
        Task<Product> GetProduct(int productID);
        Task<List<Product>> GetProducts();
        Task<List<Product>> GetProducts(string search);
        Task<List<Product>> GetProducts(string search, string filter);

        Task<List<string>> GetCategories();

        Task<CartItemAPI> GetCartItem(int cartItemID);
        Task<List<CartItemAPI>> GetCartItems();
        Task PostCartItem(int productID);
        Task DeleteCartItem(int cartItemID);
        Task<int> GetCartCount();
    }
}
