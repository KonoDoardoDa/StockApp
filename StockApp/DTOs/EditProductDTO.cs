namespace StockApp.DTOs;

public class EditProductDTO
{
    public string ProductId { get; set; }
    public string? Description { get; set; }
    public int? Quantity { get; set; }

}