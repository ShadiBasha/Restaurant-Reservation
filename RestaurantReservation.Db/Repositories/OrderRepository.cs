using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Interfaces;

namespace RestaurantReservation.Db.Repositories;

public class OrderRepository : ICrud<Order>
{
    public void Create(Order order)
    {
        var context = new RestaurantDbContext();
        context.Add(order);
        context.SaveChanges();
    }

    public void Update(int orderId, Order newOrderData)
    {
        var context = new RestaurantDbContext();
        var order = context.Orders.Find(orderId);
        if (order == null)
            throw new Exception("Order does not exist");
        order.ReservationId = newOrderData.ReservationId;
        order.EmployeeId = newOrderData.EmployeeId;
        order.OrderDate = newOrderData.OrderDate;
        order.TotalAmount = newOrderData.TotalAmount;
        context.SaveChanges();
    }

    public void Delete(int orderId)
    {
        var context = new RestaurantDbContext();
        var order = context.Orders.Find(orderId);
        if (order == null)
            throw new Exception("Order does not exist"); 
        context.Orders.Remove(order);
        context.SaveChanges();
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