using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace Appliances
{
    class AppDriver

    {
        
        public List<Appliance> appliances = new List<Appliance>();
        

        private void loadingFile()
        {
            string filepath = @"C:\Code School\C#\Appliances\appliances.txt";
            string[] lines = File.ReadAllLines(filepath);

            foreach (string line in lines)
            {
                string[] fields = line.Split(";");
                string s = fields[0];
                char firstChar = s[0];

                if (firstChar == '1')
                {
                    appliances.Add(new Refrigerator(int.Parse(fields[0]), fields[1], int.Parse(fields[2]), int.Parse(fields[3]), fields[4], double.Parse(fields[5]),
                        int.Parse(fields[6]), double.Parse(fields[7]), double.Parse(fields[8])));
                }

                else if (firstChar == '2')
                {
                    appliances.Add(new Vacuums(int.Parse(fields[0]), fields[1], int.Parse(fields[2]), int.Parse(fields[3]), fields[4], double.Parse(fields[5]),
                        fields[6], double.Parse(fields[7])));
                }
                else if (firstChar == '3')
                {
                    appliances.Add(new Microwaves(int.Parse(fields[0]), fields[1], int.Parse(fields[2]), int.Parse(fields[3]), fields[4], double.Parse(fields[5]), double.Parse(fields[6]), fields[7]) );
                }
                else if (firstChar == '4' || firstChar == '5')
                {
                    appliances.Add(new Dishwasher(int.Parse(fields[0]), fields[1], int.Parse(fields[2]), int.Parse(fields[3]), fields[4], double.Parse(fields[5]), fields[6], fields[7]));
                }
                else
                {
                    Console.WriteLine("No appliance with this ID is avaliable.");
                }

            }
            
        }
        public AppDriver()
        {
            loadingFile();
            
            /*foreach (Appliance appliance in appliances)
            {
                Console.WriteLine(appliance);
            }
            */

            displayMenu();
        }
        public void displayMenu()
        {
            loadingFile();
            int choice = 0;
            while (choice != 5)
            {
                Console.WriteLine("                                               " +
                    "Welcome to Modern Appliances");
                Console.WriteLine("                                               " +
                    "~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

                Console.WriteLine("\n   How may we assist you?\n   ----------------------");
                Console.WriteLine(" 1 - Check out Appliance");
                Console.WriteLine(" 2 - Find appliances by brand");
                Console.WriteLine(" 3 - Display appliances by type");
                Console.WriteLine(" 4 - Produce random appliance list");
                Console.WriteLine(" 5 - Save & exit");

                Console.Write("\nEnter Option: ");
                
                try
                {
                    choice = int.Parse(Console.ReadLine());

                    if (choice < 1 || choice > 5)
                    {
                        Console.Beep(300, 200);
                        Console.WriteLine("Invalid option. Please enter a number between 1 and 5.\n");
                    }
                    else
                    {
                        switch (choice)
                        {
                            case 1:
                                int itemNum = 0;
                                Console.WriteLine("Enter item number of an Appliance: ");
                                itemNum = int.Parse(Console.ReadLine());
                                bool found = false;
                                foreach (Appliance appliance in appliances)
                                {
                                    bool check = appliance.isAvaliable(itemNum);
                                    if (check)
                                    {
                                        Console.WriteLine("Appliance '" + itemNum + "'has been checked out");
                                        found = true;
                                        break;
                                    }
                                }
                                if (!found)
                                {
                                    Console.WriteLine("No appliance was found with that item number");
                                }
                                break;
                            case 2:
                                Console.WriteLine("Function 2");
                                break;
                            case 3:
                                Console.WriteLine("Function 3");
                                break;
                            case 4:
                                Console.WriteLine("Function 4");
                                break;
                            case 5:
                                Console.WriteLine("\nThank-You for visiting, Have a nice day!");
                                break;
                        }
                    }
                }
                catch (FormatException)
                {
                    Console.Beep(300, 200);
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 5.\n");
                }
            }
        }

        



    }
}
