using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Interfaces;

namespace RestaurantReservation.Db.Repositories;

public class RestaurantRepository : ICrud<Restaurant>
{
    public void Create(Restaurant restaurant)
    {
        var context = new RestaurantDbContext();
        context.Restaurants.Add(restaurant);
        context.SaveChanges();
    }

    public void Update(int restaurantId, Restaurant newRestaurantData)
    {
        var context = new RestaurantDbContext();
        var restaurant = context.Restaurants.Find(restaurantId);
        if (restaurant == null)
            throw new Exception("Restaurant does not exist");
        restaurant.Name = newRestaurantData.Name;
        restaurant.Address = newRestaurantData.Address;
        restaurant.PhoneNumber = newRestaurantData.PhoneNumber;
        restaurant.OpeningHours = newRestaurantData.OpeningHours;
        context.SaveChanges();
    }

    public void Delete(int restaurantId)
    {
        var context = new RestaurantDbContext();
        var restaurant = context.Restaurants.Find(restaurantId);
        if (restaurant == null)
            throw new Exception("Restaurant does not exist");
        context.Restaurants.Remove(restaurant);
        context.SaveChanges();
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