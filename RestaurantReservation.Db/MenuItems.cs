namespace RestaurantReservation.Db;

public class MenuItems
{
    public int ItemId { get; set; }
    public int RestaurantId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public ICollection<OrderItems> OrderItems { get; set; }
}