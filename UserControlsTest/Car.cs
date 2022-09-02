using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserControlsTest
{
    class Car
    {
        public string Brand { get; set; }
        public short ProductionYear { get; set; }
        public Car() { }
        public Car(string brand, short productionYear)
        {
            Brand = brand;
            ProductionYear = productionYear;
        }
        public override string ToString()
        {
            return "Марка: " + Brand + "\n"
                + "Год выпуска: " + ProductionYear;
        }
    }
}
