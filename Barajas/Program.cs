using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Barajas;

namespace JuegoBarajas
{
    internal class Program
    {
        static Baraja miBaraja;
        static void Main(string[] args)
        {
            CraerBaraja();
            Menu();
        }

        static void Menu() 
        {
            Console.WriteLine(@"Menu:
1. mostrar cartas
2. barajar
3. robar primera
4. robar posicion n
5. robar random");

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
                    default:
                        break;
                }

            }
        }
        static void CraerBaraja() //
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
            miBaraja.Robar();
            Console.WriteLine(miBaraja.MostrarBaraja());
        }

        static void RobarRandom()
        {
            miBaraja.RobarRandom();
            Console.WriteLine(miBaraja.MostrarBaraja());
        }

        static void RobarN()
        {
            if (miBaraja.RobarN(ConvertStringInt("Introduce la posicion de la carta a robar: ")))
                Console.WriteLine(miBaraja.MostrarBaraja());
            else
                Console.WriteLine("indice fuera del margen");
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
