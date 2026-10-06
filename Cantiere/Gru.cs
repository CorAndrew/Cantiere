using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cantiere
{
    namespace Cantiere
    {
        public class Gru : Macchinario
        {
            public double PortataMassima { get; set; }
            public int AltezzaLavoro { get; private set; }

            public Gru(string targa, string modello, int annoProduzione, double volumeSerbatoio, double portataMassima, int altezzaIniziale) : base(targa, modello, annoProduzione, volumeSerbatoio)
            {
                PortataMassima = portataMassima;
                AltezzaLavoro = altezzaIniziale > 0 ? altezzaIniziale : 1;
            }

            public void AumentaAltezza()
            {
                AltezzaLavoro += 1;
            }

            public bool DiminuisciAltezza()
            {
                if (AltezzaLavoro > 1)
                {
                    AltezzaLavoro -= 1;
                    return true;
                }
                return false;
            }

            public override string Descrizione()
            {
                return base.Descrizione() + $" | Portata: {PortataMassima} t | Altezza: {AltezzaLavoro} m";
            }
        }
    }
}
