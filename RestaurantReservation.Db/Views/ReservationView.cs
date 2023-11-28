namespace RestaurantReservation.Db.Views;

public class ReservationView
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime ReservationDate { get; set; }
    public int PartySize { get; set; }
    public string Email { get; set; }
    public string CustomerNumber { get; set; }
    public string RestaurantName { get; set; }
    public string Address { get; set; }
    public string RestaurantNumber { get; set; }
    public override string ToString()
    {
        return $@"
                    Customer Name: {FirstName} {LastName}
                    Email: {Email}
                    Customer Number: {CustomerNumber}
                    Reservation Date: {ReservationDate}
                    Party Size: {PartySize}
                    Restaurant Name: {RestaurantName}
                    Address: {Address}
                    Restaurant Number: {RestaurantNumber}
                    ";
    }
}