using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanFormatter
{
    class Program
    {
        static void Main(string[] args)
        {
            bool go;
            var romanFormatter = new RomanFormatter();
            do
            {
                Console.WriteLine("Veuillez saisir un en entier à convertir en chiffres romains ou autre chose pour sortir");
                go = int.TryParse(Console.ReadLine(), out int value);
                if (go)
                    Console.WriteLine(string.Format(romanFormatter, "Entier saisi:{0}, en chiffres romains: {0:Roman}", value));
            }
            while (go);
        }
    }
}
