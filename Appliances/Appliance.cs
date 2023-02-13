using System;

namespace Appliances
{
    class Appliance
    {
        public int ItemNum { get; set; }
        public string Brand { get; set; }
        public int Quantity { get; set; }
        public int Wattage { get; set; }
        public string Colour { get; set; }
        public double Price { get; set; }

        public Appliance(int itemNum, string brand, int quantity, int wattage, string colour, double price)
        {
            ItemNum = itemNum;
            Brand = brand;
            Quantity = quantity;
            Wattage = wattage;
            Colour = colour;
            Price = price;
        }

        public override string ToString()
        {
            return $"Appliance number: {ItemNum}\nBrand: {Brand}\nQuantity: {Quantity}\nWattage: {Wattage}\nColour: {Colour}\nPrice ($): {Price}\n";
        }

        public virtual string FileFormat()
        {
            return $"{ItemNum};{Brand};{Quantity};{Wattage};{Colour};{Price};";
        }

        public bool IsAvailable(int itemNum)
        {
            if (itemNum == ItemNum)
            {
                Quantity--;
                if (Quantity <= 0)
                {
                    Console.Beep(300, 200);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nThis appliance is out of stock\n");
                    Console.ResetColor();
                    System.Threading.Thread.Sleep(1000);
                    Console.WriteLine("    ______________________\n   /Redirecting to menu../\n  /_____________________/");
                    System.Threading.Thread.Sleep(1000);
                    Quantity = 0;
                    return true;
                }

                return true;
            }

            return false;
        }
    }
}
