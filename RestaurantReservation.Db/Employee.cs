namespace RestaurantReservation.Db;

public class Employee
{
    public int EmployeeId { get; set; }
    public int RestaurantId { get; set; }
    public Restaurant Restaurant { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Position { get; set; }
    public ICollection<Order> Orders { get; set; }
    public override string ToString()
    {
        return $"""
                Employee name: {FirstName} {LastName}
                Position: {Position}
                Employee ID: {EmployeeId}
                Restaurant ID: {RestaurantId}
                """;
    }
}