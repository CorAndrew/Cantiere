using Cantiere.Cantiere;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cantiere
{
    internal class Program
    {
        private static List<Macchinario> parcoMacchine = new List<Macchinario>();

        static void Main(string[] args)
        {
            bool esci = false;
            while (!esci)
            {
                Console.WriteLine("1. Visualizza macchinari liberi");
                Console.WriteLine("2. Visualizza descrizione di tutti i macchinari");
                Console.WriteLine("3. Assegna macchinario a un cantiere");
                Console.WriteLine("4. Libera macchinario da un cantiere");
                Console.WriteLine("5. Operazioni specifiche macchinario");

                string scelta = Console.ReadLine();
                Console.WriteLine();

                switch (scelta)
                {
                    case "1": VisualizzaInParcheggio(); break;
                    case "2": VisualizzaDescrizioni(); break;
                    case "3": AssegnaMacchinario(); break;
                    case "4": LiberaMacchinario(); break;
                    case "5": GestisciOperazioniSpecifiche(); break;
                    case "0": esci = true; break;
                    default: Console.WriteLine("Opzione non valida"); break;
                }
            }
        }

        private static void VisualizzaInParcheggio()
        {
            Console.WriteLine("macchinari pronti e disponibili");
            foreach (var m in parcoMacchine)
            {
                if (!m.IsOccupato)
                {
                    Console.WriteLine(m.Descrizione());
                }
            }
        }

        private static void VisualizzaDescrizioni()
        {
            Console.WriteLine("tutti i macchinari");
            for (int i = 0; i < parcoMacchine.Count; i++)
            {
                Console.WriteLine($"[{i}] {parcoMacchine[i].Descrizione()}");
            }
        }

        private static void AssegnaMacchinario()
        {
            VisualizzaDescrizioni();
            Console.WriteLine("Inserisci l'indice del macchinario da assegnare: ");
            if (int.TryParse(Console.ReadLine(), out int idx) && idx >= 0 && idx < parcoMacchine.Count)
            {
                if (parcoMacchine[idx].AssegnaACantiere())
                    Console.WriteLine("Macchinario assegnato con successo al cantiere");
                else
                    Console.WriteLine("Il macchinario è già occupato");
            }
        }

        private static void LiberaMacchinario()
        {
            VisualizzaDescrizioni();
            Console.WriteLine("inserisci l'indice del macchinario da liberare: ");
            if (int.TryParse(Console.ReadLine(), out int idx) && idx >= 0 && idx < parcoMacchine.Count)
            {
                if (parcoMacchine[idx].Libera())
                    Console.WriteLine("Macchinario liberato e riportato in parcheggio");
                else
                    Console.WriteLine("Il macchinario era già libero");
            }
        }

        private static void GestisciOperazioniSpecifiche()
        {
            VisualizzaDescrizioni();
            Console.WriteLine("Seleziona il macchinario su cui operare: ");
            if (int.TryParse(Console.ReadLine(), out int idx) && idx >= 0 && idx < parcoMacchine.Count)
            {
                Macchinario m = parcoMacchine[idx];

                if (m is Ruspa ruspa)
                {
                    Console.Write("Inserisci nuova dimensione benna (300, 500, 700, 1000, 1500, 2000 mm): ");
                    if (int.TryParse(Console.ReadLine(), out int dim) && ruspa.CambiaBenna(dim))
                        Console.WriteLine("Benna sostituita correttamente.");
                    else
                        Console.WriteLine("Dimensione non valida");
                }
                else if (m is Gru gru)
                {
                    Console.WriteLine("1. Aumenta altezza (+1m)\n2. Diminuisci altezza (-1m)");
                    string op = Console.ReadLine();
                    if (op == "1")
                    {
                        gru.AumentaAltezza();
                        Console.WriteLine("Altezza aumentata");
                    }
                    else if (op == "2" && gru.DiminuisciAltezza())
                    {
                        Console.WriteLine("Altezza diminuita");
                    }
                    else
                    {
                        Console.WriteLine("Operazione non valida o altezza minima raggiunta");
                    }
                }
                else if (m is Betoniera betoniera)
                {
                    Console.WriteLine("1. Carica cemento\n2. Versa cemento");
                    string op = Console.ReadLine();
                    Console.Write("Inserisci quantità in m³: ");
                    if (double.TryParse(Console.ReadLine(), out double qta))
                    {
                        if (op == "1" && betoniera.CaricaCemento(qta))
                            Console.WriteLine("Cemento caricato");
                        else if (op == "2" && betoniera.VersaCemento(qta))
                            Console.WriteLine("Cemento versato");
                        else
                            Console.WriteLine("Quantità non consentita");
                    }
                }
            }
        }
    }
}