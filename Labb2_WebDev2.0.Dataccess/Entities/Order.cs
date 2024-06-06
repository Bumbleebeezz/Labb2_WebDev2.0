namespace Labb2_WebDev2._0.Dataccess.Entities;

public class Order
{
    public int OrderID { get; set; }
    public int CustomerID { get; set; }
    public DateTime DateOfOrder { get; set; }
    public bool OrderShipped { get; set; }
    public List<int> Products { get; set; } = new();
}