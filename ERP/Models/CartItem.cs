using Newtonsoft.Json;

namespace ERP.Models
{
    internal class CartItem
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("product")]
        public Product Product { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }
    }
}
