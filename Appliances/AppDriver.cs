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

            string filepath = "appliances.txt";
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
                    appliances.Add(new Microwaves(int.Parse(fields[0]), fields[1], int.Parse(fields[2]), int.Parse(fields[3]), fields[4], double.Parse(fields[5]), double.Parse(fields[6]), fields[7]));
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
            displayMenu();
        }



        public void displayMenu()
        {
            loadingFile();
            int choice = 0;

            //Display welcome message when program starts
            Console.WriteLine("\n\n\n\n");
            Console.WriteLine("\u001b[31m");
            Console.WriteLine("                     ******************************************************************************");
            Console.WriteLine("                     *                                                                            *");
            Console.WriteLine("                     *                                                                            *");
            Console.WriteLine("                     *                        Welcome to Modern Appliances                        *");
            Console.WriteLine("                     *                                                                            *");
            Console.WriteLine("                     *                                                                            *");
            Console.WriteLine("                     ******************************************************************************\u001b[0m\n\n\n\n");

            //If user doesn't enter 5 to exit the menu will continue looping
            while (choice != 5)
            {
                Console.WriteLine("\n   How may we assist you?\n   ----------------------");
                Console.WriteLine(" 1 - Check out Appliance");
                Console.WriteLine(" 2 - Find appliances by brand");
                Console.WriteLine(" 3 - Display appliances by type");
                Console.WriteLine(" 4 - Produce random appliance list");
                Console.WriteLine(" 5 - Save & exit");
                Console.Write("\nEnter Option: \n    ");

                //Try converting user option to int
                try
                {
                    choice = int.Parse(Console.ReadLine());

                    if (choice < 1 || choice > 5)
                    {
                        //If invalid choice print error message
                        Console.Beep(300, 200);
                        Console.WriteLine("Invalid option. Please enter a number between 1 and 5.\n");
                    }
                    else
                    {
                        switch (choice)
                        {
                            //If 1 run checkout appliance method
                            case 1:
                                checkoutAppliance();
                                break;
                            //If 2 run search by brand method
                            case 2:
                                searchByBrand();
                                break;
                            //If 3 run search by type method
                            case 3:
                                searchByType();
                                break;
                            //If 4 run search random appliance method
                            case 4:
                                randomAppliances();
                                break;
                            //If 5 , write list of objects to file and exit program with goodbye message
                            case 5:
                                writeFile();
                                Console.WriteLine("\nThank-You for visiting, Have a nice day!");
                                break;
                        }
                    }
                }
                //Catch error if user enters a non integer
                catch (FormatException)
                {   
                    Console.Beep(300, 200);
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 5.\n");
                }

            }

        }
        /*
         * checkoutAppliance method that prompts the user to input the appliance ID, if its avaliable then it will checkout
         * if the quantity is at 0 then it will tell the user that they are out of stock, finally if the user enters an ID that does not match the list of appliance ID numbers
         * it will return saying no appliance is found. Each aspect will then return to the main menu.
         */
        public void checkoutAppliance()
        {
            //ask user for the appliance item num
            int itemNum = 0;
            Console.Write("\nEnter item number of an Appliance:\n    ");
            itemNum = int.Parse(Console.ReadLine());
            //set this to false to parse through each appliance, only printing if its a match or after it finishes parsing through
            bool found = false;
            foreach (Appliance appliance in appliances)
            {
                //use the public bool isAvaliable(int itemNum); method in Appliance class, checks to see for match then returns true or false
                bool check = appliance.isAvaliable(itemNum);

                //if check == true then it enters stage to check if the quantity is above 0.
                if (check)
                {
                    int quantity = ((Appliance)appliance).getQuantity();
                    if (quantity <=0)
                    {
                        //ends function and prints statement from isAvaliable method
                        found = true;
                        break;
                        
                    }
                    //if check == true and quantity > 0, prints the respected itemNum thats correspondant to the appliance
                    found = true;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nAppliance '" + itemNum + "'has been checked out\n");
                    Console.ResetColor();
                    Thread.Sleep(1000);
                    Console.WriteLine("    ______________________\n   /Redirecting to menu../\n  /_____________________/");
                    Thread.Sleep(1000);
                    break;
                }
            }
            //after parsing and none return true, user is prompted with an error saying no appliance was found
            if (!found)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Beep(300, 200);
                Console.WriteLine("\nNo appliance was found with that item number\n");
                Console.ResetColor();
                Thread.Sleep(1000);
                Console.WriteLine("    ______________________\n   /Redirecting to menu../\n  /_____________________/");
                Thread.Sleep(1000);
                
                
            }
        }

        //A method that prompts the customer to enter a brand. Performs a case-insensitive search
        //of appliances that have the same brand, and displays them.
        public void searchByBrand()
        {
            //Asks for brand and reads user input
            Console.Write("\nEnter a brand to search for: \n    ");
            string userInput = Console.ReadLine().ToLower();


            bool check = false;
            //Searches every appliance for the user entered brand
            foreach (Appliance appliance in appliances)
            {
                string brand = appliance.getBrand().ToLower();

                //If found displays relevant appliances
                if (userInput == brand)
                {
                    Console.WriteLine("\n" + appliance.ToString());
                    check = true;
                }
                
            }
            if (!check)
            {
                //If none returns to main menu
                Console.Beep(300, 200);
                Console.WriteLine("\nThere doesn't seem to be any brands by that name\n");
                Thread.Sleep(1000);
                Console.WriteLine("    ______________________\n   /Redirecting to menu../\n  /_____________________/");
                Thread.Sleep(1000);
            }

        }

        //A method that prompts a user to enter a number, and the program then displays that number of random
        //appliances.The appliances can be of any type.
        public void randomAppliances()
        {
            //Asks for number of appliances
            Console.Write("\nEnter number of appliances:\n    ");

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
                    Console.WriteLine("\n"+appliances[y].ToString());
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
                //Displays menu for different appliance types and asks for user selection
                Console.WriteLine("\n 1 - Refridgerators");
                Console.WriteLine(" 2 - Vacuums");
                Console.WriteLine(" 3 - Microwaves");
                Console.WriteLine(" 4 - Dishwashers");
                Console.WriteLine(" 5 - Exit");

                Console.Write("\nEnter type of appliance:\n    ");

                try
                {
                    int userInput = int.Parse(Console.ReadLine());
                    inputValid = true;

                    //Switch case based on user input it will run the proper method
                    switch (userInput)
                    {
                        //If 1 run search by doors method
                        case 1:
                            searchByDoors();
                            break;
                        //If 2 run search by volts method
                        case 2:
                            searchByVolts();
                            break;
                        //If 3 run search by room method
                        case 3:
                            searchByRoom();
                            break;
                        //If 4 run search by sound method
                        case 4:
                            searchBySound();
                            break;
                        //If 5 redirects to main menu
                        case 5:
                            Thread.Sleep(1000);
                            Console.WriteLine("    ______________________\n   /Redirecting to menu../\n  /_____________________/");
                            Thread.Sleep(1000);
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter an integer");
                }
            }
        }

        // A method for searching fridges by doors, used in searchByType
        public void searchByDoors()
        {
            //Asks user to input desired number of doors
            Console.WriteLine("Enter number of doors: ");
            Console.WriteLine("2 - 4 Doors\n    ");
            try
            {
                //Stores user input as variable
                int doors = int.Parse(Console.ReadLine());
                if (doors == 2 || doors == 3 || doors == 4)
                {
                    foreach (Appliance appliance in appliances)
                    {
                        if (appliance is Refrigerator refrigerator)
                        {
                            //Compares variable to actual amount of doors of refridgerators in our list
                            if (refrigerator.getDoors() == doors)
                            {
                                //If found print product information
                                Console.WriteLine("\n   Matching Refrigerator:\n");
                                Console.WriteLine(refrigerator.ToString());
                            }
                        }

                    }
                }
                else
                {
                    Console.WriteLine("There are no fridges with that amount of doors, sorry.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("The only valid inputs are 2, 3, & 4");
            }
        }

        //A method for searching vacuums by voltage, used in searchByType
        public void searchByVolts()
        {
            //Gives the user two options for voltages to search for
            Console.Write("\n\nEnter battery voltage\n18V(low) or 24V(high)\n(V):");
            double voltage = double.Parse(Console.ReadLine());
            try
            {
                //If user inputs correctly it will find matching vacuums in list
                if (voltage == 18 || voltage == 24)
                {
                    foreach (Appliance appliance in appliances)
                        if (appliance is Vacuums vacuums)
                        {
                            if (vacuums.getVoltage() == voltage)
                            {
                                //If it finds matching vacuum(s) it will print product info
                                Console.WriteLine("\n   Matching Vaccum:\n");
                                Console.WriteLine(vacuums.ToString());
                            }
                        }
                }
                else
                {
                    Console.WriteLine("The only valid inputs are 18 or 24.");
                    Thread.Sleep(1000);
                    Console.WriteLine("    ______________________\n   /Redirecting to menu../\n  /_____________________/");
                    Thread.Sleep(1000);
                }
            }
            //Prints error message if user enters a non-integer
            catch
            {
                Console.WriteLine("The only valid inputs are 18 or 24.");
                searchByVolts();
            }
        }

        //A method for searching microwaves by room type('W'ork or 'K'itchen)
        public void searchByRoom()
        {
            //Sets 'found' to false
            bool found = false;
            Console.WriteLine("\nEnter room where microwave will be installed.");
            Console.Write("Enter 'K' for Kitchen or 'W' for Worksite.\n    ");
            string userInput = Console.ReadLine().ToUpper();
            foreach (Appliance appliance in appliances)
                if (appliance is Microwaves microwaves)
                {
                    if (microwaves.getRoom() == userInput)
                    {
                        //If matching microwave is found print item info and change 'found' to true.
                        Console.WriteLine("\n   Matching Microwave:\n");
                        Console.WriteLine(microwaves.ToString());
                        found = true;
                    }
                }
            if (!found)
            {
                //If no microwaves are found print message and return to main menu.
                Console.WriteLine("\nThere are no microwaves matching your input.");
                Console.WriteLine("    ______________________\n   /Redirecting to menu../\n  /_____________________/");
            }
        }

        //A method for searching dishwashers by sound rating
        public void searchBySound()
        {
            bool found = false;
            Console.WriteLine("\nEnter the sound rating of the dishwasher");
            Console.WriteLine("Qt (Quietist), Qr (Quieter), Qu (Quiet), or M(Moderate)\n    ");
            string userInput = Console.ReadLine().ToUpper();
            foreach (Appliance appliance in appliances)
                if (appliance is Dishwasher dishwasher)
                {
                    if (dishwasher.getSound().ToUpper() == userInput)
                    {
                        Console.WriteLine("\n   Matching Dishwasher:\n");
                        Console.WriteLine(dishwasher.ToString());
                        found = true;
                    }
                }
            if (!found)
            {
                Console.WriteLine("\nThere are no Dishwashers matching your input.");
                Console.WriteLine("    ______________________\n   /Redirecting to menu../\n  /_____________________/");
            }
                
        }

        /*A method that takes the appliances stored in the list and persists them back to the appliances.txt
        *file in the proper format*/
        public void writeFile()
        {
            
            File.WriteAllText("appliances.txt", string.Empty);
            
            using (StreamWriter writer = new StreamWriter("appliances.txt"))
            {
                //Foreach appliance in the list we will be adding strings to our new list names 'lines'
                foreach (Appliance appliance in appliances)
                {
                    //If fridge, include all fridge attributes in new line
                    if (appliance is Refrigerator)
                    {
                        writer.WriteLine(((Refrigerator)appliance).fileFormat());
                    }
                    //If vacuum, include all vacuum attributes in new line
                    else if (appliance is Vacuums)
                    {
                        writer.WriteLine(((Vacuums)appliance).fileFormat());
                    }
                    //If microwave, include all microwave attributes in new line
                    else if (appliance is Microwaves)
                    {
                        writer.WriteLine(((Microwaves)appliance).fileFormat());
                    }
                    //If dishwasher, include all dishwasher attributes in new line
                    else if (appliance is Dishwasher)
                    {
                        writer.WriteLine(((Dishwasher)appliance).fileFormat());
                    }


                }
            }
        }

        //public void displayAllAppliancesInFile()
        //{
        //    loadingFile();
        //    foreach (Appliance appliance in appliances)
        //    {
        //        Console.WriteLine(appliance);
        //    }
        //}

    }
}