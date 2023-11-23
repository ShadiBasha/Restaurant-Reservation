﻿namespace RestaurantReservation.Db;

public class Customers
{
    public int CustomerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public ICollection<Reservations> Reservations { get; set; }
}