using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appliances
{
    //Creating new subclass Dishwasher from base class Appliance
    class Dishwasher : Appliance
    {
        //Adds two new attributes to subclass
        private string sound;
        private string feature;

        /*Constructor that calls the superclass constructor and adds two new 
         dishwasher attributes*/
        public Dishwasher(int itemNum, string brand, int quantity, int wattage,
            string colour, double price, string feature, string sound) :
            base(itemNum, brand, quantity, wattage, colour, price)
        {
            this.sound = sound;
            this.feature = feature;
        }

        //Getters for all fields
        public string getSound()
        {
            return sound;
        }
        public string getFeature()
        {
            return feature;
        }

        //Setters for all fields
        public void setSound(string sound)
        {
            this.sound = sound;
        }
        public void setFeature(string feature)
        {
            this.feature = feature;
        }

        /*Returns a formatted string for file output containing attributes from base
         class and adds two from subclass*/
        public override string fileFormat()
        {
            return base.fileFormat() +
                this.sound + ";" +
                this.feature;
        }

        //Returns a formatted string representation of subclass.
        public override string ToString()
        {
            return base.ToString() + "Sound Rating: " + sound + "\n" + "Feature and Finish: " + feature + "\n";
        }

    }
}
