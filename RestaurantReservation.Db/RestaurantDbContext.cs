using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Views;

namespace RestaurantReservation.Db
{
    public class RestaurantDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<RestaurantRevenue> RestaurantRevenues { get; set; }

        public DbSet<ReservationView> ReservationViews { get; set; }
        
        public DbSet<EmployeeView> EmployeeView { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=localhost\SQLEXPRESS;Database=RestaurantReservationCore;Trusted_Connection=True;TrustServerCertificate=true;"
            );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //move seeding to extention 
            modelBuilder.Entity<Reservation>(entity =>
                {
                    entity.HasOne(r => r.Table)
                        .WithMany(t => t.Reservations)
                        .HasForeignKey(r => r.TableId)
                        .OnDelete(DeleteBehavior.Cascade);
                });
            
            modelBuilder
                .Entity<RestaurantRevenue>().HasNoKey().ToView(null);
            
            modelBuilder
                .Entity<ReservationView>(res =>
                {
                    res.HasNoKey();
                    res.ToView("ReservationView");
                });
            
            modelBuilder
                .Entity<EmployeeView>(emp =>
                {
                    emp.HasNoKey();
                    emp.ToView("EmployeeView");
                });
            
            var customersList = new Customer[]
            {
                new Customer
                {
                    CustomerId = 1,
                    FirstName = "Alice",
                    LastName = "Smith",
                    Email = "alice.smith@example.com",
                    PhoneNumber = "111-222-3333"
                },
                new Customer
                {
                    CustomerId = 2,
                    FirstName = "Bob",
                    LastName = "Johnson",
                    Email = "bob.johnson@example.com",
                    PhoneNumber = "444-555-6666"
                },
                new Customer
                {
                    CustomerId = 3,
                    FirstName = "Charlie",
                    LastName = "Brown",
                    Email = "charlie.brown@example.com",
                    PhoneNumber = "777-888-9999"
                },
                new Customer
                {
                    CustomerId = 4,
                    FirstName = "David",
                    LastName = "Miller",
                    Email = "david.miller@example.com",
                    PhoneNumber = "123-456-7890"
                },
                new Customer
                {
                    CustomerId = 5,
                    FirstName = "Eva",
                    LastName = "Davis",
                    Email = "eva.davis@example.com",
                    PhoneNumber = "555-666-7777"
                }
            };
            
            var restaurantsList = new Restaurant[]
            {
                new Restaurant
                {
                    RestaurantId = 1,
                    Name = "Tasty Bites",
                    Address = "123 Main St, Cityville",
                    PhoneNumber = "111-222-3333",
                    OpeningHours = "Mon-Sat: 10 AM - 9 PM, Sun: 12 PM - 8 PM"
                },
                new Restaurant
                {
                    RestaurantId = 2,
                    Name = "Spice World",
                    Address = "456 Oak St, Townsville",
                    PhoneNumber = "444-555-6666",
                    OpeningHours = "Mon-Fri: 11 AM - 8 PM, Sat-Sun: 12 PM - 7 PM"
                },
                new Restaurant
                {
                    RestaurantId = 3,
                    Name = "Sushi Delight",
                    Address = "789 Pine St, Villageton",
                    PhoneNumber = "777-888-9999",
                    OpeningHours = "Tue-Sun: 5 PM - 10 PM"
                },
                new Restaurant
                {
                    RestaurantId = 4,
                    Name = "Pizza Palace",
                    Address = "101 Cedar St, Hamletville",
                    PhoneNumber = "123-456-7890",
                    OpeningHours = "Mon-Sun: 11 AM - 11 PM"
                },
                new Restaurant
                {
                    RestaurantId = 5,
                    Name = "Café Royale",
                    Address = "202 Elm St, Riverside",
                    PhoneNumber = "555-666-7777",
                    OpeningHours = "Mon-Sat: 8 AM - 6 PM"
                }
            };
            
            var employeesList = new Employee[]
            {
                new Employee
                {
                    EmployeeId = 1,
                    RestaurantId = restaurantsList[0].RestaurantId,
                    FirstName = "Emily",
                    LastName = "Johnson",
                    Position = "Chef"
                },
                new Employee
                {
                    EmployeeId = 2,
                    RestaurantId = restaurantsList[1].RestaurantId,
                    FirstName = "Alex",
                    LastName = "Williams",
                    Position = "Waiter"
                },
                new Employee
                {
                    EmployeeId = 3,
                    RestaurantId = restaurantsList[2].RestaurantId,
                    FirstName = "Daniel",
                    LastName = "Brown",
                    Position = "Manager"
                },
                new Employee
                {
                    EmployeeId = 4,
                    RestaurantId = restaurantsList[3].RestaurantId,
                    FirstName = "Olivia",
                    LastName = "Jones",
                    Position = "Cook"
                },
                new Employee
                {
                    EmployeeId = 5,
                    RestaurantId = restaurantsList[4].RestaurantId,
                    FirstName = "Liam",
                    LastName = "Smith",
                    Position = "Waitress"
                }
            };
            
            var menuItemsList = new MenuItem[]
            {
                new MenuItem
                {
                    MenuItemId = 1,
                    RestaurantId = restaurantsList[0].RestaurantId,
                    Name = "Chicken Alfredo",
                    Description = "Creamy Alfredo sauce with grilled chicken and fettuccine pasta",
                    Price = 15
                },
                new MenuItem
                {
                    MenuItemId = 2,
                    RestaurantId = restaurantsList[1].RestaurantId,
                    Name = "Spicy Tofu Stir-Fry",
                    Description = "Tofu and mixed vegetables stir-fried in a spicy sauce",
                    Price = 12
                },
                new MenuItem
                {
                    MenuItemId = 3,
                    RestaurantId = restaurantsList[2].RestaurantId,
                    Name = "Sashimi Platter",
                    Description = "Assorted slices of fresh sashimi with soy sauce",
                    Price = 20
                },
                new MenuItem
                {
                    MenuItemId = 4,
                    RestaurantId = restaurantsList[3].RestaurantId,
                    Name = "Pepperoni Pizza",
                    Description = "Classic pizza with tomato sauce, mozzarella, and pepperoni",
                    Price = 18
                },
                new MenuItem
                {
                    MenuItemId = 5,
                    RestaurantId = restaurantsList[4].RestaurantId,
                    Name = "Espresso",
                    Description = "Strong black coffee made by forcing hot water through finely-ground coffee beans",
                    Price = 3
                }
            };
            
            var tablesList = new Table[]
            {
                new Table
                {
                    TableId = 1,
                    RestaurantId = restaurantsList[0].RestaurantId,
                    Capacity = 4
                },
                new Table
                {
                    TableId = 2,
                    RestaurantId = restaurantsList[1].RestaurantId,
                    Capacity = 6
                },
                new Table
                {
                    TableId = 3,
                    RestaurantId = restaurantsList[2].RestaurantId,
                    Capacity = 8
                },
                new Table
                {
                    TableId = 4,
                    RestaurantId = restaurantsList[3].RestaurantId,
                    Capacity = 2
                },
                new Table
                {
                    TableId = 5,
                    RestaurantId = restaurantsList[4].RestaurantId,
                    Capacity = 4
                }
            };
            
            var reservationsList = new Reservation[]
            {
                new Reservation
                {
                    ReservationId = 1,
                    CustomerId = customersList[0].CustomerId,
                    RestaurantId = restaurantsList[0].RestaurantId,
                    TableId = tablesList[0].TableId,
                    ReservationDate = DateTime.Now.AddDays(2),
                    PartySize = 3
                },
                new Reservation
                {
                    ReservationId = 2,
                    CustomerId = customersList[1].CustomerId,
                    RestaurantId = restaurantsList[1].RestaurantId,
                    TableId = tablesList[1].TableId,
                    ReservationDate = DateTime.Now.AddDays(1),
                    PartySize = 5
                },
                new Reservation
                {
                    ReservationId = 3,
                    CustomerId = customersList[2].CustomerId,
                    RestaurantId = restaurantsList[2].RestaurantId,
                    TableId = tablesList[2].TableId,
                    ReservationDate = DateTime.Now.AddDays(3),
                    PartySize = 7
                },
                new Reservation
                {
                    ReservationId = 4,
                    CustomerId = customersList[3].CustomerId,
                    RestaurantId = restaurantsList[3].RestaurantId,
                    TableId = tablesList[3].TableId,
                    ReservationDate = DateTime.Now.AddDays(5),
                    PartySize = 2
                },
                new Reservation
                {
                    ReservationId = 5,
                    CustomerId = customersList[4].CustomerId,
                    RestaurantId = restaurantsList[4].RestaurantId,
                    TableId = tablesList[4].TableId,
                    ReservationDate = DateTime.Now.AddDays(4),
                    PartySize = 4
                }
            };
            
            var ordersList = new Order[]
            {
                new Order
                {
                    OrderId = 1,
                    ReservationId = reservationsList[0].ReservationId,
                    EmployeeId = employeesList[0].EmployeeId,
                    OrderDate = DateTime.Now.AddHours(2),
                    TotalAmount = 40
                },
                new Order
                {
                    OrderId = 2,
                    ReservationId = reservationsList[1].ReservationId,
                    EmployeeId = employeesList[1].EmployeeId,
                    OrderDate = DateTime.Now.AddHours(1),
                    TotalAmount = 60
                },
                new Order
                {
                    OrderId = 3,
                    ReservationId = reservationsList[2].ReservationId,
                    EmployeeId = employeesList[2].EmployeeId,
                    OrderDate = DateTime.Now.AddHours(3),
                    TotalAmount = 80
                },
                new Order
                {
                    OrderId = 4,
                    ReservationId = reservationsList[3].ReservationId,
                    EmployeeId = employeesList[3].EmployeeId,
                    OrderDate = DateTime.Now.AddHours(5),
                    TotalAmount = 25
                },
                new Order
                {
                    OrderId = 5,
                    ReservationId = reservationsList[4].ReservationId,
                    EmployeeId = employeesList[4].EmployeeId,
                    OrderDate = DateTime.Now.AddHours(4),
                    TotalAmount = 35
                }
            };
            
            var orderItemsList = new OrderItem[]
            {
                new OrderItem
                {
                    OrderItemId = 1,
                    OrderId = ordersList[0].OrderId,
                    MenuItemId = menuItemsList[0].MenuItemId,
                    Quantity = 2,
                },
                new OrderItem
                {
                    OrderItemId = 2,
                    OrderId = ordersList[1].OrderId,
                    MenuItemId = menuItemsList[1].MenuItemId,
                    Quantity = 3,
                },
                new OrderItem
                {
                    OrderItemId = 3,
                    OrderId = ordersList[2].OrderId,
                    MenuItemId = menuItemsList[2].MenuItemId,
                    Quantity = 1,
                },
                new OrderItem
                {
                    OrderItemId = 4,
                    OrderId = ordersList[3].OrderId,
                    MenuItemId = menuItemsList[3].MenuItemId,
                    Quantity = 4,
                },
                new OrderItem
                {
                    OrderItemId = 5,
                    OrderId = ordersList[4].OrderId,
                    MenuItemId = menuItemsList[4].MenuItemId,
                    Quantity = 2,
                }
            };

            modelBuilder.Entity<Customer>().HasData(customersList);
            modelBuilder.Entity<Restaurant>().HasData(restaurantsList);
            modelBuilder.Entity<Employee>().HasData(employeesList);
            modelBuilder.Entity<MenuItem>().HasData(menuItemsList);
            modelBuilder.Entity<Table>().HasData(tablesList);
            modelBuilder.Entity<Reservation>().HasData(reservationsList);
            modelBuilder.Entity<Order>().HasData(ordersList);
            modelBuilder.Entity<OrderItem>().HasData(orderItemsList);
        }
    }
}