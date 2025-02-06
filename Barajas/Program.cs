using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;
using Barajas;

namespace JuegoBarajas
{
    internal class Program
    {
        static Baraja miBaraja;
        static List<Jugador> Jugadores = new List<Jugador>();
        private static Random rng = new Random();
        static void Main(string[] args)
        {
            CrearBaraja();
            Menu();
        }

        static void Menu() 
        {
            Console.WriteLine(@"Menu:
1. mostrar cartas
2. barajar
3. robar primera
4. robar posicion n
5. robar random
6. Jugar Partida
7. Iniciar la baraja ordenada");

            while (true)
            {
                switch (ConvertStringInt("indica opcion del menu "))
                {
                    case 0:
                        return;
                    case 1:
                        Console.WriteLine(miBaraja.MostrarBaraja());
                        break;
                    case 2:
                        Barajar();
                        break;
                    case 3:
                        Robar();
                        break;
                    case 4:
                        RobarN();
                        break;
                    case 5:
                        RobarRandom();
                        break;
                    case 6:
                        JugarPartida();
                        break;
                    case 7:
                        CrearBaraja();
                        break;
                    default:
                        break;
                }

            }
        }

        static void CrearBaraja() //
        {   
            miBaraja = new Baraja();
        }

        static void Barajar()
        {
            miBaraja.Barajar();
            Console.WriteLine(miBaraja.MostrarBaraja());
        }

        static void Robar()
        {
            miBaraja.RobarN(0);
            Console.WriteLine(miBaraja.MostrarBaraja());
        }

        static void RobarRandom()
        {
            miBaraja.RobarN(rng.Next(1, miBaraja.Cantidad()));
            Console.WriteLine(miBaraja.MostrarBaraja());
        }

        static void RobarN()
        {
            if (miBaraja.RobarN(ConvertStringInt("Introduce la posicion de la carta a robar: "))!=null)
                Console.WriteLine(miBaraja.MostrarBaraja());
            else
                Console.WriteLine("indice fuera del margen");
        }

        static void JugarPartida()
        {
            int numJugadores = ConvertStringInt("Indica el numero de jugadores entre 2 y 5: ");
            if (numJugadores > 1 && numJugadores <= 5)
            {
                //inicia lista de jugadores 
                for (int i = 0; i < numJugadores; i++)
                    Jugadores.Add(new Jugador());

                int numRondas = miBaraja.Cartas.Count() / numJugadores;

                for (int i = 0; i < numRondas; i++)
                {
                    Console.WriteLine("------");

                    //asignar cartas a cada jugador
                    List<Carta> cartasPartida = new List<Carta>();
                    for (int j = 0; j < numJugadores; j++)
                    {
                        Carta c = miBaraja.RobarN(1);
                        cartasPartida.Add(c);
                        Console.WriteLine($"Jugador {j}: {c.Numero} de {c.Palo}");
                    }

                    //asignar cartas al ganador de la partida
                    int ganadorRonda = GanadorRonda(cartasPartida);
                    Jugadores[ganadorRonda].AddCartas(cartasPartida);
                    Console.WriteLine($"El ganador de la ronda {i}, es el Jugador {ganadorRonda}");
                }

                List<Jugador> ranking = Jugadores.OrderByDescending(x => x.CartasCount).ToList();
                int ganadorPartida = Jugadores.IndexOf(ranking[0]);
                Console.WriteLine($"El ganador es el jugador {ganadorPartida}");
            }
            else
                Console.WriteLine("exceso de numero de jugadores");
        }

        static int GanadorRonda(List<Carta> cartasjugada)
        {
            Carta cartaGanadora = cartasjugada
                .OrderByDescending(c => c.Numero)
                .ThenByDescending(c => c.Palo)
                .First();
            return cartasjugada.IndexOf(cartaGanadora);
        }

        static int ConvertStringInt(string pregunta)
        {
            int number;
            while (true)
            {
                Console.Write(pregunta);
                if (!int.TryParse(Console.ReadLine(), out number))
                    Console.WriteLine("Convertion failed. Introduce un numero valido.");
                else
                    return number;
            }
        }
    }
}
