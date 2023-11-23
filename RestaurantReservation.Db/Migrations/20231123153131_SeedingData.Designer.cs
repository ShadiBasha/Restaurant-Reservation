﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestaurantReservationDbContext;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    [DbContext(typeof(RestaurantDbContext))]
    [Migration("20231123153131_SeedingData")]
    partial class SeedingData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RestaurantReservation.Db.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerId = 1,
                            Email = "alice.smith@example.com",
                            FirstName = "Alice",
                            LastName = "Smith",
                            PhoneNumber = "111-222-3333"
                        },
                        new
                        {
                            CustomerId = 2,
                            Email = "bob.johnson@example.com",
                            FirstName = "Bob",
                            LastName = "Johnson",
                            PhoneNumber = "444-555-6666"
                        },
                        new
                        {
                            CustomerId = 3,
                            Email = "charlie.brown@example.com",
                            FirstName = "Charlie",
                            LastName = "Brown",
                            PhoneNumber = "777-888-9999"
                        },
                        new
                        {
                            CustomerId = 4,
                            Email = "david.miller@example.com",
                            FirstName = "David",
                            LastName = "Miller",
                            PhoneNumber = "123-456-7890"
                        },
                        new
                        {
                            CustomerId = 5,
                            Email = "eva.davis@example.com",
                            FirstName = "Eva",
                            LastName = "Davis",
                            PhoneNumber = "555-666-7777"
                        });
                });

            modelBuilder.Entity("RestaurantReservation.Db.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmployeeId = 1,
                            FirstName = "Emily",
                            LastName = "Johnson",
                            Position = "Chef",
                            RestaurantId = 1
                        },
                        new
                        {
                            EmployeeId = 2,
                            FirstName = "Alex",
                            LastName = "Williams",
                            Position = "Waiter",
                            RestaurantId = 2
                        },
                        new
                        {
                            EmployeeId = 3,
                            FirstName = "Daniel",
                            LastName = "Brown",
                            Position = "Manager",
                            RestaurantId = 3
                        },
                        new
                        {
                            EmployeeId = 4,
                            FirstName = "Olivia",
                            LastName = "Jones",
                            Position = "Cook",
                            RestaurantId = 4
                        },
                        new
                        {
                            EmployeeId = 5,
                            FirstName = "Liam",
                            LastName = "Smith",
                            Position = "Waitress",
                            RestaurantId = 5
                        });
                });

            modelBuilder.Entity("RestaurantReservation.Db.MenuItem", b =>
                {
                    b.Property<int>("MenuItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MenuItemId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.HasKey("MenuItemId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("MenuItems");

                    b.HasData(
                        new
                        {
                            MenuItemId = 1,
                            Description = "Creamy Alfredo sauce with grilled chicken and fettuccine pasta",
                            Name = "Chicken Alfredo",
                            Price = 15,
                            RestaurantId = 1
                        },
                        new
                        {
                            MenuItemId = 2,
                            Description = "Tofu and mixed vegetables stir-fried in a spicy sauce",
                            Name = "Spicy Tofu Stir-Fry",
                            Price = 12,
                            RestaurantId = 2
                        },
                        new
                        {
                            MenuItemId = 3,
                            Description = "Assorted slices of fresh sashimi with soy sauce",
                            Name = "Sashimi Platter",
                            Price = 20,
                            RestaurantId = 3
                        },
                        new
                        {
                            MenuItemId = 4,
                            Description = "Classic pizza with tomato sauce, mozzarella, and pepperoni",
                            Name = "Pepperoni Pizza",
                            Price = 18,
                            RestaurantId = 4
                        },
                        new
                        {
                            MenuItemId = 5,
                            Description = "Strong black coffee made by forcing hot water through finely-ground coffee beans",
                            Name = "Espresso",
                            Price = 3,
                            RestaurantId = 5
                        });
                });

            modelBuilder.Entity("RestaurantReservation.Db.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ReservationId")
                        .HasColumnType("int");

                    b.Property<int>("TotalAmount")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ReservationId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            OrderId = 1,
                            EmployeeId = 1,
                            OrderDate = new DateTime(2023, 11, 23, 19, 31, 31, 413, DateTimeKind.Local).AddTicks(5762),
                            ReservationId = 1,
                            TotalAmount = 40
                        },
                        new
                        {
                            OrderId = 2,
                            EmployeeId = 2,
                            OrderDate = new DateTime(2023, 11, 23, 18, 31, 31, 413, DateTimeKind.Local).AddTicks(5766),
                            ReservationId = 2,
                            TotalAmount = 60
                        },
                        new
                        {
                            OrderId = 3,
                            EmployeeId = 3,
                            OrderDate = new DateTime(2023, 11, 23, 20, 31, 31, 413, DateTimeKind.Local).AddTicks(5769),
                            ReservationId = 3,
                            TotalAmount = 80
                        },
                        new
                        {
                            OrderId = 4,
                            EmployeeId = 4,
                            OrderDate = new DateTime(2023, 11, 23, 22, 31, 31, 413, DateTimeKind.Local).AddTicks(5772),
                            ReservationId = 4,
                            TotalAmount = 25
                        },
                        new
                        {
                            OrderId = 5,
                            EmployeeId = 5,
                            OrderDate = new DateTime(2023, 11, 23, 21, 31, 31, 413, DateTimeKind.Local).AddTicks(5775),
                            ReservationId = 5,
                            TotalAmount = 35
                        });
                });

            modelBuilder.Entity("RestaurantReservation.Db.OrderItem", b =>
                {
                    b.Property<int>("OrderItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderItemId"));

                    b.Property<int>("MenuItemId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderItemId");

                    b.HasIndex("MenuItemId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems");

                    b.HasData(
                        new
                        {
                            OrderItemId = 1,
                            MenuItemId = 1,
                            OrderId = 1,
                            Quantity = 2
                        },
                        new
                        {
                            OrderItemId = 2,
                            MenuItemId = 2,
                            OrderId = 2,
                            Quantity = 3
                        },
                        new
                        {
                            OrderItemId = 3,
                            MenuItemId = 3,
                            OrderId = 3,
                            Quantity = 1
                        },
                        new
                        {
                            OrderItemId = 4,
                            MenuItemId = 4,
                            OrderId = 4,
                            Quantity = 4
                        },
                        new
                        {
                            OrderItemId = 5,
                            MenuItemId = 5,
                            OrderId = 5,
                            Quantity = 2
                        });
                });

            modelBuilder.Entity("RestaurantReservation.Db.Reservation", b =>
                {
                    b.Property<int>("ReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReservationId"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("PartySize")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReservationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.Property<int>("TableId")
                        .HasColumnType("int");

                    b.HasKey("ReservationId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("RestaurantId");

                    b.HasIndex("TableId");

                    b.ToTable("Reservations");

                    b.HasData(
                        new
                        {
                            ReservationId = 1,
                            CustomerId = 1,
                            PartySize = 3,
                            ReservationDate = new DateTime(2023, 11, 25, 17, 31, 31, 413, DateTimeKind.Local).AddTicks(5691),
                            RestaurantId = 1,
                            TableId = 1
                        },
                        new
                        {
                            ReservationId = 2,
                            CustomerId = 2,
                            PartySize = 5,
                            ReservationDate = new DateTime(2023, 11, 24, 17, 31, 31, 413, DateTimeKind.Local).AddTicks(5747),
                            RestaurantId = 2,
                            TableId = 2
                        },
                        new
                        {
                            ReservationId = 3,
                            CustomerId = 3,
                            PartySize = 7,
                            ReservationDate = new DateTime(2023, 11, 26, 17, 31, 31, 413, DateTimeKind.Local).AddTicks(5751),
                            RestaurantId = 3,
                            TableId = 3
                        },
                        new
                        {
                            ReservationId = 4,
                            CustomerId = 4,
                            PartySize = 2,
                            ReservationDate = new DateTime(2023, 11, 28, 17, 31, 31, 413, DateTimeKind.Local).AddTicks(5755),
                            RestaurantId = 4,
                            TableId = 4
                        },
                        new
                        {
                            ReservationId = 5,
                            CustomerId = 5,
                            PartySize = 4,
                            ReservationDate = new DateTime(2023, 11, 27, 17, 31, 31, 413, DateTimeKind.Local).AddTicks(5758),
                            RestaurantId = 5,
                            TableId = 5
                        });
                });

            modelBuilder.Entity("RestaurantReservation.Db.Restaurant", b =>
                {
                    b.Property<int>("RestaurantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RestaurantId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OpeningHours")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RestaurantId");

                    b.ToTable("Restaurants");

                    b.HasData(
                        new
                        {
                            RestaurantId = 1,
                            Address = "123 Main St, Cityville",
                            Name = "Tasty Bites",
                            OpeningHours = "Mon-Sat: 10 AM - 9 PM, Sun: 12 PM - 8 PM",
                            PhoneNumber = "111-222-3333"
                        },
                        new
                        {
                            RestaurantId = 2,
                            Address = "456 Oak St, Townsville",
                            Name = "Spice World",
                            OpeningHours = "Mon-Fri: 11 AM - 8 PM, Sat-Sun: 12 PM - 7 PM",
                            PhoneNumber = "444-555-6666"
                        },
                        new
                        {
                            RestaurantId = 3,
                            Address = "789 Pine St, Villageton",
                            Name = "Sushi Delight",
                            OpeningHours = "Tue-Sun: 5 PM - 10 PM",
                            PhoneNumber = "777-888-9999"
                        },
                        new
                        {
                            RestaurantId = 4,
                            Address = "101 Cedar St, Hamletville",
                            Name = "Pizza Palace",
                            OpeningHours = "Mon-Sun: 11 AM - 11 PM",
                            PhoneNumber = "123-456-7890"
                        },
                        new
                        {
                            RestaurantId = 5,
                            Address = "202 Elm St, Riverside",
                            Name = "Café Royale",
                            OpeningHours = "Mon-Sat: 8 AM - 6 PM",
                            PhoneNumber = "555-666-7777"
                        });
                });

            modelBuilder.Entity("RestaurantReservation.Db.Table", b =>
                {
                    b.Property<int>("TableId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TableId"));

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.HasKey("TableId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Tables");

                    b.HasData(
                        new
                        {
                            TableId = 1,
                            Capacity = 4,
                            RestaurantId = 1
                        },
                        new
                        {
                            TableId = 2,
                            Capacity = 6,
                            RestaurantId = 2
                        },
                        new
                        {
                            TableId = 3,
                            Capacity = 8,
                            RestaurantId = 3
                        },
                        new
                        {
                            TableId = 4,
                            Capacity = 2,
                            RestaurantId = 4
                        },
                        new
                        {
                            TableId = 5,
                            Capacity = 4,
                            RestaurantId = 5
                        });
                });

            modelBuilder.Entity("RestaurantReservation.Db.Employee", b =>
                {
                    b.HasOne("RestaurantReservation.Db.Restaurant", "Restaurant")
                        .WithMany("Employees")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("RestaurantReservation.Db.MenuItem", b =>
                {
                    b.HasOne("RestaurantReservation.Db.Restaurant", "Restaurant")
                        .WithMany("MenuItems")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Order", b =>
                {
                    b.HasOne("RestaurantReservation.Db.Employee", "Employee")
                        .WithMany("Orders")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestaurantReservation.Db.Reservation", "Reservation")
                        .WithMany("Orders")
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("RestaurantReservation.Db.OrderItem", b =>
                {
                    b.HasOne("RestaurantReservation.Db.MenuItem", "MenuItem")
                        .WithMany("OrderItems")
                        .HasForeignKey("MenuItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestaurantReservation.Db.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MenuItem");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Reservation", b =>
                {
                    b.HasOne("RestaurantReservation.Db.Customer", "Customer")
                        .WithMany("Reservations")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestaurantReservation.Db.Restaurant", "Restaurant")
                        .WithMany("Reservations")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestaurantReservation.Db.Table", "Table")
                        .WithMany("Reservations")
                        .HasForeignKey("TableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Restaurant");

                    b.Navigation("Table");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Table", b =>
                {
                    b.HasOne("RestaurantReservation.Db.Restaurant", "Restaurant")
                        .WithMany("Tables")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Customer", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Employee", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("RestaurantReservation.Db.MenuItem", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Reservation", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Restaurant", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("MenuItems");

                    b.Navigation("Reservations");

                    b.Navigation("Tables");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Table", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
