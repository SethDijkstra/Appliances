using System;

namespace Appliances
{
    class Refrigerator : Appliance
    {
        public int Doors { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }

        public Refrigerator(int itemNum, string brand, int quantity, int wattage, string colour, double price, int doors, double height, double width)
            : base(itemNum, brand, quantity, wattage, colour, price)
        {
            Doors = doors;
            Height = height;
            Width = width;
        }

        public override string ToString()
        {
            return base.ToString() + $"Doors: {Doors}\nHeight (inches): {Height}\nWidth (inches): {Width}\n";
        }

        public override string FileFormat()
        {
            return base.FileFormat() + $"{Doors};{Height};{Width}";
        }
    }
}
