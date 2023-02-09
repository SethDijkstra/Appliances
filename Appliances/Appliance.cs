using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appliances
{
    class Appliance
    {
        private int itemNum;
        private string brand;
        private int quantity;
        private int wattage;
        private string colour;
        private double price;

        public Appliance(int itemNum, string brand, int quantity, 
            int wattage, string colour, double price)
        {
            this.itemNum = itemNum;
            this.brand = brand;
            this.quantity = quantity;
            this.wattage = wattage;
            this.colour = colour;
            this.price = price;
        }

        public int getItemNum()
        {
            return itemNum;
        }

        public string getBrand()
        {
            return brand;
        }
        public int getQuantity()
        {
            return quantity;
        }
        public int getWattage()
        {
            return wattage;
        }
        public string getColour()
        {
            return colour;
        }
        public double getPrice()
        {
            return price;
        }

        public void setItemNum(int itemNum)
        {
            this.itemNum = itemNum;
        }

        public void setBrand(string brand)
        {
            this.brand = brand;
        }

        public void setQuantity(int quantity)
        {
            this.quantity = quantity;
        }
        public void setWattage(int wattage)
        {
            this.wattage = wattage;
        }

        public void setColour(string colour)
        {
            this.colour = colour;
        }

        public void setPrice(double price)
        {
            this.price = price;
        }

        public virtual string fileFormat()
        {
            return this.itemNum + ";" +
                this.brand + ";" +
                this.quantity + ";" +
                this.wattage + ";" +
                this.colour + ";" +
                this.price + ";";
        }

        public bool isAvaliable(int itemNum)
        {
            if (itemNum == getItemNum())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /*
         * Return as formatted string
         */
        public override string ToString()
        {
            return (String.Format("Appliance number: {0,-15} Brand: {1,-15} Quantity: {2,-15} Wattage: {3,-15} Colour: {4,-15} Price ($): {5,-15}",
                itemNum, brand, quantity, wattage, colour, price));
        }

    }



}
