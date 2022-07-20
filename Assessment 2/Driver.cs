using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Assessment_2
{
    class Driver
    {
        public int licence;
        public string fName;
        public string lName;
        public int phone;
        public string[] states;
        public string[] address;
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


        public void AddDemeritPoints(int newDP)
        {
            if (newDP < 0)
            {
                totalDemeritPoints = totalDemeritPoints + newDP;
                
                if (totalDemeritPoints < 0)
                {
                    totalDemeritPoints = totalDemeritPoints - newDP;
                    Console.WriteLine(" ");
                    Console.WriteLine("-------------------------------------------- ");
                    Console.WriteLine("LICENCE STATUS WARNING");
                    Console.WriteLine("ERROR, demerit points is bellow 0");
                    Console.WriteLine("-------------------------------------------- ");
                    Console.WriteLine(" ");

                }
               
            }

            else if(newDP > 0)
            {
                totalDemeritPoints = newDP + totalDemeritPoints;
                
                if(totalDemeritPoints > MaxDemeritPoints)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("-------------------------------------------- ");
                    Console.WriteLine("LICENCE STATUS WARNING");
                    Console.WriteLine("ERROR, New demerit points exced the maximum");
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

        public void PrintDriver()
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

        public void DriverFile()
        {
            string driverDetails = "The driver " + fName +  " " + lName + ", has a driver licence number: " + licence + " Contact phone number: " + phone + " Demerit points: " + totalDemeritPoints;
            File.WriteAllText("Driver.txt", driverDetails);

            string read = File.ReadAllText("Driver.txt");
            Console.WriteLine(read);


        }

    }
}
