namespace RestaurantReservation.Db;

public class Employees
{
    public int EmployeeId { get; set; }
    public int RestaurantId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Position { get; set; }
    public ICollection<Orders> Orders { get; set; }
}