using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appliances
{
    //Creating new subclass Refrigerator from base class Appliance
    class Refrigerator : Appliance
    {
        //Adds three new attributes to subclass
        private int doors;
        private double height;
        private double width;

        /*Constructor that calls superclass constructor and adds the two new
         refrigerator attributes*/
        public Refrigerator(int itemNum, string brand, int quantity, int wattage, 
            string colour, double price, int doors, double height, double width) : 
            base(itemNum, brand, quantity, wattage, colour, price)
        {
            this.doors = doors;
            this.height = height;
            this.width = width;
        }

        //Getters for all fields
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

        //Setters for all fields
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

        /*Returns a formatted string for file output containing attributes from base
         class and adds two from subclass*/
        public override string fileFormat()
        {
            return base.fileFormat() +
                this.doors + ";" +
                this.height + ";" +
                this.width;
        }

        //Returns a formatted string representation of subclass.
        public override string ToString()
        {
            return base.ToString() + "Doors: " + doors + "\n" + "Height (inches): " + height + "\n" + "Width (inches): " + width + "\n";
        }

    }
}

