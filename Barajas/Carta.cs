using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barajas
{
    public class Carta
    {
        public enum ePalos
        {
            Oros,   
            Copas,
            Espadas,
            Bastos,
        }

        private int numero;
        private string palo;

        public string Palo
        {
            get {  return palo; } 
            set { palo = value; }
        }

        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        public Carta(string p, int n) 
        { 
            this.palo = p;
            this.numero = n;
        }
    }
}
