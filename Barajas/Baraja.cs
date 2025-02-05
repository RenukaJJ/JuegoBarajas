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
        private static Random rng = new Random();

        public List<Carta> Cartas 
        { 
            get {  return cartaList; } 
        }

        public Baraja() 
        {
            cartaList = new List<Carta> { };
            for (int i = 1; i < 11; i++)
            {
                foreach (string name in Enum.GetNames(typeof(Carta.ePalos)))
                    cartaList.Add(new Carta(name, i));
            }
        }

        public string MostrarBaraja() 
        {
            string resultado = "";
            for (int i = 0; i < cartaList.Count; i++)
                resultado += ($"{i+1} - {cartaList[i].Numero} de {cartaList[i].Palo} \n");
            return resultado;
        }

        public void Barajar() 
        {
            cartaList = cartaList.OrderBy(_ => rng.Next()).ToList();
        }

        public void Robar()
        {
            cartaList.RemoveRange(0, 1);
        }

        public void RobarRandom()
        {
            cartaList.RemoveRange(rng.Next(cartaList.Count()), 1);
        }

        public bool RobarN(int n)
        {
            if (n < cartaList.Count())
            {
                cartaList.RemoveRange((n-1),1);
                return true;
            }
            else
                return false;
            
        }
    }
}
