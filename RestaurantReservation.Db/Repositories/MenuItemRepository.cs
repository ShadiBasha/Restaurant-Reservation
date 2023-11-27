using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Interfaces;

namespace RestaurantReservation.Db.Repositories;

public class MenuItemRepository : ICrud<MenuItem>
{
    public void Create(MenuItem item)
    {
        var context = new RestaurantDbContext();
        context.MenuItems.Add(item);
        context.SaveChanges();
    }

    public void Update(int itemId, MenuItem newItemData)
    {
        var context = new RestaurantDbContext();
        var item = context.MenuItems.Find(itemId);
        if (item == null)
            throw new Exception("Item does not exist");
        item.RestaurantId = newItemData.RestaurantId;
        item.Name = newItemData.Name;
        item.Description = newItemData.Description;
        item.Price = newItemData.Price;
        context.SaveChanges();
    }

    public void Delete(int itemId)
    {
        var context = new RestaurantDbContext();
        var item = context.MenuItems.Find(itemId);
        if (item == null)
            throw new Exception("Item does not exist");
        context.MenuItems.Remove(item);
        context.SaveChanges();
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
}