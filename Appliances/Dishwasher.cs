using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appliances
{
    // Class for Dishwasher appliances
    class Dishwasher : Appliance
    {
        // Private fields for the sound rating and features/finish of the dishwasher
        private string sound;
        private string feature;

        // Constructor for Dishwasher class that takes in parameters for item number, brand, quantity, wattage, colour, price, feature, and sound
        // The constructor calls the base constructor of the Appliance class and sets the values of the private fields sound and feature
        public Dishwasher(int itemNum, string brand, int quantity, int wattage,
            string colour, double price, string feature, string sound) :
            base(itemNum, brand, quantity, wattage, colour, price)
        {
            // Setting the value of the private field sound
            this.sound = sound;
            // Setting the value of the private field feature
            this.feature = feature;
        }

        // Method to get the sound rating of the dishwasher
        public string getSound()
        {
            // Returns the value of the private field sound
            return sound;
        }
        // Method to get the features/finish of the dishwasher
        public string getFeature()
        {
            // Returns the value of the private field feature
            return feature;
        }
        // Method to set the sound rating of the dishwasher
        public void setSound(string sound)
        {
            // Sets the value of the private field sound
            this.sound = sound;
        }
        // Method to set the features/finish of the dishwasher
        public void setFeature(string feature)
        {
            // Sets the value of the private field feature
            this.feature = feature;
        }

        // Overridden method to return the information about the Dishwasher as a string
        public override string ToString()
        {
            // Returns a string with information about the Dishwasher and its properties
            // The information includes the information returned by the ToString() method of the base class (Appliance)
            return base.ToString() +
                // The sound rating of the dishwasher
                " Sound Rating: " + sound +
                // The features and finish of the dishwasher
                " Feature and Finish: " + feature;
        }
    }
}
