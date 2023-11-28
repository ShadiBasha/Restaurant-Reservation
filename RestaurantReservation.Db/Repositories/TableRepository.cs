using RestaurantReservation.Db.Interfaces;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories;

public class TableRepository : ICrud<Table>
{
    public async Task CreateAsync(Table table)
    {
        using var context = new RestaurantDbContext();
        await context.Tables.AddAsync(table);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(int tableId, Table newTableData)
    {
        using var context = new RestaurantDbContext();
        var table = await context.Tables.FindAsync(tableId);
        if (table == null)
            throw new Exception("Table does not exist");
        table.RestaurantId = newTableData.RestaurantId;
        table.Capacity = newTableData.Capacity;
        await context.SaveChangesAsync();
    }
    
    public async Task DeleteAsync(int tableId)
    {
        var context = new RestaurantDbContext();
        var table = await context.Tables.FindAsync(tableId);
        if (table == null)
            throw new Exception("Table does not exist");
        context.Remove(table);
        await context.SaveChangesAsync();
    }

}