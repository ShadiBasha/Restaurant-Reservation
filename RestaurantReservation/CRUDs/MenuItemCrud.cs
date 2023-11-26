using RestaurantReservation.Db;

namespace RestaurantReservation.CRUDs;

public class MenuItemCrud : ICrud<MenuItem>
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
}