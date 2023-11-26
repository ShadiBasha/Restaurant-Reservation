using RestaurantReservation.Db;

namespace RestaurantReservation.CRUDs;

public class OrderItemCrud : ICrud<OrderItem>
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

}