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
                foreach (Carta.ePalos palo in Enum.GetValues(typeof(Carta.ePalos)))
                    cartaList.Add(new Carta(palo, i));
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
            for (int i = cartaList.Count - 1; i > 0; i--)
            {
                int j = rng.Next(i + 1);
                Carta c = cartaList[i];
                cartaList[i] = cartaList[j];
                cartaList[j] = c;
            }
            //cartaList = cartaList.OrderBy(_ => rng.Next()).ToList();
        }

        public Carta RobarN(int n)
        {
            if (n-1 < cartaList.Count() && n>0)
            {
                Carta c = cartaList[(n - 1)];
                cartaList.Remove(c);
                return c;
            }
            else
                return null;
        }

        public int Cantidad()
        {
            return cartaList.Count;
        }
    }
}
