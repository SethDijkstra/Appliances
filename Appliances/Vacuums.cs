using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appliances
{
    class Vacuums : Appliance
    {
        private string grade;
        private double voltage;

        public Vacuums(int itemNum, string brand, int quantity, int wattage,
            string colour, double price, string grade, double voltage) :
            base(itemNum, brand, quantity, wattage, colour, price)
        {
            this.grade = grade;
            this.voltage = voltage;
        }

        public string getGrade()
        {
            return grade;
        }

        public double getVoltage()
        {
            return voltage;
        }

        public void setGrade(string grade)
        {
            this.grade = grade;
        }

        public void setVoltage(double voltage)
        {
            this.voltage = voltage;
        }

        public override string fileFormat()
        {
            return base.fileFormat() + ";" +
                this.grade + ";" +
                this.voltage;
        }

        public override string ToString()
        {
            return base.ToString() +
                String.Format("Grade: {0,-15} Voltage: {1,-15}", grade, voltage);
        }

    }
}
