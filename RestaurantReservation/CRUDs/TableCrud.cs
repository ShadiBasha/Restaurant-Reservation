using RestaurantReservation.Db;

namespace RestaurantReservation.CRUDs;

public class TableCrud : ICrud<Table>
{
    public void Create(Table table)
    {
        var context = new RestaurantDbContext();
        context.Tables.Add(table);
        context.SaveChanges();
    }

    public void Update(int tableId, Table newTableData)
    {
        var context = new RestaurantDbContext();
        var table = context.Tables.Find(tableId);
        if (table == null)
            throw new Exception("Table does not exist");
        table.RestaurantId = newTableData.RestaurantId;
        table.Capacity = newTableData.Capacity;
        context.SaveChanges();
    }
    
    public void Delete(int tableId)
    {
        var context = new RestaurantDbContext();
        var table = context.Tables.Find(tableId);
        if (table == null)
            throw new Exception("Table does not exist");
        context.Remove(table);
        context.SaveChanges();
    }

}