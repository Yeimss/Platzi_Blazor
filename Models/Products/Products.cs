namespace Platzi_Blazor;

public class Products
{
    public int Id { get; set; }
    public string Title { get; set; }
    public decimal? price { get; set; }
    public string Description { get; set; }
    public int CategoryId { get; set; }
    public string[] Images { get; set; }
    public string Image { get; set; }
        
}
