using Microsoft.EntityFrameworkCore;
using RestaurantReservation;
using RestaurantReservation.Db;
using RestaurantReservation.Db.Repositories;

//code

// Console.WriteLine("hello world");
var list = CustomerRepository.GetCustomersWithPartySizeGreaterThan(5);
foreach (var customer in list)
{
    Console.WriteLine(customer.FirstName);
}