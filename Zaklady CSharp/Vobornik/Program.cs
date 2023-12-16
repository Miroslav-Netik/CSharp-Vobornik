using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Vobornik
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello world");

            //Console.Write("Zadej sve jmeno: ");
            //string jmeno = Console.ReadLine();
            //Console.WriteLine(jmeno);
            //Console.WriteLine(" Scitanim -> Ahoj " + jmeno +"!");
            //Console.WriteLine(" Parametricky -> Ahoj {0}!", jmeno);
            //Console.WriteLine($" Parametricky $ -> Ahoj {jmeno}!");

            // Ctrl + k + c - koment, ctrl + k + u - unkoment

            // Ciselny vstup a format vystupu

            //int a = Convert.ToInt32(Console.ReadLine());

            //// Nacteni ciselne hodnoty s zachycenim pripadne vyjimky
            //try
            //{
            //    int d = Convert.ToInt32(Console.ReadLine());
            //    // je nastaveno - prevod na cislo byl uspesny
            //}
            //catch (Exception)
            //{
            //    // neni nastaveno - prevod na cislo se nazdaril
            //    throw;
            //}

            //// Nacteni ciselne hodnoty s kontrolou validity
            //string sc = Console.ReadLine();
            //if (int.TryParse(sc, out int c))
            //{
            //    // c je nastaveno - prevod na cislo byl uspesny
            //}
            //else
            //{
            //    // c neni nastaveno - prevod na cislo se nazdaril
            //}

            //// Zadavani se opakuje
            //string se = Console.ReadLine();
            //int e;
            //while (!int.TryParse(se, out e))
            //    se = Console.ReadLine();


            // Operace se dvema cisly

            //int a = Convert.ToInt32(Console.ReadLine());
            //int b = Convert.ToInt32(Console.ReadLine());

            //Console.WriteLine("Soucet = {0}", a + b);
            //Console.WriteLine("Soucin = {0}", a *b);
            //Console.WriteLine("Rozdil = {0}", a - b);
            //Console.WriteLine("Podil = {0}", a / (double)b );
            //Console.WriteLine("Celociselne deleni = {0}", a / b); // div
            //Console.WriteLine("Zbytek po deleni = {0}", a % b); // mod zbytek po deleni
            //Console.WriteLine("Sin(pi/2) = {0}", Math.Sin(Math.PI / 2.0));

            // Vetsi

            //int a = Convert.ToInt32(Console.ReadLine());
            //int b = Convert.ToInt32(Console.ReadLine());

            //if (a == b)
            //{
            //    Console.WriteLine("Jsou si rovna..");
            //}

            //else if (a > b)
            //{
            //    Console.WriteLine("Vetsi je {0}", a);
            //}

            //else
            //{
            //    Console.WriteLine("Vetsi je {0}", a);
            //}

            //// Nejvetsi ze ctyr hodnot
            //int a = Convert.ToInt32(Console.ReadLine());
            //int b = Convert.ToInt32(Console.ReadLine());
            //int c = Convert.ToInt32(Console.ReadLine());
            //int d = Convert.ToInt32(Console.ReadLine());
            //int max = a;
            //if (b > max)
            //{
            //    max = b;
            //}
            //if (c > max)
            //{
            //    max = c;
            //}
            //if (d > max)
            //{
            //    max = d;
            //}
            //Console.WriteLine("Nejvetsi je {0}", max);

            //// Prohozeni dvou promennych
            //int a = Convert.ToInt32(Console.ReadLine());
            //int b = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("{0}, {1}", a, b);
            //int p = a;
            //a = b;
            //b = p;
            //Console.WriteLine("{0}, {1}", a, b);

            //// Cyklicky posun vpred (1, 2, 3 => 2, 3, 1)
            //int a = Convert.ToInt32(Console.ReadLine());
            //int b = Convert.ToInt32(Console.ReadLine());
            //int c = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("{0}, {1}, {2}", a, b, c);
            //int p = a;
            //a = b;
            //b = c;
            //c = p;
            //Console.WriteLine("{0}, {1}, {2}", a, b, c);

            //// Cyklicky posun vzad (1, 2, 3 => 3, 1, 2)
            //int a = Convert.ToInt32(Console.ReadLine());
            //int b = Convert.ToInt32(Console.ReadLine());
            //int c = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("{0}, {1}, {2}", a, b, c);
            //int p = c;
            //c = b;
            //b = a;
            //a = p;
            //Console.WriteLine("{0}, {1}, {2}", a, b, c);

            //// Dokud
            //int i = 1;
            //while (i <= 10)
            //{
            //    Console.WriteLine(i);
            //    i++;
            //}

            //// Pro
            //for (int i = 0; i <= 10; i++)
            //{
            //    Console.WriteLine(i);
            //}

            //// Zaheslovany pristup
            //Console.WriteLine("Zadej heslo: ");
            //string heslo = Console.ReadLine();
            //while (heslo != "123")
            //{
            //    Console.WriteLine("Neplatne heslo, zkus to znovu: ");
            //    heslo = Console.ReadLine();
            //}
            //Console.WriteLine("Tajna informace.");

            // Fibonacciho posloupnost (0, 1, 1, 2, 3, 5, 8, 13, ...)
            Console.Write("Po kolikaty celn posloupnosti(1 - 93): ");
            int n = Convert.ToInt32(Console.ReadLine());
            // Vypsani prvnich dvou clenu posl. (index 0 a 1)
            BigInteger a1 = 0, a2 = 1;   // Muzeme pouzit BigInteger - nakliknout using system numerics
            Console.WriteLine("{0,2}. = {1,26:N0}",0, a1);
            Console.WriteLine("{0,2}. = {1,26:N0}",1, a2);
            // Vypsani zbytku
            for (int i = 2; i <= n; i++)
            {
                BigInteger a3 = a1 + a2;
                Console.WriteLine("{0,2}. = {1,26:N0}", i, a3);
                a1 = a2;
                a2 = a3;
            }


            Console.ReadLine();


        }
    }
}
