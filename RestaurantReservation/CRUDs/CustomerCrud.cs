using RestaurantReservation.Db;

namespace RestaurantReservation.CRUDs;

public class CustomerCrud : ICrud<Customer>
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
        var customerToDelete = context.Customers.Find(customerId);
        if (customerToDelete == null)
        {
            throw new Exception("Customer does not exist");
        }
        context.Customers.Remove(customerToDelete);
        context.SaveChanges();
    }
}