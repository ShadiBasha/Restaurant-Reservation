namespace RestaurantReservation.Db;

public class Tables
{
    public int TablesId { get; set; }
    public int RestaurantId { get; set; }
    public int Capacity { get; set; }
    public ICollection<Reservations> Reservations { get; set; }

}