using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appliances
{
    class Dishwasher : Appliance
    {
        private string sound;
        private string feature;

        public Dishwasher(int itemNum, string brand, int quantity, int wattage,
            string colour, double price, string feature, string sound) :
            base(itemNum, brand, quantity, wattage, colour, price)
        {
            this.sound = sound;
            this.feature = feature;
        }

        public string getSound()
        {
            return sound;
        }
        public string getFeature()
        {
            return feature;
        }
        public void setSound(string sound)
        {
            this.sound = sound;
        }
        public void setFeature(string feature)
        {
            this.feature = feature;
        }

        public override string ToString()
        {
            return "Sound Rating: " + sound +
                "Feature and Finish: " + feature;
        }
    }
}
