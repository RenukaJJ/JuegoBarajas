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
            Oros=0,   
            Copas=1,
            Espadas=2,
            Bastos=3,
        }

        private int numero;
        private ePalos palo;

        public ePalos Palo
        {
            get {  return palo; } 
            set { palo = value; }
        }

        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        public Carta(ePalos p, int n) 
        { 
            this.palo = p;
            this.numero = n;
        }
    }
}
