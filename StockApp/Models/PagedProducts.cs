namespace StockApp.Models;

public class PagedProducts<T>
{
    public List<T> Items { get; set; } = new();
    public int TotalItems { get; set; }
    public int PageSize { get; set; }
    public int CurrentPage { get; set; }
    public int TotalPages => (int)Math.Ceiling((double)TotalItems / PageSize);

}