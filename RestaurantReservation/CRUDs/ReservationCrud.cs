using RestaurantReservation.Db;

namespace RestaurantReservation.CRUDs;

public class ReservationCrud : ICrud<Reservation>
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
}