namespace RestaurantReservation.Db;

public class Order
{
    public int OrderId { get; set; }
    public int ReservationId { get; set; }
    public Reservation Reservation { get; set; }
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }
    public DateTime OrderDate { get; set; }
    public int TotalAmount { get; set; }
    public ICollection<OrderItem> OrderItems { get; set; }
    public override string ToString()
    {
        return $"""
                Order ID: {OrderId}
                Reservation ID: {ReservationId}
                Employee ID: {EmployeeId}
                Order Date: {OrderDate}
                Total Amount: {TotalAmount} units
                """;
    }
}