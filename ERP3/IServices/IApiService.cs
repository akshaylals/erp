namespace ERP3.IServices;

public interface IApiService
{
    Task<Product> GetProduct(string productID);
    Task<CartItemAPI> GetCartItem(string cartItemID);
    Task<List<Product>> GetProducts();
    Task<List<CartItemAPI>> GetCartItems();
    Task PostCartItem(int productID);
    Task DeleteCartItem(int cartItemID);
    Task<int> GetCartCount();
}
