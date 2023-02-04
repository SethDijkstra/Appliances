using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appliances
{
    class AppDriver
    {
        public List<Appliance> employees = new List<Appliance>();

        private void loadingFile()
        {
            string filepath = @"C:\Users\Seth\source\repos\Appliances\Appliances\appliances.txt";
            string[] lines = File.ReadAllLines(filepath);
        }
    }
}
