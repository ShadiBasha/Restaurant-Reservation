using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Interfaces;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories;

public class RestaurantRepository : ICrud<Restaurant>
{
    public async Task CreateAsync(Restaurant restaurant)
    {
        using var context = new RestaurantDbContext();
        await context.Restaurants.AddAsync(restaurant);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(int restaurantId, Restaurant newRestaurantData)
    {
        var context = new RestaurantDbContext();
        var restaurant = await context.Restaurants.FindAsync(restaurantId);
        if (restaurant == null)
            throw new Exception("Restaurant does not exist");
        restaurant.Name = newRestaurantData.Name;
        restaurant.Address = newRestaurantData.Address;
        restaurant.PhoneNumber = newRestaurantData.PhoneNumber;
        restaurant.OpeningHours = newRestaurantData.OpeningHours;
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int restaurantId)
    {
        using var context = new RestaurantDbContext();
        var restaurant = await context.Restaurants.FindAsync(restaurantId);
        if (restaurant == null)
            throw new Exception("Restaurant does not exist"); 
        context.Restaurants.Remove(restaurant);
        await context.SaveChangesAsync();
    }
    
    public static RestaurantRevenue? GetRestaurantRevenue(int restaurantId)
    {
        var context = new RestaurantDbContext();
        var result = context.RestaurantRevenues
            .FromSqlRaw("""
                        begin
                            declare @RestaurantId int = {0}
                            declare @result int
                            exec
                                @result = dbo.RestaurantRevenue @RestaurantId
                            select @result as Revenue
                        end
                        """, restaurantId)
            .AsEnumerable()
            .FirstOrDefault();
        return result;
    }
}