using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oefDemotica
{
    class PLC
    {
        public Verwarming Chauffage { get; set; }
        public Lichten SalonLichten { get; set; }

        public void DoeLichtenAan()
        {
            SalonLichten.Power = true;
        }

        public void DoeLichtenUit()
        {
            SalonLichten.Power = false;
        }

        public void PasTemperatuurAan(double graden)
        {
            Chauffage.Graden = graden;
        }

        public void ZetVerwarmingAf()
        {
            Chauffage.Power = false;
        }

        public void ZetVerwarmingOp()
        {
            Chauffage.Power = true;
        }
    }
}
