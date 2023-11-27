using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Interfaces;

namespace RestaurantReservation.Db.Repositories;

public class CustomerRepository : ICrud<Customer>
{
    public void Create(Customer customer)
    {
        var context = new RestaurantDbContext();
        context.Customers.Add(customer);
        context.SaveChanges();
    }

    public void Update(int customerId, Customer newCustomerData)
    {
        var context = new RestaurantDbContext();
        var customer = context.Customers.Find(customerId);
        if(customer == null)
            throw new Exception("Customer does not exist");
        customer.FirstName = newCustomerData.FirstName;
        customer.LastName = newCustomerData.LastName;
        customer.Email = newCustomerData.Email;
        customer.PhoneNumber = newCustomerData.PhoneNumber;
        context.SaveChanges();
    }

    public void Delete(int customerId)
    {
        var context = new RestaurantDbContext();
        var customer = context.Customers.Find(customerId);
        if (customer == null)
        {
            throw new Exception("Customer does not exist");
        }
        context.Customers.Remove(customer);
        context.SaveChanges();
    }
    
    public static List<Customer>? GetCustomersWithPartySizeGreaterThan(int partySize)
    {
        var context = new RestaurantDbContext();
        var result = context.Customers
            .FromSqlRaw("""
                        CustomersReservations {0}
                        """, partySize)
            .ToList();
        return result;
    }
}