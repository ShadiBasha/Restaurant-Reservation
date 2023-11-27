namespace RestaurantReservation.Db;

public class OrderItem
{
    public int OrderItemId { get; set; }
    public int OrderId { get; set; }
    public Order Order { get; set; }
    public int MenuItemId { get; set; }
    public MenuItem MenuItem { get; set; }
    public int Quantity { get; set; }
    public override string ToString()
    {
        return $@"
                    Order Item ID: {OrderItemId}
                    Order ID: {OrderId}
                    MenuItem ID: {MenuItemId}
                    Quantity: {Quantity}
                    ";
    }
}