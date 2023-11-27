namespace RestaurantReservation.Db;

public class RestaurantRevenue
{
    public int? Revenue { get; set; }
    public override string ToString()
    {
        return $"Revenue: {Revenue}";
    }
}