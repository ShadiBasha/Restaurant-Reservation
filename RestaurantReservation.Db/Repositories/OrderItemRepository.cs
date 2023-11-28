using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Interfaces;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories;

public class OrderItemRepository : ICrud<OrderItem>
{
    public async Task CreateAsync(OrderItem orderItem)
    {
        using var context = new RestaurantDbContext();
        await context.OrderItems.AddAsync(orderItem);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(int orderItemId, OrderItem newOrderItemData)
    {
        using var context = new RestaurantDbContext();
        var orderItem = await context.OrderItems.FindAsync(orderItemId);
        if (orderItem == null)
            throw new Exception("OrderItem does not exist");
        orderItem.OrderId = newOrderItemData.OrderId;
        orderItem.MenuItemId = newOrderItemData.MenuItemId;
        orderItem.Quantity = newOrderItemData.Quantity;
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int orderItemId)
    {
        var context = new RestaurantDbContext();
        var orderItem = await context.OrderItems.FindAsync(orderItemId);
        if (orderItem == null)
            throw new Exception("OrderItem does not exist");
        context.OrderItems.Remove(orderItem);
        await context.SaveChangesAsync();
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
}