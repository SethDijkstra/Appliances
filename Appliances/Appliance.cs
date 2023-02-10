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
                this.quantity -= 1;
                if (this.quantity<= 0)
                {
                    this.quantity = 0;
                    Console.Beep(300, 200);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nThis appliance is out of stock\n");
                    Console.ResetColor();
                    Thread.Sleep(1000);
                    Console.WriteLine("    ______________________\n   /Redirecting to menu../\n  /_____________________/");
                    Thread.Sleep(1000);

                    
                    return true;
                }
                
                return true;

            }
            else
            {

                return false;
            }
        }

        /*
         * Return as formatted string
         *
        public override string ToString()
        {
            return (String.Format("Appliance number: {0,-15} Brand: {1,-15} Quantity: {2,-15} Wattage: {3,-15} Colour: {4,-15} Price ($): {5,-15}",
                itemNum, brand, quantity, wattage, colour, price));
        }
        */
        public override string ToString()
        {
            return "Appliance number: " + itemNum + "\n" + "Brand: " + brand + "\n" + "Quantity: " + quantity + "\n" + "Wattage: " + wattage + "\n" + "Colour: " + colour + "\n" + "Price ($): " + price + "\n";
        }
    }



}
