using RestaurantReservation.Db;

namespace RestaurantReservation.CRUDs;

public class EmployeeCrud : ICrud<Employee>
{
    public void Create(Employee employee)
    {
        var context = new RestaurantDbContext();
        context.Employees.Add(employee);
        context.SaveChanges();
    }

    public void Update(int employeeId, Employee newEmployeeData)
    {
        var context = new RestaurantDbContext();
        var employee = context.Employees.Find(employeeId);
        if (employee == null)
            throw new Exception("Employee does not exist");
        employee.RestaurantId = newEmployeeData.RestaurantId;
        employee.FirstName = newEmployeeData.FirstName;
        employee.LastName = newEmployeeData.LastName;
        employee.Position = newEmployeeData.Position;
        context.SaveChanges();
    }

    public void Delete(int employeeId)
    {
        var context = new RestaurantDbContext();
        var employee = context.Employees.Find(employeeId);
        if (employee == null)
            throw new Exception("Employee does not exist");
        context.Employees.Remove(employee);
        context.SaveChanges();
    }
}