using RestaurantReservation.Db;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation
{
    class Program
    {
        const string Line = "---------------";

        static void Main(string[] args)
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
                        CustomerOperations();
                        break;
                    case "2":
                        EmployeeOperations();
                        break;
                    case "3":
                        MenuItemOperations();
                        break;
                    case "4":
                        OrderItemOperations();
                        break;
                    case "5":
                        OrderOperations();
                        break;
                    case "6":
                        ReservationOperations();
                        break;
                    case "7":
                        RestaurantOperations();
                        break;
                    case "8":
                        TableOperations();
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

        static void TableOperations()
        {
            var tableRepository = new TableRepository();
            var context = new RestaurantDbContext();
            
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
                        CreateTable(tableRepository);
                        break;
                    case "2":
                        DisplayTables(context.Tables.ToList());
                        break;
                    case "3":
                        UpdateTable(tableRepository);
                        break;
                    case "4":
                        DeleteTable(tableRepository);
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void CreateTable(TableRepository repository)
        {
            var newTable = new Table
            {
                RestaurantId = int.Parse(GetInput("Enter restaurant ID: ")),
                Capacity = int.Parse(GetInput("Enter table capacity: "))
            };

            repository.Create(newTable);
            Console.WriteLine("Table created successfully.");
        }

        static void DisplayTables(List<Table>? tables)
        {
            Console.WriteLine("All Tables:");
            DisplayEntities(tables);
        }

        static void UpdateTable(TableRepository repository)
        {
            var tableId = int.Parse(GetInput("Enter table ID to update: "));

            var updatedTableData = new Table
            {
                RestaurantId = int.Parse(GetInput("Enter updated restaurant ID: ")),
                Capacity = int.Parse(GetInput("Enter updated table capacity: "))
            };

            repository.Update(tableId, updatedTableData);
            Console.WriteLine("Table updated successfully.");
        }

        static void DeleteTable(TableRepository repository)
        {
            var tableId = int.Parse(GetInput("Enter table ID to delete: "));
            repository.Delete(tableId);
            Console.WriteLine("Table deleted successfully.");
        }
        
        static void RestaurantOperations()
        {
            var restaurantRepository = new RestaurantRepository();
            var context = new RestaurantDbContext();
            
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
                        CreateRestaurant(restaurantRepository);
                        break;
                    case "2":
                        DisplayRestaurants(context.Restaurants.ToList());
                        break;
                    case "3":
                        UpdateRestaurant(restaurantRepository);
                        break;
                    case "4":
                        DeleteRestaurant(restaurantRepository);
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

        static void CreateRestaurant(RestaurantRepository repository)
        {
            var newRestaurant = new Restaurant
            {
                Name = GetInput("Enter restaurant name: "),
                Address = GetInput("Enter restaurant address: "),
                PhoneNumber = GetInput("Enter restaurant phone number: "),
                OpeningHours = GetInput("Enter restaurant opening hours: ")
            };

            repository.Create(newRestaurant);
            Console.WriteLine("Restaurant created successfully.");
        }

        static void DisplayRestaurants(List<Restaurant>? restaurants)
        {
            Console.WriteLine("All Restaurants:");
            DisplayEntities(restaurants);
        }

        static void UpdateRestaurant(RestaurantRepository repository)
        {
            var restaurantId = int.Parse(GetInput("Enter restaurant ID to update: "));

            var updatedRestaurantData = new Restaurant
            {
                Name = GetInput("Enter updated restaurant name: "),
                Address = GetInput("Enter updated restaurant address: "),
                PhoneNumber = GetInput("Enter updated restaurant phone number: "),
                OpeningHours = GetInput("Enter updated restaurant opening hours: ")
            };

            repository.Update(restaurantId, updatedRestaurantData);
            Console.WriteLine("Restaurant updated successfully.");
        }

        static void DeleteRestaurant(RestaurantRepository repository)
        {
            var restaurantId = int.Parse(GetInput("Enter restaurant ID to delete: "));
            repository.Delete(restaurantId);
            Console.WriteLine("Restaurant deleted successfully.");
        }

        static void GetRestaurantRevenue(RestaurantRepository repository)
        {
            var restaurantId = int.Parse(GetInput("Enter restaurant ID: "));
            var restaurantRevenue = RestaurantRepository.GetRestaurantRevenue(restaurantId);
            Console.WriteLine($"Restaurant {restaurantId} Revenue: {restaurantRevenue?.Revenue ?? 0}$");
        }
        
        static void ReservationOperations()
        {
            var reservationRepository = new ReservationRepository();
            var context = new RestaurantDbContext();
            
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
                        CreateReservation(reservationRepository);
                        break;
                    case "2":
                        DisplayReservations(context.Reservations.ToList());
                        break;
                    case "3":
                        UpdateReservation(reservationRepository);
                        break;
                    case "4":
                        DeleteReservation(reservationRepository);
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

        static void CreateReservation(ReservationRepository repository)
        {
            var newReservation = new Reservation
            {
                CustomerId = int.Parse(GetInput("Enter customer ID: ")),
                RestaurantId = int.Parse(GetInput("Enter restaurant ID:")),
                TableId = int.Parse(GetInput("Enter table ID: ")),
                ReservationDate = DateTime.Parse(GetInput("Enter reservation date (yyyy-MM-dd HH:mm:ss): ")),
                PartySize = int.Parse(GetInput("Enter party size: "))
            };

            repository.Create(newReservation);
            Console.WriteLine("Reservation created successfully.");
        }

        static void DisplayReservations(List<Reservation>? reservations)
        {
            Console.WriteLine("All Reservations:");
            DisplayEntities(reservations);
        }

        static void UpdateReservation(ReservationRepository repository)
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

            repository.Update(reservationId, updatedReservationData);
            Console.WriteLine("Reservation updated successfully.");
        }

        static void DeleteReservation(ReservationRepository repository)
        {
            var reservationId = int.Parse(GetInput("Enter reservation ID to delete: "));
            repository.Delete(reservationId);
            Console.WriteLine("Reservation deleted successfully.");
        }

        static void GetReservationsByCustomer(ReservationRepository repository)
        {
            var customerId = int.Parse(GetInput("Enter customer ID: "));
            ReservationRepository.GetReservationsByCustomer(customerId);
        }
        
        static void OrderOperations()
        {
            var orderRepository = new OrderRepository();
            var context = new RestaurantDbContext();

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
                        CreateOrder(orderRepository);
                        break;
                    case "2":
                        DisplayOrders(context.Orders.ToList());
                        break;
                    case "3":
                        UpdateOrder(orderRepository);
                        break;
                    case "4":
                        DeleteOrder(orderRepository);
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

        static void CreateOrder(OrderRepository repository)
        {
            var newOrder = new Order
            {
                ReservationId = int.Parse(GetInput("Enter reservation ID: ")),
                EmployeeId = int.Parse(GetInput("Enter employee ID:")),
                OrderDate = DateTime.Parse(GetInput("Enter order date (yyyy-MM-dd HH:mm:ss): ")),
                TotalAmount = int.Parse(GetInput("Enter total amount: "))
            };

            repository.Create(newOrder);
            Console.WriteLine("Order created successfully.");
        }

        static void DisplayOrders(List<Order>? orders)
        {
            Console.WriteLine("All Orders:");
            DisplayEntities(orders);
        }

        static void UpdateOrder(OrderRepository repository)
        {
            var orderId = int.Parse(GetInput("Enter order ID to update: "));

            var updatedOrderData = new Order
            {
                ReservationId = int.Parse(GetInput("Enter updated reservation ID: ")),
                EmployeeId = int.Parse(GetInput("Enter updated employee ID:")),
                OrderDate = DateTime.Parse(GetInput("Enter updated order date (yyyy-MM-dd HH:mm:ss): ")),
                TotalAmount = int.Parse(GetInput("Enter updated total amount: "))
            };

            repository.Update(orderId, updatedOrderData);
            Console.WriteLine("Order updated successfully.");
        }

        static void DeleteOrder(OrderRepository repository)
        {
            var orderId = int.Parse(GetInput("Enter order ID to delete: "));
            repository.Delete(orderId);
            Console.WriteLine("Order deleted successfully.");
        }

        static void CalculateAverageOrderAmount(OrderRepository repository)
        {
            var employeeId = int.Parse(GetInput("Enter employee ID: "));
            OrderRepository.CalculateAverageOrderAmount(employeeId);
        }


        static void OrderItemOperations()
        {
            var orderItemRepository = new OrderItemRepository();
            var context = new RestaurantDbContext();
            
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
                        CreateOrderItem(orderItemRepository);
                        break;
                    case "2":
                        DisplayOrderItems(context.OrderItems.ToList());
                        break;
                    case "3":
                        UpdateOrderItem(orderItemRepository);
                        break;
                    case "4":
                        DeleteOrderItem(orderItemRepository);
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
        
        static void CreateOrderItem(OrderItemRepository repository)
        {
            var newOrderItem = new OrderItem
            {
                OrderId = int.Parse(GetInput("Enter order ID: ")),
                MenuItemId = int.Parse(GetInput("Enter menu item ID:")),
                Quantity = int.Parse(GetInput("Enter quantity: "))
            };

            repository.Create(newOrderItem);
            Console.WriteLine("Order item created successfully.");
        }

        static void DisplayOrderItems(List<OrderItem>? orderItems)
        {
            Console.WriteLine("All Order Items:");
            DisplayEntities(orderItems);
        }

        static void UpdateOrderItem(OrderItemRepository repository)
        {
            var orderItemId = int.Parse(GetInput("Enter order item ID to update: "));

            var updatedOrderItemData = new OrderItem
            {
                OrderId = int.Parse(GetInput("Enter updated order ID: ")),
                MenuItemId = int.Parse(GetInput("Enter updated menu item ID:")),
                Quantity = int.Parse(GetInput("Enter updated quantity: "))
            };

            repository.Update(orderItemId, updatedOrderItemData);
            Console.WriteLine("Order item updated successfully.");
        }

        static void DeleteOrderItem(OrderItemRepository repository)
        {
            var orderItemId = int.Parse(GetInput("Enter order item ID to delete: "));
            repository.Delete(orderItemId);
            Console.WriteLine("Order item deleted successfully.");
        }

        static void ListOrdersAndMenuItems(OrderItemRepository repository)
        {
            var reservationId = int.Parse(GetInput("Enter reservation ID: "));
            OrderItemRepository.ListOrdersAndMenuItems(reservationId);
        }
        static void MenuItemOperations()
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
                        CreateMenuItem(menuItemRepository);
                        break;
                    case "2":
                        DisplayMenuItems(context.MenuItems.ToList());
                        break;
                    case "3":
                        UpdateMenuItem(menuItemRepository);
                        break;
                    case "4":
                        DeleteMenuItem(menuItemRepository);
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

        static void CreateMenuItem(MenuItemRepository repository)
        {
            var newMenuItem = new MenuItem
            {
                RestaurantId = int.Parse(GetInput("Enter restaurant ID: ")),
                Name = GetInput("Enter menu item name: "),
                Description = GetInput("Enter menu item description: "),
                Price = int.Parse(GetInput("Enter menu item price: "))
            };

            repository.Create(newMenuItem);
            Console.WriteLine("Menu item created successfully.");
        }

        static void DisplayMenuItems(List<MenuItem>? menuItems)
        {
            Console.WriteLine("All Menu Items:");
            DisplayEntities(menuItems);
        }

        static void UpdateMenuItem(MenuItemRepository repository)
        {
            var itemId = int.Parse(GetInput("Enter menu item ID to update: "));

            var updatedMenuItemData = new MenuItem
            {
                RestaurantId = int.Parse(GetInput("Enter updated restaurant ID: ")),
                Name = GetInput("Enter updated menu item name: "),
                Description = GetInput("Enter updated menu item description: "),
                Price = int.Parse(GetInput("Enter updated menu item price: "))
            };

            repository.Update(itemId, updatedMenuItemData);
            Console.WriteLine("Menu item updated successfully.");
        }

        static void DeleteMenuItem(MenuItemRepository repository)
        {
            var itemId = int.Parse(GetInput("Enter menu item ID to delete: "));
            repository.Delete(itemId);
            Console.WriteLine("Menu item deleted successfully.");
        }

        static void ListOrderedMenuItems(MenuItemRepository repository)
        {
            var reservationId = int.Parse(GetInput("Enter reservation ID: "));
            MenuItemRepository.ListOrderedMenuItems(reservationId);
        }

        static void CustomerOperations()
        {
            var customerRepository = new CustomerRepository();
            var context = new RestaurantDbContext();
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
                        CreateCustomer(customerRepository);
                        break;
                    case "2":
                        DisplayCustomers(context.Customers.ToList());
                        break;
                    case "3":
                        UpdateCustomer(customerRepository);
                        break;
                    case "4":
                        GetCustomersWithPartySizeGreaterThan(customerRepository);
                        break;
                    case "5":
                        DeleteCustomer(customerRepository);
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void EmployeeOperations()
        {
            var context = new RestaurantDbContext();
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
                        CreateEmployee(employeeRepository);
                        break;
                    case "2":
                        DisplayEmployees(context.Employees.ToList());
                        break;
                    case "3":
                        UpdateEmployee(employeeRepository);
                        break;
                    case "4":
                        DeleteEmployee(employeeRepository);
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

        static void CreateCustomer(CustomerRepository repository)
        {
            var newCustomer = new Customer
            {
                FirstName = GetInput("Enter first name: "),
                LastName = GetInput("Enter last name: "),
                Email = GetInput("Enter email: "),
                PhoneNumber = GetInput("Enter phone number: ")
            };

            repository.Create(newCustomer);
            Console.WriteLine("Customer created successfully.");
        }

        static void DisplayCustomers(List<Customer>? customers)
        {
            Console.WriteLine("All Customers:");
            DisplayEntities(customers);
        }

        static void UpdateCustomer(CustomerRepository repository)
        {
            var customerId = int.Parse(GetInput("Enter customer ID to update: "));

            var updatedCustomerData = new Customer
            {
                FirstName = GetInput("Enter updated first name: "),
                LastName = GetInput("Enter updated last name: "),
                Email = GetInput("Enter updated email: "),
                PhoneNumber = GetInput("Enter updated phone number: ")
            };

            repository.Update(customerId, updatedCustomerData);
            Console.WriteLine("Customer updated successfully.");
        }

        static void GetCustomersWithPartySizeGreaterThan(CustomerRepository repository)
        {
            var partySize = int.Parse(GetInput("Enter party size: "));
            var customersWithPartySizeGreaterThan = CustomerRepository.GetCustomersWithPartySizeGreaterThan(partySize);

            Console.WriteLine($"Customers with party size greater than {partySize}:");
            DisplayEntities(customersWithPartySizeGreaterThan);
        }

        static void DeleteCustomer(CustomerRepository repository)
        {
            var customerId = int.Parse(GetInput("Enter customer ID to delete: "));
            repository.Delete(customerId);
            Console.WriteLine("Customer deleted successfully.");
        }

        static void CreateEmployee(EmployeeRepository repository)
        {
            var newEmployee = new Employee
            {
                FirstName = GetInput("Enter first name: "),
                LastName = GetInput("Enter last name: "),
                Position = GetInput("Enter position: "),
                RestaurantId = int.Parse(GetInput("Restaurant ID:"))
            };

            repository.Create(newEmployee);
            Console.WriteLine("Employee created successfully.");
        }

        static void DisplayEmployees(List<Employee>? employees)
        {
            Console.WriteLine("All Employees:");
            DisplayEntities(employees);
        }

        static void UpdateEmployee(EmployeeRepository repository)
        {
            var employeeId = int.Parse(GetInput("Enter employee ID to update: "));

            var updatedEmployeeData = new Employee
            {
                FirstName = GetInput("Enter updated first name: "),
                LastName = GetInput("Enter updated last name: "),
                Position = GetInput("Enter updated position: "),
                RestaurantId = int.Parse(GetInput("Restaurant ID:"))
            };

            repository.Update(employeeId, updatedEmployeeData);
            Console.WriteLine("Employee updated successfully.");
        }

        static void DeleteEmployee(EmployeeRepository repository)
        {
            var employeeId = int.Parse(GetInput("Enter employee ID to delete: "));
            repository.Delete(employeeId);
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
