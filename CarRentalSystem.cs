using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    internal class CarRentalSystem
    {
        private List<Car> cars;
        private List<Customer> customers;
        private List<Rental> rentals;

        public CarRentalSystem()
        {
            cars = new List<Car>();
            customers = new List<Customer>();
            rentals = new List<Rental>();
        }

        public void addCar(Car car)
        {
            cars.Add(car);
        }

        public void addCustomer(Customer customer)
        {
            customers.Add(customer);
        }

        public void rentCar(Car car, Customer customer, int days)
        {
            if (car.isAval())
            {
                car.rent();
                rentals.Add(new Rental(car, customer, days));

            }
            else
            {
                Console.WriteLine("Car is not available for rent.");
            }
        }

        public void returnCar(Car car)
        {
            car.returnCar();
            Rental rentalToRemove = null;
            foreach (Rental rental in rentals)
            {
                if (rental.getCar() == car)
                {
                    rentalToRemove = rental;
                    break;
                }
            }
            if (rentalToRemove != null)
            {
                rentals.Remove(rentalToRemove);

            }
            else
            {
                Console.WriteLine("Car was not rented.");
            }
        }

        public void menu()
        {


            while (true)
            {
                Console.WriteLine("===== Car Rental System =====");
                Console.WriteLine("1. Rent a Car");
                Console.WriteLine("2. Return a Car");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                if (choice == 1)
                {
                    Console.WriteLine("\n== Rent a Car ==\n");
                    Console.Write("Enter your name: ");
                    String customerName = Console.ReadLine();

                    Console.WriteLine("\nAvailable Cars:");
                    foreach (Car car in cars)
                    {
                        if (car.isAval())
                        {
                            Console.WriteLine(car.getCarId() + " - " + car.getBrand() + " " + car.getModel());
                        }
                    }

                    Console.Write("\nEnter the car ID you want to rent: ");
                    String carId = Console.ReadLine();

                    Console.Write("Enter the number of days for rental: ");
                    int rentalDays = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine() ;

                    Customer newCustomer = new Customer("CUS" + (customers.Count() + 1), customerName);
                    addCustomer(newCustomer);

                    Car selectedCar = null;
                    foreach (Car car in cars)
                    {
                        if (car.getCarId().Equals(carId) && car.isAval())
                        {
                            selectedCar = car;
                            break;
                        }
                    }

                    if (selectedCar != null)
                    {
                        double totalPrice = selectedCar.calculatePrice(rentalDays);
                        Console.WriteLine(totalPrice);
                        Console.WriteLine("\n== Rental Information ==\n");
                        Console.WriteLine("Customer ID: " + newCustomer.getCustomerId());
                        Console.WriteLine("Customer Name: " + newCustomer.getName());
                        Console.WriteLine("Car: " + selectedCar.getBrand() + " " + selectedCar.getModel());
                        Console.WriteLine("Rental Days: " + rentalDays);
                        Console.Write($"Total Price: {totalPrice}");

                        Console.Write("\nConfirm rental (Y/N): ");
                        String confirm = Console.ReadLine();

                        if (confirm=="Y")
                        {
                            rentCar(selectedCar, newCustomer, rentalDays);
                            Console.WriteLine("\nCar rented successfully.");
                        }
                        else
                        {
                            Console.WriteLine("\nRental canceled.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid car selection or car not available for rent.");
                    }
                }
                else if (choice == 2)
                {
                    Console.WriteLine("\n== Return a Car ==\n");
                    Console.Write("Enter the car ID you want to return: ");
                    String carId = Console.ReadLine();

                    Car carToReturn = null;
                    foreach (Car car in cars)
                    {
                        if (car.getCarId().Equals(carId) && !car.isAval())
                        {
                            carToReturn = car;
                            break;
                        }
                    }

                    if (carToReturn != null)
                    {
                        Customer customer = null;
                        foreach (Rental rental in rentals)
                        {
                            if (rental.getCar() == carToReturn)
                            {
                                customer = rental.getCustomer();
                                break;
                            }
                        }

                        if (customer != null)
                        {
                            returnCar(carToReturn);
                            Console.WriteLine("Car returned successfully by " + customer.getName());
                        }
                        else
                        {
                            Console.WriteLine("Car was not rented or rental information is missing.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid car ID or car is not rented.");
                    }
                }
                else if (choice == 3)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please enter a valid option.");
                }
            }

            Console.WriteLine("\nThank you for using the Car Rental System!");
        }
    }
}
