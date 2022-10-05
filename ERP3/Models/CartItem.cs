namespace ERP3.Models;

public class CartItem
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("product")]
    public Product Product { get; set; }

    [JsonPropertyName("quantity")]
    public int Quantity { get; set; }
}

public class CartItemAPI
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("product")]
    public int Product { get; set; }

    [JsonPropertyName("quantity")]
    public int Quantity { get; set; }
}
