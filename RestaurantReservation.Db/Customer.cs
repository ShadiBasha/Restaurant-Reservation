
namespace RestaurantReservation.Db;

public class Customer
{
    public int CustomerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public ICollection<Reservation> Reservations { get; set; }
    public override string ToString()
    {
        return $"""
                Customer name: {FirstName} {LastName}
                Email: {Email}
                Phone Number: {PhoneNumber}
                """;
    }
}