using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appliances
{
    //Creating new subclass Vacuums from base class Appliance
    class Vacuums : Appliance
    {
        //Adds two new attributes to subclass
        private string grade;
        private double voltage;

        /*Constructor that calls superclass constructor and adds the two new
         microwaves attributes*/
        public Vacuums(int itemNum, string brand, int quantity, int wattage,
            string colour, double price, string grade, double voltage) :
            base(itemNum, brand, quantity, wattage, colour, price)
        {
            this.grade = grade;
            this.voltage = voltage;
        }

        //Getters for all fields
        public string getGrade()
        {
            return grade;
        }

        public double getVoltage()
        {
            return voltage;
        }

        //Setters for all fields
        public void setGrade(string grade)
        {
            this.grade = grade;
        }

        public void setVoltage(double voltage)
        {
            this.voltage = voltage;
        }

        /*Returns a formatted string for file output containing attributes from base
         class and adds two from subclass*/
        public override string fileFormat()
        {
            return base.fileFormat() +
                this.grade + ";" +
                this.voltage;
        }

        //Returns a formatted string representation of subclass.
        public override string ToString()
        {
            return base.ToString() + "Grade: " + grade + "\n" + "Voltage: " + voltage + "\n";
        }
    }
}
