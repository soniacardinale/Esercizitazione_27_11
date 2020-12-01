using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio10
{
    public class Veicolo
    {
        public int ID { get; set; }
        public  string Targa { get; set; }
        public int  Peso { get; set; }
        public string Colore { get; set; }
        public double Prezzo { get; set; }
        public int IDProprietario { get; set; }
    }
}
