using RestaurantReservation.Db.Interfaces;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories;

public class EmployeeRepository : ICrud<Employee>
{
    public async Task CreateAsync(Employee employee)
    {
        using var context = new RestaurantDbContext();
        await context.Employees.AddRangeAsync(employee);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(int employeeId, Employee newEmployeeData)
    {
        using var context = new RestaurantDbContext();
        var employee = await context.Employees.FindAsync(employeeId);
        if (employee == null)
            throw new Exception("Employee does not exist");
        employee.RestaurantId = newEmployeeData.RestaurantId;
        employee.FirstName = newEmployeeData.FirstName;
        employee.LastName = newEmployeeData.LastName;
        employee.Position = newEmployeeData.Position;
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int employeeId)
    {
        using var context = new RestaurantDbContext();
        var employee = await context.Employees.FindAsync(employeeId);
        if (employee == null)
            throw new Exception("Employee does not exist");
        context.Employees.Remove(employee);
        await context.SaveChangesAsync();
    }
    
    public static void ListManagers()
    {
        var context = new RestaurantDbContext();
        var managers = context.Employees.Where(employee => employee.Position == "Manager").ToList();
        foreach (var manager in managers)
        {
            Console.WriteLine($"""
                               Name : {manager.FirstName} {manager.LastName}
                               Restaurant Id : {manager.RestaurantId}
                               -----------------------------
                               """);
        }
    }
}