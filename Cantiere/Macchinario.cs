using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cantiere
{
    public abstract class Macchinario : IAssegnabile
    {
        public string Targa { get; set; }
        public string Modello { get; set; }
        public int AnnoProduzione { get; set; }
        public double VolumeSerbatoio { get; set; }
        public bool IsOccupato { get; protected set; }

        public Macchinario(string targa, string modello, int annoProduzione, double volumeSerbatoio)
        {
            Targa = targa;
            Modello = modello;
            AnnoProduzione = annoProduzione;
            VolumeSerbatoio = volumeSerbatoio;
            IsOccupato = false;
        }

        public bool AssegnaACantiere()
        {
            if (IsOccupato) return false;
            IsOccupato = true;
            return true;
        }

        public bool Libera()
        {
            if (!IsOccupato) return false;
            IsOccupato = false;
            return true;
        }

        public virtual string Descrizione()
        {
            string stato = IsOccupato ? "Assegnato a cantiere" : "Disponibile in parcheggio";
            return $"Targa: {Targa} | Modello: {Modello} | Anno: {AnnoProduzione} | Serbatoio: {VolumeSerbatoio}L | Stato: {stato}";
        }
    }
}
