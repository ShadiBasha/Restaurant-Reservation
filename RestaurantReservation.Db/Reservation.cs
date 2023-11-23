﻿using System.ComponentModel.DataAnnotations;

namespace RestaurantReservation.Db;

public class Reservation
{
    public int ReservationId { get; set; }
    public Customer Customer { get; set; }
    public Restaurant Restaurant { get; set; }
    public Table Table { get; set; }
    public DateTime ReservationDate { get; set; }
    public int PartySize { get; set; }
    public ICollection<Order> Orders { get; set; }
}