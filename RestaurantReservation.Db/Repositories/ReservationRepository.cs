using RestaurantReservation.Db.Interfaces;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories;

public class ReservationRepository : ICrud<Reservation>
{
    public async Task CreateAsync(Reservation reservation)
    {
        using var context = new RestaurantDbContext();
        await context.Reservations.AddAsync(reservation);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(int reservationId, Reservation newReservationData)
    {
        using var context = new RestaurantDbContext();
        var reservation = await context.Reservations.FindAsync(reservationId);
        if (reservation == null)
            throw new Exception("Reservation does not exist");
        reservation.CustomerId = newReservationData.CustomerId;
        reservation.RestaurantId = newReservationData.RestaurantId;
        reservation.TableId = newReservationData.TableId;
        reservation.ReservationDate = newReservationData.ReservationDate;
        reservation.PartySize = newReservationData.PartySize;
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int reservationId)
    {
        using var context = new RestaurantDbContext();
        var reservation = await context.Reservations.FindAsync(reservationId);
        if (reservation == null)
        {
            throw new Exception("Reservation does not exist");
        }
        context.Remove(reservation);
        await context.SaveChangesAsync();
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