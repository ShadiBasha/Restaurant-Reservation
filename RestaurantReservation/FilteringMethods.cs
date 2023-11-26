using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db;

namespace RestaurantReservation;

public static class FilteringMethods
{
    public static void ListManagers()
    {
        var context = new RestaurantDbContext();
        var managers = context.Employees.Where(employee => employee.Position == "Manager").ToList();
        foreach (var manager in managers)
        {
            Console.WriteLine($"""
                              Name : {manager.FirstName} {manager.LastName}
                              Restaurant Id : {manager.RestaurantId}
                              -----------------------------
                              """);
        }
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

    public static void ListOrdersAndMenuItems(int reservationId)
    {
        var context = new RestaurantDbContext();
        var ordersList = context.Orders
            .Include(order => order.OrderItems)
            .ThenInclude(item => item.MenuItem)
            .Where(order => order.ReservationId == reservationId);
        foreach (var order in ordersList)
        {
            Console.WriteLine($"""
                              Order Id: {order.OrderId}
                              Order Date : {order.OrderDate}
                              ******************************
                              """);
            foreach (var orderItem in order.OrderItems.ToList()) 
            {
                Console.WriteLine($"""
                                  Item        : {orderItem.MenuItem.Name}
                                  Description : {orderItem.MenuItem.Description}
                                  Price       : {orderItem.MenuItem.Price}
                                  Quantity    : {orderItem.Quantity}
                                  ******************************
                                  """);
            }
            Console.WriteLine($"Total Amount : {order.TotalAmount}");
            Console.WriteLine($"-----------------------------");
        }
    }

    public static void ListOrderedMenuItems(int reservationId)
    {
        var context = new RestaurantDbContext();
        var ordersList = context.Orders
            .Include(order => order.OrderItems)
            .ThenInclude(item => item.MenuItem)
            .Where(order => order.ReservationId == reservationId); 
        foreach (var order in ordersList)
        {
            foreach (var orderItem in order.OrderItems.ToList()) 
            {
                Console.WriteLine($"""
                                   Item        : {orderItem.MenuItem.Name}
                                   Description : {orderItem.MenuItem.Description}
                                   Price       : {orderItem.MenuItem.Price}
                                   Quantity    : {orderItem.Quantity}
                                   ******************************
                                   """);
            }
            Console.WriteLine($"-----------------------------");
        }
    }

    public static void CalculateAverageOrderAmount(int employeeId)
    {
        var context = new RestaurantDbContext();
        var employeeAverageTotalAmount = context.Employees
            .Include(employee => employee.Orders)
            .FirstOrDefault(employee => employee.EmployeeId == employeeId)?
            .Orders
            .Average(order => order.TotalAmount);
        if (employeeAverageTotalAmount == null)
        {
           throw new Exception("Employee ID does not exist");
        }else
            Console.WriteLine($"Employee {employeeId} Average Order Amount is {employeeAverageTotalAmount}$");
    }
}