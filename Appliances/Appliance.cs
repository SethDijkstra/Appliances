using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appliances
{
    //Base/superclass containing all appliance attributes
    class Appliance
    {
        private int itemNum;
        private string brand;
        private int quantity;
        private int wattage;
        private string colour;
        private double price;

        //Constructor
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

        //Getters for all fields
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

        //Setters for all fields
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

        //Method to return formatted string for file output
        public virtual string fileFormat()
        {
            return this.itemNum + ";" +
                this.brand + ";" +
                this.quantity + ";" +
                this.wattage + ";" +
                this.colour + ";" +
                this.price + ";";
        }

        //Check if item is available and decrement quantity if so
        public bool isAvaliable(int itemNum)
        {
            if (itemNum == getItemNum())
            {
                this.quantity -= 1;
                if (this.quantity<= 0)
                {
                    //If not found print out of stock message and return to main menu
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

        //Return string representation of object
        public override string ToString()
        {
            return "Appliance number: " + itemNum + "\n" + "Brand: " + brand + "\n" + "Quantity: " + quantity + "Wattage: " + wattage + "\n" + "Colour: " + colour + "\n" + "Price ($): " + price + "\n";
        }
    }



}
