using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio10
{
    public static class PersonaExtension
    {
        public static IEnumerable<VeicoloPosseduto> VeicoliPosseduti(this Persona proprietario, List<Veicolo> elencoVeicoli)
        {
            int id = proprietario.ID;

            var veicoli =
                (from v in elencoVeicoli
                 where v.ID == id
                 select new VeicoloPosseduto { ID = v.ID, Prezzo = v.Prezzo, Targa = v.Targa }).ToList();

            return veicoli;

        }
    }
}
