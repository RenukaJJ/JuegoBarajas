using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barajas
{
    public class Baraja
    {
        private List<Carta> cartaList;  

        public List<Carta> Cartas { 
            get {  return cartaList; } 
            set {  cartaList = value; }  
        }
        public Baraja() { }
    }
}
