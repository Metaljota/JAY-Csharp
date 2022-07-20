using System;
//"Trucking Australia" app
//Code Authors: Jay Sierra
//Date: 19 July 2022

//This code is use to record details of Drivers, Cars and Trucks from Trucking Australia company.
//Functionality overview: Cars and truck kilometers can be update. Demerit points can also be update. 

namespace Assessment_2
{
    //----------------------------------VEHICLE-------------------------------------

    class Vehicle 
    {
        protected int rego;
        private string make;
        private string model;
        private int totalKm;
        public Driver theDriver;
        public Vehicle(int rego, string make, string model, int totalKm, Driver theDriver)
        {
            this.rego = rego;
            this.make = make;
            this.model = model;
            this.totalKm = totalKm;
            this.theDriver = theDriver; 
        }

        public void UpDateKm(int newkm) //Method use to add kilometres to the vehicles. 
        {           
            if (newkm < 0)
            {
                totalKm = totalKm + newkm;

                if (totalKm < 0) //If km goes bellow cero the totalkm stay intact 
                {
                    totalKm = totalKm - newkm;
                    Console.WriteLine("-------------------------------------------- ");
                    Console.WriteLine("Kilometers value warning".ToUpper());
                    Console.WriteLine("ERROR, Km value cannot go below zero");
                    Console.WriteLine("-------------------------------------------- ");
                }
            }

            else if (newkm >= 0)
            {
                totalKm = newkm + totalKm;
            }
        }
      
        public virtual void PrintVehicleAll() 
        {
            Console.WriteLine("Vehicle general details: ");
            Console.WriteLine("Rego is: " + rego + "." + " Make is: " + make + "." + " Model is: " + model + "." + " Km's are: " + totalKm + "km.");
        }

    }

    //----------------------------------CAR-------------------------------------

    class Car : Vehicle 
    {
        private string bodyType;
        private string colour;
        private string upholstery;
        private int doors;
        public Car(string bodyType, string colour, string upholstery, int doors, int rego, string make, string model, int totalKm, Driver theDriver)
            : base(rego, make, model, totalKm, theDriver)
        {
            this.bodyType = bodyType;
            this.colour = colour;
            this.upholstery = upholstery;
            this.doors = doors;
        }

        public void ChangeColor(string newColor) //method for change car color 
        {
            colour = newColor;
        }

        public override void PrintVehicleAll() //For displaying car specific, general details and the driver 
        {
            theDriver.PrintDriver();
            CarSpecific();
            base.PrintVehicleAll();
        }

        public void CarSpecific() //display specific details of car  
        {
            Console.WriteLine(" ");
            Console.WriteLine("Car details: ");
            Console.WriteLine("Body type: " + bodyType + ", colour: " + colour + ", The upholstery: " + upholstery + ", Doors number: " + doors);
        }

        public void PrintGeneral() //display only general details 
        {
            base.PrintVehicleAll(); 
            
        }

        public void SpecAndGen()
        {
            CarSpecific();
            PrintGeneral();
        }

    }

    //-----------------------------TRUCK-------------------------------------------

    class Truck : Vehicle
    {
        private int load;
        private int axles;
        private int wheels;
        public Truck(int load, int axles, int wheels, int rego, string make, string model, int totalKm, Driver theDriver)
            : base(rego, make, model, totalKm, theDriver)
        {
            this.load = load;
            this.axles = axles;
            this.wheels = wheels;
        }


        public void TruckSpecific() //display only especific details from truck 
        {
            Console.WriteLine(" ");
            Console.WriteLine("Truck details: ");
            Console.WriteLine("Maximun load: " + load + "ton." + " Number of axles: " + axles + " Number of wheels: " + wheels);
        }

        public void TruckAndGeneral() //display especific and general details 
        {
            TruckSpecific();
            PrintVehicleAll();
        }

        public void PrintTruckAll() //display all details from truck and the driver 
        {
            theDriver.PrintDriver();
            TruckAndGeneral();

        }
    }

   
    //-------------------------------------------------------------------------
    //-----------------------------PROGRAM--------------------------------------
    //--------------------------------------------------------------------------


    class Program
    {
        static void Main(string[] args)
        {
            //Driver 1, car 1, truck 1 details
            string[] address1 = { "Street: 24 Lincoln Road", "City : Melbourne", "State : Victoria ", "Postcode : 3040" };
            string[] states1 = { "Qld :", " Vic :", " NSW", };
            Driver driver1 = new Driver(58946, "Jack", "Sparrow", 058423645, states1, address1, 5);
            Vehicle objVehicle = new Vehicle(978564, "Ford", "Mustang", 2300, driver1);
            Car car1 = new Car("sedan", "red", "plastic", 4, 978564, "Ford", "Mustang", 2300, driver1);
            Truck truck1 = new Truck(200, 5, 6, 878969, "Mercedes", "Diesel", 1500, driver1);

            //Driver 2, Car 2, Truck 2 details
            string[] address2 = { "Street: 52 Herbert St", "City : Sydney", "State : New South Wales ", "Postcode : 2216" };
            string[] states2 = { " Vic :", " NSW", "SA", "Qld" };
            Driver driver2 = new Driver(666895, "Pedro", "Valdez", 0245789654, states2, address2, 3);
            Vehicle objVehicle2 = new Vehicle(666888, "Toyota", "camrry", 1500, driver2);
            Car car2 = new Car("sedan", "black", "plastic", 4, 666888, "Toyota", "camrry", 1500, driver2);
            Truck truck2 = new Truck(170, 4, 8, 555777, "Mack", "Titan", 35000, driver2);

            //------Display section------//

            //Displaying driver details 
            Console.WriteLine("==========================================");
            Console.WriteLine("\nDisplaying driver details".ToUpper());
            driver1.PrintDriver();

            //Displaying car specific and general 
            Console.WriteLine("==========================================");
            Console.WriteLine("\nDisplaying car general and specific details".ToUpper());
            car1.SpecAndGen();

            //Displaying Truck specific and general 
            Console.WriteLine("==========================================");
            Console.WriteLine("\nDisplaying Truck general and specific details".ToUpper());
            truck1.TruckAndGeneral();

            //Displaying all car details and driver 
            Console.WriteLine(" ");
            Console.WriteLine("==========================================");
            Console.WriteLine("\nDisplaying all car details including driver".ToUpper());
            car1.PrintVehicleAll();

            //Displaying all Truck details and driver 
            Console.WriteLine(" ");
            Console.WriteLine("==========================================");
            Console.WriteLine("\nDisplaying all truck details including driver".ToUpper());
            truck1.PrintTruckAll();

            //Making changes and displaying again
            car1.UpDateKm(200); //updating km on car
            driver1.AddDemeritPoints(3);//Adding demerit points 
            car1.ChangeColor("green");//changing color on car
            Console.WriteLine(" ");
            Console.WriteLine("==========================================");
            Console.WriteLine("\nMacking changes and displaying again. (200km, 3DP, green color)".ToUpper());
            car1.PrintVehicleAll();

            //Attempt ilegal changes and see warnings 
            Console.WriteLine(" ");
            Console.WriteLine("==========================================");
            Console.WriteLine("\nAttempting illegal changes and displaying again. (-2600km, +10DP, -10DP, adding 2DP)".ToUpper());
            Console.WriteLine(" ");
            car1.UpDateKm(-2600); //updating km on car
            driver1.AddDemeritPoints(10);//Exeding the maximun 
            driver1.AddDemeritPoints(-10);//Going bellow cero
            driver1.AddDemeritPoints(2);//Near to suspension 
            car1.PrintVehicleAll();

            //Decreasing demerit points and km within the legal range 
            Console.WriteLine(" ");
            Console.WriteLine("==========================================");
            Console.WriteLine("\nDecreasing demerit points and Km (-500km, -2DP)".ToUpper());
            driver1.AddDemeritPoints(-2);
            car1.UpDateKm(-500);
            driver1.PrintDriver();
            car1.PrintGeneral();


            //Write and read file
            Console.WriteLine(" ");
            Console.WriteLine("==========================================");
            Console.WriteLine("\nWriting and reading driver file".ToUpper());
            driver1.DriverFile();


        }
    }
}
