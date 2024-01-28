using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    internal class Car
    {
        private String carId;
        private String brand;
        private String model;
        private double basePricePerDay;
        private bool isAvailable;

        public Car(String carId, String brand, String model, double basePricePerDay)
        {
            this.carId = carId;
            this.brand = brand;
            this.model = model;
            this.basePricePerDay = basePricePerDay;
            this.isAvailable = true;

        }
        public String getCarId()
        {
            return carId;
        }

        public String getBrand()
        {
            return brand;
        }

        public String getModel()
        {
            return model;
        }

        public double calculatePrice(int rentalDays)
        {
            //Console.WriteLine(basePricePerDay * rentalDays);
            double amount = basePricePerDay * rentalDays;
            return amount;
        }

        public bool isAval()
        {
            return isAvailable;
        }

        public void rent()
        {
            isAvailable = false;
        }

        public void returnCar()
        {
            isAvailable = true;
        }
    }
}
