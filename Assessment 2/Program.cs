using System;


namespace Assessment_2
{
    //----------------------------------VEHICLE-------------------------------------

    class Vehicle 
    {
        public int rego;
        public string make;
        public string model;
        public int totalKm;
        Driver theDriver;
        public Vehicle(int rego, string make, string model, int totalKm, Driver theDriver)
        {
            this.rego = rego;
            this.make = make;
            this.model = model;
            this.totalKm = totalKm;
            this.theDriver = theDriver; 
        }

        public void UpDateKm(int newkm)
        {           
            if (newkm < 0)
            {
                Console.WriteLine("Kilometers value warning".ToUpper());
                Console.WriteLine("ERROR, enter valid value for Km");
            }
            else if (newkm >= 0)
            {
                totalKm = newkm + totalKm;
            }
        }
      
        public void PrintVehicle()
        {
            Console.WriteLine("Additional details: ");
            Console.WriteLine("Rego is: " + rego + "." + " Make is: " + make + "." + " Model is: " + model + "." + " Km's are: " + totalKm + "km.");
        }

    }

    //----------------------------------CAR-------------------------------------

    class Car : Vehicle
    {
        public string bodyType;
        public string colour;
        public string upholstery;
        public int doors;
        public Car(string bodyType, string colour, string upholstery, int doors, int rego, string make, string model, int totalKm, Driver theDriver)
            : base(rego, make, model, totalKm, theDriver)
        {
            this.bodyType = bodyType;
            this.colour = colour;
            this.upholstery = upholstery;
            this.doors = doors;
        }

        public void ChangeColor(string newColor)
        {
            colour = newColor;
        }

        public void PrintCar()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Car details: ");
            Console.WriteLine("Body type: " + bodyType + ", colour: " + colour + ", The upholstery: " + upholstery + ", Doors number: " + doors);
        }
        
    }

    //-----------------------------TRUCK-------------------------------------------

    class Truck : Vehicle
    {
        public int load;
        public int axles;
        public int wheels;
        public Truck(int load, int axles, int wheels, int rego, string make, string model, int totalKm, Driver theDriver)
            : base(rego, make, model, totalKm, theDriver)
        {
            this.load = load;
            this.axles = axles;
            this.wheels = wheels;
        }


        public void PrintTruck()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Truck details: ");
            Console.WriteLine("Maximun load: " + load + " Number of axles: " + axles + " Number of wheels: " + wheels);
        }
    }

   
    //-------------------------------------------------------------------------
    //-----------------------------PROGRAM--------------------------------------
    //--------------------------------------------------------------------------


    class Program
    {
        static void Main(string[] args)
        {
            string[] address1 = { "Street: 24 Lincoln Road", "City : Melbourne", "State : Victoria ", "Postcode : 3040" };
            string[] states1 = { "Qld :"," Vic :", " NSW", };
            Driver driver1 = new Driver(58946, "Jack", "Sparrow", 058423645, states1, address1, 5);
            driver1.AddDemeritPoints(0);
            driver1.PrintDriver();

            Console.WriteLine(" "); //Write and read the driver file
            Console.WriteLine("Checking driver file".ToUpper());
            driver1.DriverFile();

            Car car1 = new Car("sedan", "red", "plastic", 4, 978564, "Ford", "Mustang", 2300, driver1);
            car1.UpDateKm(500);
            car1.ChangeColor("blue");
            car1.PrintCar();
            car1.PrintVehicle();

            Truck truck1 = new Truck(200, 5, 6, 878969, "Mercedes", "Diesel", 1500, driver1);
            truck1.PrintTruck();
            truck1.PrintVehicle();

            Console.WriteLine(" ");
            Console.WriteLine("==========================================");
            Console.WriteLine("Another Driver".ToUpper());
            Console.WriteLine("==========================================");

            string[] address2 = { "Street: 15 Sydney road", "City: Melbourne", "State: Victoria", "Postcode: 2740" };
            string[] states2 = { "SA :", " VIC :" };
            Driver driver2 = new Driver(258963, "Pedro", "Valdez", 0426897456, states2, address2, 5);
            driver2.AddDemeritPoints(2);
            driver2.PrintDriver();

            Car car2 = new Car("Suv", "black", "leather", 4, 426789, "Toyota", "RAV4", 1050, driver2);
            car2.UpDateKm(300);
            car2.ChangeColor("green");
            car2.PrintCar();
            car2.PrintVehicle();

            Truck truck2 = new Truck(185, 5, 6, 123456, "Mercedes", "The Actros", 23465, driver2);
            truck2.UpDateKm(-50);
            truck2.PrintTruck();
            truck2.PrintVehicle();



        }
    }
}
