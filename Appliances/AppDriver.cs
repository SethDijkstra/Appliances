using System;
using System.Collections.Generic;
using System.IO;

namespace Appliances
{
    class AppDriver
    {
        private readonly List<Appliance> _appliances;

        public AppDriver()
        {
            _appliances = new List<Appliance>();
            LoadAppliancesFromFile();

            DisplayMenu();
        }

        private void LoadAppliancesFromFile()
        {
            string filePath = "/Users/isaacsaffran/Desktop/C#/Appliances-1/Appliances/appliance.txt";
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string[] fields = line.Split(';');
                string s = fields[0];
                char firstChar = s[0];

                switch (firstChar)
                {
                    case '1':
                        _appliances.Add(new Refrigerator(int.Parse(fields[0]), fields[1], int.Parse(fields[2]), int.Parse(fields[3]), fields[4], double.Parse(fields[5]),
                            int.Parse(fields[6]), double.Parse(fields[7]), double.Parse(fields[8])));
                        break;
                    case '2':
                        _appliances.Add(new Vacuums(int.Parse(fields[0]), fields[1], int.Parse(fields[2]), int.Parse(fields[3]), fields[4], double.Parse(fields[5]),
                            fields[6], double.Parse(fields[7])));
                        break;
                    case '3':
                        _appliances.Add(new Microwaves(int.Parse(fields[0]), fields[1], int.Parse(fields[2]), int.Parse(fields[3]), fields[4], double.Parse(fields[5]), double.Parse(fields[6]), fields[7]));
                        break;
                    case '4':
                    case '5':
                        _appliances.Add(new Dishwasher(int.Parse(fields[0]), fields[1], int.Parse(fields[2]), int.Parse(fields[3]), fields[4], double.Parse(fields[5]), fields[6], fields[7]));
                        break;
                    default:
                        Console.WriteLine("No appliance with this ID is available.");
                        break;
                }
            }
        }

        public void DisplayMenu()
        {
            int choice = 0;
            while (choice != 5)
            {
                Console.WriteLine("Welcome to Modern Appliances");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("\nHow may we assist you?");
                Console.WriteLine("----------------------");
                Console.WriteLine("1 - Check out Appliance");
                Console.WriteLine("2 - Find appliances by brand");
                Console.WriteLine("3 - Display appliances by type");
                Console.WriteLine("4 - Produce random appliance list");
                Console.WriteLine("5 - Save & exit");

                Console.Write("\nEnter Option: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Function 1");
                        break;
                    case 2:
                        Console.WriteLine("Function 2");
                        break;
                    case 3:
                        Console.WriteLine("Function 3");
                        break;
                    case 4:
                        Console.WriteLine("Eat dix");
                        break;
                    case 5:
                        Console.WriteLine("Thank-You for visiting, Have a nice day!");
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
                        break;
                }
            }
        }
    }
}
