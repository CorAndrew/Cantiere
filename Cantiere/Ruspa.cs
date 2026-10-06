using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Cantiere
{
    public class Ruspa : Macchinario
    {
        private static readonly int[] DimensioniConsentite = { 300, 500, 700, 1000, 1500, 2000 };
        public int DimensioneBenna { get; private set; }

        public Ruspa(string targa, string modello, int annoProduzione, double volumeSerbatoio, int dimensioneBenna) : base(targa, modello, annoProduzione, volumeSerbatoio)
        {
            if (DimensioniConsentite.Contains(dimensioneBenna))
                DimensioneBenna = dimensioneBenna;
            else
                DimensioneBenna = 300; // Valore di default
        }

        public bool CambiaBenna(int nuovaDimensione)
        {
            if (DimensioniConsentite.Contains(nuovaDimensione))
            {
                DimensioneBenna = nuovaDimensione;
                return true;
            }
            return false;
        }

        public override string Descrizione()
        {
            return base.Descrizione() + $" | Benna: {DimensioneBenna} mm";
        }
    }
}