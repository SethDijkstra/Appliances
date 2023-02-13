using System;

namespace Appliances
{
    class Dishwasher : Appliance
    {
        public string Sound { get; set; }
        public string Feature { get; set; }

        public Dishwasher(int itemNum, string brand, int quantity, int wattage, string colour, double price, string feature, string sound)
            : base(itemNum, brand, quantity, wattage, colour, price)
        {
            Sound = sound;
            Feature = feature;
        }

        public override string ToString()
        {
            return base.ToString() + $"Sound Rating: {Sound}\nFeature and Finish: {Feature}\n";
        }

        public override string FileFormat()
        {
            return base.FileFormat() + $"{Sound};{Feature}";
        }
    }
}
