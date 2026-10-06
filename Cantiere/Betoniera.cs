using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cantiere
{
    namespace Cantiere
    {
        public class Betoniera : Macchinario
        {
            public double CapacitaMassimaCemento { get; set; }
            public double CementoAttuale { get; private set; }

            public Betoniera(string targa, string modello, int annoProduzione, double volumeSerbatoio, double capacitaMassimaCemento) : base(targa, modello, annoProduzione, volumeSerbatoio)
            {
                CapacitaMassimaCemento = capacitaMassimaCemento;
                CementoAttuale = 0;
            }

            public bool CaricaCemento(double quantita)
            {
                if (quantita <= 0 || CementoAttuale + quantita > CapacitaMassimaCemento)
                    return false;

                CementoAttuale += quantita;
                return true;
            }

            public bool VersaCemento(double quantita)
            {
                if (quantita <= 0 || quantita > CementoAttuale)
                    return false;

                CementoAttuale -= quantita;
                return true;
            }

            public override string Descrizione()
            {
                return base.Descrizione() + $" | Cemento: {CementoAttuale}/{CapacitaMassimaCemento} m³";
            }
        }
    }
}
