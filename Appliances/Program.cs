namespace Appliances
{
    internal class Program
    {
        static void Main(string[] args)
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