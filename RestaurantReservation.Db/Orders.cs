namespace RestaurantReservation.Db;

public class Orders
{
    public int OrderId { get; set; }
    public int ReservationId { get; set; }
    public int EmployeeId { get; set; }
    public DateTime OrderDate { get; set; }
    public int TotalAmount { get; set; }
    public ICollection<OrderItems> OrderItems { get; set; }
}