using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Interfaces;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories;

public class OrderRepository : ICrud<Order>
{
    public async Task CreateAsync(Order order)
    {
        using var context = new RestaurantDbContext();
        await context.AddAsync(order);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(int orderId, Order newOrderData)
    {
        using var context = new RestaurantDbContext();
        var order = await context.Orders.FindAsync(orderId);
        if (order == null)
            throw new Exception("Order does not exist");
        order.ReservationId = newOrderData.ReservationId;
        order.EmployeeId = newOrderData.EmployeeId;
        order.OrderDate = newOrderData.OrderDate;
        order.TotalAmount = newOrderData.TotalAmount;
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int orderId)
    {
        using var context = new RestaurantDbContext();
        var order = await context.Orders.FindAsync(orderId);
        if (order == null)
            throw new Exception("Order does not exist"); 
        context.Orders.Remove(order);
        await context.SaveChangesAsync();
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