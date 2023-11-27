using RestaurantReservation.Db.Interfaces;

namespace RestaurantReservation.Db.Repositories;

public class ReservationRepository : ICrud<Reservation>
{
    public void Create(Reservation reservation)
    {
        var context = new RestaurantDbContext();
        context.Reservations.Add(reservation);
        context.SaveChanges();
    }

    public void Update(int reservationId, Reservation newReservationData)
    {
        var context = new RestaurantDbContext();
        var reservation = context.Reservations.Find(reservationId);
        if (reservation == null)
            throw new Exception("Reservation does not exist");
        reservation.CustomerId = newReservationData.CustomerId;
        reservation.RestaurantId = newReservationData.RestaurantId;
        reservation.TableId = newReservationData.TableId;
        reservation.ReservationDate = newReservationData.ReservationDate;
        reservation.PartySize = newReservationData.PartySize;
        context.SaveChanges();
    }

    public void Delete(int reservationId)
    {
        var context = new RestaurantDbContext();
        var reservation = context.Reservations.Find(reservationId);
        if (reservation == null)
        {
            throw new Exception("Reservation does not exist");
        }
        context.Remove(reservation);
        context.SaveChanges();
    }
    
    public static void GetReservationsByCustomer(int customerId)
    {
        var context = new RestaurantDbContext();
        var customerReservations = context.Reservations.Where(reservation => reservation.CustomerId == customerId).ToList();
        foreach (var reservation in customerReservations)
        {
            Console.WriteLine($"""
                               Reservation Date :{reservation.ReservationDate}
                               Reservation Party Size : {reservation.PartySize}
                               -----------------------------
                               """);
        }
    }
}