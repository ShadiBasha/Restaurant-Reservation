using RestaurantReservationDbContext;
using RestaurantReservation.Db;
RestaurantDbContext _context = new RestaurantDbContext();

foreach (var table in _context.Tables.ToList())
{
    Console.WriteLine(table);
}
