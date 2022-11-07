namespace ERP.MVVM.Models;

public class CartItemAPI
{
    public int quantity { get; set; }
    public int id { get; set; }
    public int productId { get; set; }
}

public class CartItem
{
    public int quantity { get; set; }
    public int id { get; set; }
    public Product product { get; set; }
}