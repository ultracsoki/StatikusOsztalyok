using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatikusOsztalyok
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Veletlen veletlen = new Veletlen();

            Console.WriteLine(Veletlen.VelEgesz(5,10));

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(Veletlen.VelKarakter('A', 'Z'));
            }

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(Veletlen.VelTeljesNev(Veletlen.NEM.FERFI));
                Console.WriteLine(Veletlen.VelTeljesNev(Veletlen.NEM.NO));
            }

            Console.WriteLine("\n------------------------------------------------\n");
            Console.WriteLine(Veletlen.VelDatum(2004,2023));
            Console.WriteLine(Veletlen.VelEmail(Veletlen.VelVezetekNev() + Veletlen.VelKeresztNev(Veletlen.NEM.FERFI)));
            Console.WriteLine(Veletlen.VelMobil());
            Console.WriteLine(Veletlen.VelSportag());
            Console.WriteLine(Veletlen.VelSportEgyesulet());

            Console.ReadKey();
        }
    }
}
