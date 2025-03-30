namespace StockApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductId { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public int ProviderId { get; set; }
    }
}
