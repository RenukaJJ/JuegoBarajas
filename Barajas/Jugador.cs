using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barajas
{
    public class Jugador
    {
        private List<Carta> Mazo;
        private int NumeroCartas;

        public int CartasCount
        {
            get { return NumeroCartas; }
        }

        public void AddCartas(List<Carta> cartas)
        {
            Mazo.AddRange(cartas);
            NumeroCartas=Mazo.Count;
        }

        public Jugador() 
        {
            this.Mazo = new List<Carta> { };
            this.NumeroCartas = 0;
        }
    }
}
