using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appliances
{
    class AppDriver

    {   
        public List<Appliance> appliaces = new List<Appliance>();

        private void loadingFile()
        {
            string filepath = @"C:\Users\Seth\source\repos\Appliances\Appliances\appliances.txt";
            string[] lines = File.ReadAllLines(filepath);

            foreach (string line in lines)
            {
                string[] fields = line.Split(";");
                string s = fields[0];
                char firstChar = s[0];

                if (firstChar == '1')
                {
                    appliaces.Add(new Refrigerator(int.Parse(fields[0]), fields[1], int.Parse(fields[2]), int.Parse(fields[3]), fields[4], double.Parse(fields[5]),
                        int.Parse(fields[6]), int.Parse(fields[7]), int.Parse(fields[8])));
                }

            }
            
        }
        public AppDriver()
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
            int userInput = int.Parse(Console.ReadLine());
        }
    }
}
