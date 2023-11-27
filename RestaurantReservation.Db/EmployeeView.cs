namespace RestaurantReservation.Db;

public class EmployeeView
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string RestaurantName { get; set; }
    public string Position { get; set; }
    public override string ToString()
    {
        return $"""
                Employee name: {FirstName} {LastName}
                Position: {Position}
                Restaurant: {RestaurantName}
                """;
    }
}