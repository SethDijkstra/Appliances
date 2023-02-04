using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appliances
{
    class Refrigerator : Appliance
    {
        private int doors;
        private int height;
        private int width;

        public Refrigerator(int itemNum, string brand, int quantity, int wattage, 
            string colour, double price, int doors, int height, int width) : base(itemNum, brand, quantity, wattage, colour, price)
        {
            this.doors = itemNum;
            this.height = height;
            this.width = width;
        }

        public int getDoors()
        {
            return doors;
        }
        public int getHeight()
        {
            return height;
        }
        public int getWidth()
        {
            return width;
        }

        public void setDoors(int doors)
        {
            this.doors = doors;
        }
        public void setHeight(int height)
        {
            this.height = height;
        }
        public void setWidth(int width)
        {
            this.width = width;
        }

        public override string ToString()
        {
            return "Doors: "+ doors +
                "Height (inches): " + height +
                "Width (inches): " + width;
        }
    }
}
