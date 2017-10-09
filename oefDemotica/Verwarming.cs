using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oefDemotica
{
    class Verwarming
    {
        private double graden;

        public bool Power { get; set; }
        public double Graden { get => graden;
            set {
                if (Power) graden = value;
            }
        }

        public double InFahrenheit()
        {
            return Graden * 9 / 5 + 32;
        }
    }
}
