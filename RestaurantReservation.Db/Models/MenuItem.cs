namespace RestaurantReservation.Db.Models;

public class MenuItem
{
    public int MenuItemId { get; set; }
    public int RestaurantId { get; set; }
    public Restaurant Restaurant { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public ICollection<OrderItem> OrderItems { get; set; }
    public override string ToString()
    {
        return $"""
                Menu Item: {Name}
                Description: {Description}
                Price: {Price} units
                Restaurant ID: {RestaurantId}
                """;
    }
}