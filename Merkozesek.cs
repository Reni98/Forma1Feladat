using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forma1Projekt
{
    internal class Merkozesek
    {
        public string helyszin;
        public string palyatipus;
        public int rajtszam;
        public int helyezes;
        public bool gyozelem;
        public DateTime datum;


        public Merkozesek(string helyszin, string palyatipus, string rajtszam, string helyezes, string gyozelem, string datum)
        {
            this.helyszin = helyszin;
            this.palyatipus = palyatipus;
            this.rajtszam = int.Parse(rajtszam);
            this.helyezes = int.Parse(helyezes);
            this.gyozelem = bool.Parse(gyozelem);
            this.datum = DateTime.Parse(datum);
        }
    }
}
