namespace RestaurantReservation.Db;

public class MenuItem
{
    public int MenuItemId { get; set; }
    public Restaurant Restaurant { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public ICollection<OrderItem> OrderItems { get; set; }
}