using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio10
{
    public class Esecizio
    {
      
        public static List<Persona> CreateListPersona()
       {
            List<Persona> lista = new List<Persona>
            {
            new Persona{ID=1, Nome="Marco", Cognome="Bianchi", Nazione="Italiana"},
            new Persona{ID=2, Nome="Jhon", Cognome="Smith", Nazione= "Americana"},
            new Persona{ID=3, Nome="Sarah", Cognome="Amber", Nazione= "Tedesca"}
            };

            return lista;
       }

        public static List<Veicolo> CreateListVeicoli()
       {
            List<Veicolo> lista = new List<Veicolo>
             {
            new Veicolo{ID=1, Peso=200, Colore="Rosso", Prezzo = 11000.20, Targa = "AA000CC", IDProprietario=2 },
            new Veicolo{ID=2, Peso=300, Colore="Rosso", Prezzo = 15000.40, Targa = "BB000DD", IDProprietario=1},
            new Veicolo{ID=3, Peso=300, Colore="Nero", Prezzo = 35000.99, Targa = "EE000FF", IDProprietario=1}
             };
            return lista;
       }

        public static void CountByColour()
        {
            var lst_Veicoli = CreateListVeicoli();
            var carByColour = lst_Veicoli
                .GroupBy(p => p.Colore)
                .Select(lista => new { Colore= lista.Key, Quantities = lista.Count() });

            foreach (var item in carByColour)
            {
                Console.WriteLine("{0} n° {1}", item.Colore, item.Quantities);
            }
           

        }

        public static void PesoPrezzoByPerson()
        {
            var lst_Persone = CreateListPersona();
            var lst_Veicoli = CreateListVeicoli();


            //var lst_pesoprezzo = lst_Persone
            //    .GroupJoin(lst_Veicoli, p => p.ID, v => v.IDProprietario,
            //    (p, v) => new { Proprietario = p.Nome, Peso = v.Sum(o => o.Peso), Prezzo = v.Average(o => o.Prezzo) });

            var lst_pesoprezzo =   
               from o in lst_Veicoli
               group o by o.IDProprietario
               into cl
               select new { IDProprietario = cl.Key, Peso = cl.Sum(o => o.Peso), Prezzo = cl.Average(o => o.Prezzo) }
               into cl1
              join p in lst_Persone
              on cl1.IDProprietario equals p.ID
                select new { Proprietario = p.Nome, Peso = cl1.Peso, Prezzo = cl1.Prezzo}; //così non ho errori perchè vede solamente Persone che hanno effettivamente una macchina


            foreach (var item in lst_pesoprezzo)
            {
                Console.WriteLine("{0}, Prezzo Medio: {1}, Peso Totale: {2}", item.Proprietario, item.Prezzo, item.Peso);
            }
        }

        public static void ExMethod()
        {
            var lst_veicoli = CreateListVeicoli();
            Persona p1 = new Persona { ID = 1, Nome = "Marco", Cognome = "Bianchi", Nazione = "Italiana" };
            List<VeicoloPosseduto> veicoliPossiduti = p1.VeicoliPosseduti(lst_veicoli);
            var numVeicoli_p1 = veicoliPossiduti.Count;
            Console.WriteLine($"\n \n Il proprietario {p1.ID} ha {numVeicoli_p1} veicoli: \n");
            foreach (var v in veicoliPossiduti)
            {
                Console.WriteLine($"prezzo: {v.Prezzo} e a targa: {v.Targa}");

            }
        }





    }
}
