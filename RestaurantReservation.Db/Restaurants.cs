namespace RestaurantReservation.Db;

public class Restaurants
{
    public int RestaurantId { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string OpeningHours { get; set; }
    public ICollection<Employees> Employees { get; set; }
    public ICollection<MenuItems> MenuItems { get; set; }
    public ICollection<Tables> Tables { get; set; }
    public ICollection<Reservations> Reservations { get; set; }
}