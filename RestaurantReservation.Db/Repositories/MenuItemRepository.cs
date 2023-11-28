using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Interfaces;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories;

public class MenuItemRepository : ICrud<MenuItem>
{
    public async Task CreateAsync(MenuItem item)
    {
        using var context = new RestaurantDbContext();
        await context.MenuItems.AddAsync(item);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(int itemId, MenuItem newItemData)
    {
        using var context = new RestaurantDbContext();
        var item = await context.MenuItems.FindAsync(itemId);
        if (item == null)
            throw new Exception("Item does not exist");
        item.RestaurantId = newItemData.RestaurantId;
        item.Name = newItemData.Name;
        item.Description = newItemData.Description;
        item.Price = newItemData.Price;
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int itemId)
    {
        using var context = new RestaurantDbContext();
        var item = await context.MenuItems.FindAsync(itemId);
        if (item == null)
            throw new Exception("Item does not exist");
        context.MenuItems.Remove(item);
        await context.SaveChangesAsync();
    }
    
    public static void ListOrderedMenuItems(int reservationId)
    {
        using var context = new RestaurantDbContext();
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