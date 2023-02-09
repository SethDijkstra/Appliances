using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appliances
{
    class Microwaves : Appliance
    {
        private double capacity;
        private string room;

        public Microwaves(int itemNum, string brand, int quantity, int wattage,
            string colour, double price, double capacity, string room ) :
            base(itemNum, brand, quantity, wattage, colour, price)
        {
            this.capacity = capacity;
            this.room = room;
        }

        public double getCapacity()
        {
            return capacity;
        }
        public string getRoom()
        {
            return room;
        }
        
        public void setCapacity(double capacity)
        {
            this.capacity = capacity;
        }
        public void setRoom( string room )
        {
            this.room = room;
        }
        public override string fileFormat()
        {
            return base.fileFormat() +
                this.capacity + ";" +
                this.room;
        }
        public override string ToString()
        {
            return base.ToString() +
                String.Format("Capacity: {0,-12} Room Type: {1,-15}", capacity, room);
        }
        
        



    }
}
