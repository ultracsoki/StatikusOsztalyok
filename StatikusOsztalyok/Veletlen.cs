using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Remoting.Messaging;

namespace StatikusOsztalyok
{
    internal static class Veletlen
    {
        public enum NEM
        {
            FERFI,
            NO
        }
        private static int[] telefonszamok = new int[] {20,30,70};
        //private string nev;
        private static Random RND = new Random();

        private static List<string> VEZETEKNEVEK = Feltolt("files/veznev.txt");
        private static List<string> FERFI_KERESZTNEVEK = Feltolt("files/ferfikernev.txt");
        private static List<string> NOI_KERESZTNEVEK = Feltolt("files/noikernev.txt");

        private static List<string> Feltolt(string fajlnev)
        {
            List<string> lista = new List<string>();

            using (StreamReader sr = new StreamReader(fajlnev))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    lista.Add(line);
                }
            }
            return lista;
            //return File.ReadAllLines(fajlnev).ToList();
        }

        public static int VelEgesz(int min, int max)
        {
            return RND.Next(min, max + 1);
        }

        public static char VelKarakter(char min, char max)
        {
            return (char)VelEgesz(min, max);
        }

        public static string VelVezetekNev()
        {
            return VEZETEKNEVEK[RND.Next(VEZETEKNEVEK.Count)];
        }

        public static string VelKeresztNev(NEM nem)
        {
            if (nem == NEM.FERFI)
            {
                return VelFerfiKer();
            }
            else
            {
                return VelNoiKer();
            }
        }

        private static string VelFerfiKer()
        {
            return FERFI_KERESZTNEVEK[RND.Next(FERFI_KERESZTNEVEK.Count)];
        }

        private static string VelNoiKer()
        {
            return NOI_KERESZTNEVEK[RND.Next(NOI_KERESZTNEVEK.Count)];
        }

        public static string VelTeljesNev(NEM nem)
        {
            return $"{VelVezetekNev()} {VelKeresztNev(nem)}";
        }

        public static string VelDatum(int ev1, int ev2)
        {
            int ev = RND.Next(ev1, ev2 + 1);
            int honap = RND.Next(1, 13);
            int nap = 0;
            if (honap % 2 != 0)
            {
                nap = RND.Next(1, 32);
            }
            else if (honap % 2 == 0)
            {
                nap = RND.Next(1, 31);
            }
            else
            {
                nap = RND.Next(1, 29);
            }
            return $"{ev}-{honap}-{nap}";
        }

        public static string VelEmail(string nev)
        {
            return $"{nev.ToLower().Replace('á','a').Replace('é', 'e').Replace('í', 'i').Replace('ó', 'o').Replace('ő', 'ö').Replace('ű', 'ü').Replace('ú', 'u')}{RND.Next(1, 100)}@gmail.com";
        }

        public static string VelMobil()
        {
            int random = telefonszamok[RND.Next(telefonszamok.Length)];
            switch (random)
            {
                case 20:
                    return $"+36 (20) {RND.Next(0, 1000)}-{RND.Next(0, 100)}-{RND.Next(0, 100)})";
                case 30:
                    return $"+36 (30) {RND.Next(0, 1000)}-{RND.Next(0, 100)}-{RND.Next(0, 100)})";
                case 70:
                    return $"+36 (70) {RND.Next(0, 1000)}-{RND.Next(0, 100)}-{RND.Next(0, 100)})";
                default:
                    return $"+36 (##) {RND.Next(0, 1000)}-{RND.Next(0, 100)}-{RND.Next(0, 100)})";
            }
            
        }

        public static string VelSportag()
        {
            List<string> SPORTAGAK = Feltolt("files/sportag.txt");

            return SPORTAGAK[RND.Next(SPORTAGAK.Count)];
        }

        public static string VelSportEgyesulet()
        {
            List<string> EGYESULETEK = Feltolt("files/egyesulet.txt");

            return EGYESULETEK[RND.Next(EGYESULETEK.Count)];
        }
    }
}
