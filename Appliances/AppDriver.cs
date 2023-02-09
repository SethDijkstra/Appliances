using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace Appliances
{
    class AppDriver

    {
        
        public List<Appliance> appliances = new List<Appliance>();
        private static Random random = new Random();

        private void loadingFile()
        {
            string filepath = @"appliances.txt";
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

            /*
            foreach (Appliance appliance in appliances)
            {
                Console.WriteLine(appliance);
            }*/

            displayMenu();
        }
        public void displayMenu()
        {
            loadingFile();
            int choice = 0;

            Console.WriteLine("\n\n\n\n");
            Console.WriteLine("                ****************************************************************************");
            Console.WriteLine("                *                                                                          *");
            Console.WriteLine("                *                                ModernAppliances                          *");
            Console.WriteLine("                *                                                                          *");
            Console.WriteLine("                ****************************************************************************");

            while (choice != 5)
            {
                Console.WriteLine("\n   How may we assist you?\n   ----------------------");
                Console.WriteLine(" 1 - Check out Appliance");
                Console.WriteLine(" 2 - Find appliances by brand");
                Console.WriteLine(" 3 - Display appliances by type");
                Console.WriteLine(" 4 - Produce random appliance list");
                Console.WriteLine(" 5 - Save & exit");
                Console.WriteLine("\nEnter Option: ");
                
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
                                checkoutAppliance();
                                break;
                            case 2:
                                searchByBrand();
                                break;
                            case 3:
                                searchByType();
                                break;
                            case 4:
                                randomAppliances();
                                break;
                            case 5:
                                writeToFile();
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
        public void checkoutAppliance()
        {
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
                Console.Beep(300, 200);
                Console.WriteLine("\nNo appliance was found with that item number\n");
            }
        }

        //A method that prompts the customer to enter a brand. Performs a case-insensitive search
        //of appliances that have the same brand, and displays them.
        public void searchByBrand()
        {
            //Asks for brand and reads user input
            Console.WriteLine("Enter a brand to search for: ");
            string userInput = Console.ReadLine().ToLower();

            //Searches every appliance for the user entered brand
            foreach (Appliance appliance in appliances)
            {
                string brand = appliance.getBrand().ToLower();

                //If found displays relevant appliances
                if (userInput == brand)
                {
                    Console.WriteLine(appliance.ToString());
                }
            }
            //If none returns to main menu
            Console.WriteLine("There doesn't seem to be any brands by that name, returning to main menu...");
        }

        //A method that prompts a user to enter a number, and the program then displays that number of random
        //appliances.The appliances can be of any type.
        public void randomAppliances()
        {
            //Asks for number of appliances
            Console.WriteLine("Enter number of appliances: ");

            try
            {
                //Converts user input to int
                int userInput = int.Parse(Console.ReadLine());
                //Runs for loop 'user input' amount of times
                for (int x = 0; x < userInput; x++)
                {
                    //Sets y as a random integer no greater than total appliances in list
                    int y = random.Next(appliances.Count);
                    //Displays appliance located at y index in our appliance list
                    Console.WriteLine(appliances[y].ToString()); 
                }
            }
            
            //Error message if user doesn't enter a number
            catch (FormatException)
            {
                Console.WriteLine("Please enter an integer.\nReturning to main menu...");
            }
        }

        //A method that asks the user which type of appliance they'd like to view and displays only that type
        public void searchByType()
        {
            bool inputValid = false;
            while (!inputValid)
            {
                Console.WriteLine(" 1 - Refridgerators");
                Console.WriteLine(" 2 - Vacuums");
                Console.WriteLine(" 3 - Microwaves");
                Console.WriteLine(" 4 - Dishwashers");
                Console.WriteLine(" 5 - Exit");

                Console.Write("\nEnter type of appliance: ");

                try
                {
                    int userInput = int.Parse(Console.ReadLine());
                    inputValid = true;

                    switch (userInput)
                    {
                        case 1:
                            Console.WriteLine("Enter number of doors: ");
                            Console.WriteLine("2 - 4 Doors");
                            Console.ReadLine();
                            try
                            {
                                int doors = int.Parse(Console.ReadLine());
                                if (doors == 2 || doors == 3 || doors == 4)
                                {
                                    foreach (Refrigerator refrigerator in appliances)
                                    {
                                        if (refrigerator is Refrigerator)
                                        {
                                            doors = refrigerator.getDoors();
                                            Console.WriteLine(doors);
                                        }
                                        
                                    }
                                    
                                }
                                
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("The only valid inputs are 2, 3, & 4");
                            }
                            break;
                        case 2:
                            Console.WriteLine("Enter voltage");
                            break;
                        case 3:
                            Console.WriteLine("Enter room");
                            break;
                        case 4:
                            Console.WriteLine("Enter sound rating");
                            break;
                        case 5:
                            Console.WriteLine("Returning to main menu...");
                            displayMenu();
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter an integer");
                }
            }
            Console.WriteLine("things are working");
        }

        /*A method that takes the appliances stored in the list and persists them back to the appliances.txt
        *file in the proper format
        */
        public void writeToFile()
        {
            string filepath = @"appliances.txt";
            
            //Creates a list of strings for lines in the file
            List<string> lines = new List<string>();
            //Foreach appliance in the list we will be adding strings to our new list names 'lines'
            foreach (Appliance appliance in appliances)
            {
                //If fridge, include all fridge attributes in new line
                if (appliance is Refrigerator)
                {
                    Refrigerator refridgerator= (Refrigerator)appliance;
                    refridgerator.fileFormat();
                }
                //If vacuum, include all vacuum attributes in new line
                else if (appliance is Vacuums)
                {
                    Vacuums vacuums = (Vacuums)appliance;
                    vacuums.fileFormat();
                }
                //If microwave, include all microwave attributes in new line
                else if (appliance is Microwaves)
                {
                    Microwaves microwaves = (Microwaves)appliance;
                    microwaves.fileFormat();
                }
                //If dishwasher, include all dishwasher attributes in new line
                else if (appliance is Dishwasher)
                {
                    Dishwasher dishwasher = (Dishwasher)appliance;
                    dishwasher.fileFormat();
                }

                
            }
        }
        

        




    }
}
