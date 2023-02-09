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
        private double height;
        private double width;

        public Refrigerator(int itemNum, string brand, int quantity, int wattage, 
            string colour, double price, int doors, double height, double width) : 
            base(itemNum, brand, quantity, wattage, colour, price)
        {
            this.doors = doors;
            this.height = height;
            this.width = width;
        }

        public int getDoors()
        {
            return doors;
        }
        public double getHeight()
        {
            return height;
        }
        public double getWidth()
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
        public override string fileFormat()
        {
            return base.fileFormat() + ";" +
                this.doors + ";" +
                this.height + ";" +
                this.width;
        }
        public override string ToString()
        {
            return base.ToString() +
                String.Format("Doors: {0,-15} Height (inches): {1,-5} Width (inches): {2,0}", doors, height, width);
        }

    }
}

