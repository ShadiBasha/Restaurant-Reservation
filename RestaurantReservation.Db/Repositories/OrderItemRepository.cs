using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Interfaces;

namespace RestaurantReservation.Db.Repositories;

public class OrderItemRepository : ICrud<OrderItem>
{
    public void Create(OrderItem orderItem)
    {
        var context = new RestaurantDbContext();
        context.OrderItems.Add(orderItem);
        context.SaveChanges();
    }

    public void Update(int orderItemId, OrderItem newOrderItemData)
    {
        var context = new RestaurantDbContext();
        var orderItem = context.OrderItems.Find(orderItemId);
        if (orderItem == null)
            throw new Exception("OrderItem does not exist");
        orderItem.OrderId = newOrderItemData.OrderId;
        orderItem.MenuItemId = newOrderItemData.MenuItemId;
        orderItem.Quantity = newOrderItemData.Quantity;
        context.SaveChanges();
    }

    public void Delete(int orderItemId)
    {
        var context = new RestaurantDbContext();
        var orderItem = context.OrderItems.Find(orderItemId);
        if (orderItem == null)
            throw new Exception("OrderItem does not exist");
        context.OrderItems.Remove(orderItem);
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