﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Assessment_2
{
    class Driver
    {
        protected int licence;
        protected string fName;
        protected string lName;
        protected int phone;
        private string[] states;
        private string[] address;
        public int totalDemeritPoints;
        public static int MaxDemeritPoints = 12;
        
        public Driver(int licence, string fName, string lName, int phone, string[] states, string[] address,   int totalDemeritPoints, int MaxDemeritPoints = 12)
        {
            this.licence = licence;
            this.fName = fName;
            this.lName = lName;
            this.phone = phone;
            this.address = address;
            this.states = states;
            this.totalDemeritPoints = totalDemeritPoints;
        

        }


        public void AddDemeritPoints(int newDP) //Method for updating demerit points 
        {
            if (newDP < 0) //We can decrease demerit points but if the totaldemeritpoints goes bellow cero, it does not update.
            {
                totalDemeritPoints = totalDemeritPoints + newDP;
                
                if (totalDemeritPoints < 0)
                {
                    totalDemeritPoints = totalDemeritPoints - newDP;
                    Console.WriteLine(" ");
                    Console.WriteLine("-------------------------------------------- ");
                    Console.WriteLine("LICENCE STATUS WARNING");
                    Console.WriteLine("ERROR, demerit points is below zero");
                    Console.WriteLine("-------------------------------------------- ");
                    Console.WriteLine(" ");

                }
               
            }

            else if(newDP > 0) //adding demerit points with warning when it is between 9 and 12 and when it is over 12. 
            {
                totalDemeritPoints = newDP + totalDemeritPoints;
                
                if(totalDemeritPoints > MaxDemeritPoints)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("-------------------------------------------- ");
                    Console.WriteLine("LICENCE STATUS WARNING");
                    Console.WriteLine("ERROR, New demerit points exceed the maximum");
                    Console.WriteLine("-------------------------------------------- ");
                    Console.WriteLine(" ");
                    totalDemeritPoints = totalDemeritPoints - newDP;
                }
                else if (totalDemeritPoints >= 9 && totalDemeritPoints < MaxDemeritPoints)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("-------------------------------------------- ");
                    Console.WriteLine("LICENCE STATUS WARNING");
                    Console.WriteLine("Total Demerit points: " + totalDemeritPoints);
                    Console.WriteLine("License suspension is imminent");
                    Console.WriteLine("-------------------------------------------- ");
                    Console.WriteLine(" ");
                }
            }

        }

        public void PrintDriver() //Displaying the driver details 
        {
            Console.WriteLine("Driver details: ");
            Console.WriteLine("The driver " + fName + " " + lName + ", has a driver licence number: " + licence + " Contact phone number: " + phone + " Demerit points: " + totalDemeritPoints);
            Console.WriteLine(" ");
            Console.WriteLine("The driver is licenced to drive in the following states: ");
            foreach (string state in states )
            {
                Console.Write(state);

            }
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine("Driver address: ");
            foreach (string item in address)
            {
                Console.WriteLine(item);
            }

        }

        public void DriverFile() //method for writing and reading the txt file with the driver details. 
        {
            string[] state = states;
            string[] item = address;
            string aboutAddress = "\nDriver address: " + "\n";
            string aboutStates = "\nThe driver is licenced to drive in the following states: " + "\n";
            string driverDetails = "The driver " + fName +  " " + lName + ", has a driver licence number: " + licence + " Contact phone number: " + phone + " Demerit points: " + totalDemeritPoints + "\n";
           
            File.WriteAllText("C:\\Temp\\Driver.txt", driverDetails);
            File.AppendAllText("C:\\Temp\\Driver.txt", aboutStates);
            File.AppendAllLines("C:\\Temp\\Driver.txt", states);
            File.AppendAllText("C:\\Temp\\Driver.txt", aboutAddress);
            File.AppendAllLines("C:\\Temp\\Driver.txt", address);

            string read = File.ReadAllText("C:\\Temp\\Driver.txt");
            Console.WriteLine(read);


        }

    }
}
