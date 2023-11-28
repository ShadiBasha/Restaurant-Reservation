using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Interfaces;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories;

public class CustomerRepository : ICrud<Customer>
{
    public async Task CreateAsync(Customer customer)
    {
        using var context = new RestaurantDbContext();
        await context.Customers.AddAsync(customer);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(int customerId, Customer newCustomerData)
    {
        using var context = new RestaurantDbContext();
        var customer = await context.Customers.FindAsync(customerId);
        if (customer == null)
            throw new Exception("Customer does not exist");
        customer.FirstName = newCustomerData.FirstName;
        customer.LastName = newCustomerData.LastName;
        customer.Email = newCustomerData.Email;
        customer.PhoneNumber = newCustomerData.PhoneNumber;
        await context.SaveChangesAsync();

    }

    public async Task DeleteAsync(int customerId)
    {
        using var context = new RestaurantDbContext();
        var customer = await context.Customers.FindAsync(customerId);
        if (customer == null)
        {
            throw new Exception("Customer does not exist");
        }
        context.Customers.Remove(customer);
        await context.SaveChangesAsync();
    }
    
    public static List<Customer> GetCustomersWithPartySizeGreaterThan(int partySize)
    {
        using var context = new RestaurantDbContext();
        var result = context.Customers
            .FromSqlRaw("""
                        CustomersReservations {0}
                        """, partySize)
            .ToList();
        return result;
    }
}