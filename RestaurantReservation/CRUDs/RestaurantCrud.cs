using RestaurantReservation.Db;

namespace RestaurantReservation.CRUDs;

public class RestaurantCrud : ICrud<Restaurant>
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
}