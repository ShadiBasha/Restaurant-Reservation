using RestaurantReservation.Db;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation
{
    class Program
    {
        const string Line = "---------------";

        static async Task Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Customer Operations");
                Console.WriteLine("2. Employee Operations");
                Console.WriteLine("3. Menu Item Operations");
                Console.WriteLine("4. Order Item Operations");
                Console.WriteLine("5. Order Operations");
                Console.WriteLine("6. Reservation Operations");
                Console.WriteLine("7. Restaurant Operations");
                Console.WriteLine("8. Table Operations");
                Console.WriteLine("0. Exit");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        await CustomerOperations();
                        break;
                    case "2":
                        await EmployeeOperations();
                        break;
                    case "3":
                        await MenuItemOperations();
                        break;
                    case "4":
                        await OrderItemOperations();
                        break;
                    case "5":
                        await OrderOperations();
                        break;
                    case "6":
                        await ReservationOperations();
                        break;
                    case "7":
                        await RestaurantOperations();
                        break;
                    case "8":
                        await TableOperations();
                        break;
                    case "0":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static async Task TableOperations()
        {
            var tableRepository = new TableRepository();
            using var context = new RestaurantDbContext();
            
            while (true)
            {
                Console.WriteLine("Table Operations:");
                Console.WriteLine("1. Create a new table");
                Console.WriteLine("2. Display all tables");
                Console.WriteLine("3. Update a table");
                Console.WriteLine("4. Delete a table");
                Console.WriteLine("0. Back");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        await CreateTable(tableRepository);
                        break;
                    case "2":
                        DisplayTables(context.Tables.ToList());
                        break;
                    case "3":
                        await UpdateTable(tableRepository);
                        break;
                    case "4":
                        await DeleteTable(tableRepository);
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static async Task CreateTable(TableRepository repository)
        {
            var newTable = new Table
            {
                RestaurantId = int.Parse(GetInput("Enter restaurant ID: ")),
                Capacity = int.Parse(GetInput("Enter table capacity: "))
            };

            await repository.CreateAsync(newTable);
            Console.WriteLine("Table created successfully.");
        }

        static void DisplayTables(List<Table>? tables)
        {
            Console.WriteLine("All Tables:");
            DisplayEntities(tables);
        }

        static async Task UpdateTable(TableRepository repository)
        {
            var tableId = int.Parse(GetInput("Enter table ID to update: "));

            var updatedTableData = new Table
            {
                RestaurantId = int.Parse(GetInput("Enter updated restaurant ID: ")),
                Capacity = int.Parse(GetInput("Enter updated table capacity: "))
            };

            await repository.UpdateAsync(tableId, updatedTableData);
            Console.WriteLine("Table updated successfully.");
        }

        static async Task DeleteTable(TableRepository repository)
        {
            var tableId = int.Parse(GetInput("Enter table ID to delete: "));
            await repository.DeleteAsync(tableId);
            Console.WriteLine("Table deleted successfully.");
        }
        
        static async Task RestaurantOperations()
        {
            var restaurantRepository = new RestaurantRepository();
            using var context = new RestaurantDbContext();
            
            while (true)
            {
                Console.WriteLine("Restaurant Operations:");
                Console.WriteLine("1. Create a new restaurant");
                Console.WriteLine("2. Display all restaurants");
                Console.WriteLine("3. Update a restaurant");
                Console.WriteLine("4. Delete a restaurant");
                Console.WriteLine("5. Get restaurant revenue");
                Console.WriteLine("0. Back");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        await CreateRestaurant(restaurantRepository);
                        break;
                    case "2":
                        DisplayRestaurants(context.Restaurants.ToList());
                        break;
                    case "3":
                        await UpdateRestaurant(restaurantRepository);
                        break;
                    case "4":
                        await DeleteRestaurant(restaurantRepository);
                        break;
                    case "5":
                        GetRestaurantRevenue(restaurantRepository);
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static async Task CreateRestaurant(RestaurantRepository repository)
        {
            var newRestaurant = new Restaurant
            {
                Name = GetInput("Enter restaurant name: "),
                Address = GetInput("Enter restaurant address: "),
                PhoneNumber = GetInput("Enter restaurant phone number: "),
                OpeningHours = GetInput("Enter restaurant opening hours: ")
            };

            await repository.CreateAsync(newRestaurant);
            Console.WriteLine("Restaurant created successfully.");
        }

        static void DisplayRestaurants(List<Restaurant>? restaurants)
        {
            Console.WriteLine("All Restaurants:");
            DisplayEntities(restaurants);
        }

        static async Task UpdateRestaurant(RestaurantRepository repository)
        {
            var restaurantId = int.Parse(GetInput("Enter restaurant ID to update: "));

            var updatedRestaurantData = new Restaurant
            {
                Name = GetInput("Enter updated restaurant name: "),
                Address = GetInput("Enter updated restaurant address: "),
                PhoneNumber = GetInput("Enter updated restaurant phone number: "),
                OpeningHours = GetInput("Enter updated restaurant opening hours: ")
            };

            await repository.UpdateAsync(restaurantId, updatedRestaurantData);
            Console.WriteLine("Restaurant updated successfully.");
        }

        static async Task DeleteRestaurant(RestaurantRepository repository)
        {
            var restaurantId = int.Parse(GetInput("Enter restaurant ID to delete: "));
            await repository.DeleteAsync(restaurantId);
            Console.WriteLine("Restaurant deleted successfully.");
        }

        static void GetRestaurantRevenue(RestaurantRepository repository)
        {
            var restaurantId = int.Parse(GetInput("Enter restaurant ID: "));
            var restaurantRevenue = RestaurantRepository.GetRestaurantRevenue(restaurantId);
            Console.WriteLine($"Restaurant {restaurantId} Revenue: {restaurantRevenue?.Revenue ?? 0}$");
        }
        
        static async Task ReservationOperations()
        {
            var reservationRepository = new ReservationRepository();
            using var context = new RestaurantDbContext();
            
            while (true)
            {
                Console.WriteLine("Reservation Operations:");
                Console.WriteLine("1. Create a new reservation");
                Console.WriteLine("2. Display all reservations");
                Console.WriteLine("3. Update a reservation");
                Console.WriteLine("4. Delete a reservation");
                Console.WriteLine("5. Get reservations by customer");
                Console.WriteLine("0. Back");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        await CreateReservation(reservationRepository);
                        break;
                    case "2":
                        DisplayReservations(context.Reservations.ToList());
                        break;
                    case "3":
                        await UpdateReservation(reservationRepository);
                        break;
                    case "4":
                        await DeleteReservation(reservationRepository);
                        break;
                    case "5":
                        GetReservationsByCustomer(reservationRepository);
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static async Task CreateReservation(ReservationRepository repository)
        {
            var newReservation = new Reservation
            {
                CustomerId = int.Parse(GetInput("Enter customer ID: ")),
                RestaurantId = int.Parse(GetInput("Enter restaurant ID:")),
                TableId = int.Parse(GetInput("Enter table ID: ")),
                ReservationDate = DateTime.Parse(GetInput("Enter reservation date (yyyy-MM-dd HH:mm:ss): ")),
                PartySize = int.Parse(GetInput("Enter party size: "))
            };

            await repository.CreateAsync(newReservation);
            Console.WriteLine("Reservation created successfully.");
        }

        static void DisplayReservations(List<Reservation>? reservations)
        {
            Console.WriteLine("All Reservations:");
            DisplayEntities(reservations);
        }

        static async Task UpdateReservation(ReservationRepository repository)
        {
            var reservationId = int.Parse(GetInput("Enter reservation ID to update: "));

            var updatedReservationData = new Reservation
            {
                CustomerId = int.Parse(GetInput("Enter updated customer ID: ")),
                RestaurantId = int.Parse(GetInput("Enter updated restaurant ID:")),
                TableId = int.Parse(GetInput("Enter updated table ID: ")),
                ReservationDate = DateTime.Parse(GetInput("Enter updated reservation date (yyyy-MM-dd HH:mm:ss): ")),
                PartySize = int.Parse(GetInput("Enter updated party size: "))
            };

            await repository.UpdateAsync(reservationId, updatedReservationData);
            Console.WriteLine("Reservation updated successfully.");
        }

        static async Task DeleteReservation(ReservationRepository repository)
        {
            var reservationId = int.Parse(GetInput("Enter reservation ID to delete: "));
            await repository.DeleteAsync(reservationId);
            Console.WriteLine("Reservation deleted successfully.");
        }

        static void GetReservationsByCustomer(ReservationRepository repository)
        {
            var customerId = int.Parse(GetInput("Enter customer ID: "));
            ReservationRepository.GetReservationsByCustomer(customerId);
        }
        
        static async Task OrderOperations()
        {
            var orderRepository = new OrderRepository();
            using var context = new RestaurantDbContext();

            while (true)
            {
                Console.WriteLine("Order Operations:");
                Console.WriteLine("1. Create a new order");
                Console.WriteLine("2. Display all orders");
                Console.WriteLine("3. Update an order");
                Console.WriteLine("4. Delete an order");
                Console.WriteLine("5. Calculate average order amount for an employee");
                Console.WriteLine("0. Back");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        await CreateOrder(orderRepository);
                        break;
                    case "2":
                        DisplayOrders(context.Orders.ToList());
                        break;
                    case "3":
                        await UpdateOrder(orderRepository);
                        break;
                    case "4":
                        await DeleteOrder(orderRepository);
                        break;
                    case "5":
                        CalculateAverageOrderAmount(orderRepository);
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static async Task CreateOrder(OrderRepository repository)
        {
            var newOrder = new Order
            {
                ReservationId = int.Parse(GetInput("Enter reservation ID: ")),
                EmployeeId = int.Parse(GetInput("Enter employee ID:")),
                OrderDate = DateTime.Parse(GetInput("Enter order date (yyyy-MM-dd HH:mm:ss): ")),
                TotalAmount = int.Parse(GetInput("Enter total amount: "))
            };

            await repository.CreateAsync(newOrder);
            Console.WriteLine("Order created successfully.");
        }

        static void DisplayOrders(List<Order>? orders)
        {
            Console.WriteLine("All Orders:");
            DisplayEntities(orders);
        }

        static async Task UpdateOrder(OrderRepository repository)
        {
            var orderId = int.Parse(GetInput("Enter order ID to update: "));

            var updatedOrderData = new Order
            {
                ReservationId = int.Parse(GetInput("Enter updated reservation ID: ")),
                EmployeeId = int.Parse(GetInput("Enter updated employee ID:")),
                OrderDate = DateTime.Parse(GetInput("Enter updated order date (yyyy-MM-dd HH:mm:ss): ")),
                TotalAmount = int.Parse(GetInput("Enter updated total amount: "))
            };

            await repository.UpdateAsync(orderId, updatedOrderData);
            Console.WriteLine("Order updated successfully.");
        }

        static async Task DeleteOrder(OrderRepository repository)
        {
            var orderId = int.Parse(GetInput("Enter order ID to delete: "));
            await repository.DeleteAsync(orderId);
            Console.WriteLine("Order deleted successfully.");
        }

        static void CalculateAverageOrderAmount(OrderRepository repository)
        {
            var employeeId = int.Parse(GetInput("Enter employee ID: "));
            OrderRepository.CalculateAverageOrderAmount(employeeId);
        }


        static async Task OrderItemOperations()
        {
            var orderItemRepository = new OrderItemRepository();
            using var context = new RestaurantDbContext();
            
            while (true)
            {
                Console.WriteLine("Order Item Operations:");
                Console.WriteLine("1. Create a new order item");
                Console.WriteLine("2. Display all order items");
                Console.WriteLine("3. Update an order item");
                Console.WriteLine("4. Delete an order item");
                Console.WriteLine("5. List orders and menu items for a reservation");
                Console.WriteLine("0. Back");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        await CreateOrderItem(orderItemRepository);
                        break;
                    case "2":
                        DisplayOrderItems(context.OrderItems.ToList());
                        break;
                    case "3":
                        await UpdateOrderItem(orderItemRepository);
                        break;
                    case "4":
                        await DeleteOrderItem(orderItemRepository);
                        break;
                    case "5":
                        ListOrdersAndMenuItems(orderItemRepository);
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
        
        static async Task CreateOrderItem(OrderItemRepository repository)
        {
            var newOrderItem = new OrderItem
            {
                OrderId = int.Parse(GetInput("Enter order ID: ")),
                MenuItemId = int.Parse(GetInput("Enter menu item ID:")),
                Quantity = int.Parse(GetInput("Enter quantity: "))
            };

            await repository.CreateAsync(newOrderItem);
            Console.WriteLine("Order item created successfully.");
        }

        static void DisplayOrderItems(List<OrderItem>? orderItems)
        {
            Console.WriteLine("All Order Items:");
            DisplayEntities(orderItems);
        }

        static async Task UpdateOrderItem(OrderItemRepository repository)
        {
            var orderItemId = int.Parse(GetInput("Enter order item ID to update: "));

            var updatedOrderItemData = new OrderItem
            {
                OrderId = int.Parse(GetInput("Enter updated order ID: ")),
                MenuItemId = int.Parse(GetInput("Enter updated menu item ID:")),
                Quantity = int.Parse(GetInput("Enter updated quantity: "))
            };

            await repository.UpdateAsync(orderItemId, updatedOrderItemData);
            Console.WriteLine("Order item updated successfully.");
        }

        static async Task DeleteOrderItem(OrderItemRepository repository)
        {
            var orderItemId = int.Parse(GetInput("Enter order item ID to delete: "));
            await repository.DeleteAsync(orderItemId);
            Console.WriteLine("Order item deleted successfully.");
        }

        static void ListOrdersAndMenuItems(OrderItemRepository repository)
        {
            var reservationId = int.Parse(GetInput("Enter reservation ID: "));
            OrderItemRepository.ListOrdersAndMenuItems(reservationId);
        }
        static async Task MenuItemOperations()
        {
            var menuItemRepository = new MenuItemRepository();
            var context = new RestaurantDbContext();
            while (true)
            {
                Console.WriteLine("Menu Item Operations:");
                Console.WriteLine("1. Create a new menu item");
                Console.WriteLine("2. Display all menu items");
                Console.WriteLine("3. Update a menu item");
                Console.WriteLine("4. Delete a menu item");
                Console.WriteLine("5. List ordered menu items for a reservation");
                Console.WriteLine("0. Back");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        await CreateMenuItem(menuItemRepository);
                        break;
                    case "2":
                        DisplayMenuItems(context.MenuItems.ToList());
                        break;
                    case "3":
                        await UpdateMenuItem(menuItemRepository);
                        break;
                    case "4":
                        await DeleteMenuItem(menuItemRepository);
                        break;
                    case "5":
                        ListOrderedMenuItems(menuItemRepository);
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static async Task CreateMenuItem(MenuItemRepository repository)
        {
            var newMenuItem = new MenuItem
            {
                RestaurantId = int.Parse(GetInput("Enter restaurant ID: ")),
                Name = GetInput("Enter menu item name: "),
                Description = GetInput("Enter menu item description: "),
                Price = int.Parse(GetInput("Enter menu item price: "))
            };

            await repository.CreateAsync(newMenuItem);
            Console.WriteLine("Menu item created successfully.");
        }

        static void DisplayMenuItems(List<MenuItem>? menuItems)
        {
            Console.WriteLine("All Menu Items:");
            DisplayEntities(menuItems);
        }

        static async Task UpdateMenuItem(MenuItemRepository repository)
        {
            var itemId = int.Parse(GetInput("Enter menu item ID to update: "));

            var updatedMenuItemData = new MenuItem
            {
                RestaurantId = int.Parse(GetInput("Enter updated restaurant ID: ")),
                Name = GetInput("Enter updated menu item name: "),
                Description = GetInput("Enter updated menu item description: "),
                Price = int.Parse(GetInput("Enter updated menu item price: "))
            };

            await repository.UpdateAsync(itemId, updatedMenuItemData);
            Console.WriteLine("Menu item updated successfully.");
        }

        static async Task DeleteMenuItem(MenuItemRepository repository)
        {
            var itemId = int.Parse(GetInput("Enter menu item ID to delete: "));
            await repository.DeleteAsync(itemId);
            Console.WriteLine("Menu item deleted successfully.");
        }

        static void ListOrderedMenuItems(MenuItemRepository repository)
        {
            var reservationId = int.Parse(GetInput("Enter reservation ID: "));
            MenuItemRepository.ListOrderedMenuItems(reservationId);
        }

        static async Task CustomerOperations()
        {
            var customerRepository = new CustomerRepository();
            using var context = new RestaurantDbContext();
            while (true)
            {
                Console.WriteLine("Customer Operations:");
                Console.WriteLine("1. Create a new customer");
                Console.WriteLine("2. Display all customers");
                Console.WriteLine("3. Update a customer");
                Console.WriteLine("4. Get customers with party size greater than");
                Console.WriteLine("5. Delete a customer");
                Console.WriteLine("0. Back");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        await CreateCustomer(customerRepository);
                        break;
                    case "2": 
                        DisplayCustomers(context.Customers.ToList());
                        break;
                    case "3":
                        await UpdateCustomer(customerRepository);
                        break;
                    case "4":
                        GetCustomersWithPartySizeGreaterThan();
                        break;
                    case "5":
                        await DeleteCustomer(customerRepository);
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static async Task EmployeeOperations()
        {
            using var context = new RestaurantDbContext();
            var employeeRepository = new EmployeeRepository();

            while (true)
            {
                Console.WriteLine("Employee Operations:");
                Console.WriteLine("1. Create a new employee");
                Console.WriteLine("2. Display all employees");
                Console.WriteLine("3. Update an employee");
                Console.WriteLine("4. Delete an employee");
                Console.WriteLine("5. List Managers");
                Console.WriteLine("0. Back");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        await CreateEmployee(employeeRepository);
                        break;
                    case "2":
                        DisplayEmployees(context.Employees.ToList());
                        break;
                    case "3":
                        await UpdateEmployee(employeeRepository);
                        break;
                    case "4":
                        await DeleteEmployee(employeeRepository);
                        break;
                    case "5":
                        EmployeeRepository.ListManagers();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static async Task CreateCustomer(CustomerRepository repository)
        {
            var newCustomer = new Customer
            {
                FirstName = GetInput("Enter first name: "),
                LastName = GetInput("Enter last name: "),
                Email = GetInput("Enter email: "),
                PhoneNumber = GetInput("Enter phone number: ")
            };

            await repository.CreateAsync(newCustomer);
            Console.WriteLine("Customer created successfully.");
        }

        static void DisplayCustomers(List<Customer>? customers)
        {
            Console.WriteLine("All Customers:");
            DisplayEntities(customers);
        }

        static async Task UpdateCustomer(CustomerRepository repository)
        {
            var customerId = int.Parse(GetInput("Enter customer ID to update: "));

            var updatedCustomerData = new Customer
            {
                FirstName = GetInput("Enter updated first name: "),
                LastName = GetInput("Enter updated last name: "),
                Email = GetInput("Enter updated email: "),
                PhoneNumber = GetInput("Enter updated phone number: ")
            };

            await repository.UpdateAsync(customerId, updatedCustomerData);
            Console.WriteLine("Customer updated successfully.");
        }

        static void GetCustomersWithPartySizeGreaterThan()
        {
            var partySize = int.Parse(GetInput("Enter party size: "));
            var customersWithPartySizeGreaterThan = CustomerRepository.GetCustomersWithPartySizeGreaterThan(partySize);

            Console.WriteLine($"Customers with party size greater than {partySize}:");
            DisplayEntities(customersWithPartySizeGreaterThan);
        }

        static async Task DeleteCustomer(CustomerRepository repository)
        {
            var customerId = int.Parse(GetInput("Enter customer ID to delete: "));
            await repository.DeleteAsync(customerId);
            Console.WriteLine("Customer deleted successfully.");
        }

        static async Task CreateEmployee(EmployeeRepository repository)
        {
            var newEmployee = new Employee
            {
                FirstName = GetInput("Enter first name: "),
                LastName = GetInput("Enter last name: "),
                Position = GetInput("Enter position: "),
                RestaurantId = int.Parse(GetInput("Restaurant ID:"))
            };

            await repository.CreateAsync(newEmployee);
            Console.WriteLine("Employee created successfully.");
        }

        static void DisplayEmployees(List<Employee>? employees)
        {
            Console.WriteLine("All Employees:");
            DisplayEntities(employees);
        }

        static async Task UpdateEmployee(EmployeeRepository repository)
        {
            var employeeId = int.Parse(GetInput("Enter employee ID to update: "));

            var updatedEmployeeData = new Employee
            {
                FirstName = GetInput("Enter updated first name: "),
                LastName = GetInput("Enter updated last name: "),
                Position = GetInput("Enter updated position: "),
                RestaurantId = int.Parse(GetInput("Restaurant ID:"))
            };

            await repository.UpdateAsync(employeeId, updatedEmployeeData);
            Console.WriteLine("Employee updated successfully.");
        }

        static async Task DeleteEmployee(EmployeeRepository repository)
        {
            var employeeId = int.Parse(GetInput("Enter employee ID to delete: "));
            await repository.DeleteAsync(employeeId);
            Console.WriteLine("Employee deleted successfully.");
        }

        static void DisplayEntities<T>(List<T>? entities)
        {
            if (entities != null && entities.Count > 0)
            {
                foreach (var entity in entities)
                {
                    Console.WriteLine(entity);
                    Console.WriteLine(Line);
                }
            }
            else
            {
                Console.WriteLine($"No {typeof(T).Name}s found.");
            }
        }

        static string GetInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }
}
