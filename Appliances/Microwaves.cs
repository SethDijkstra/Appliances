using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appliances
{
    //Creating new subclass Microwaves from base class Appliance
    class Microwaves : Appliance
    {
        //Adds two new attributes to subclass
        private double capacity;
        private string room;

        /*Constructor that calls superclass constructor and adds the two new
         microwaves attributes*/
        public Microwaves(int itemNum, string brand, int quantity, int wattage,
            string colour, double price, double capacity, string room ) :
            base(itemNum, brand, quantity, wattage, colour, price)
        {
            this.capacity = capacity;
            this.room = room;
        }

        //Getters for all fields
        public double getCapacity()
        {
            return capacity;
        }
        public string getRoom()
        {
            return room;
        }
        
        //Setters for all fields
        public void setCapacity(double capacity)
        {
            this.capacity = capacity;
        }
        public void setRoom( string room )
        {
            this.room = room;
        }

        /*Returns a formatted string for file output containing attributes from base
         class and adds two from subclass*/
        public override string fileFormat()
        {
            return base.fileFormat() +
                this.capacity + ";" +
                this.room;
        }

        //Returns a formatted string representation of subclass.
        public override string ToString()
        {
            return base.ToString() + "Capacity: " + capacity + "\n"  + "Room Type: " + room + "\n";
        }




    }
}
