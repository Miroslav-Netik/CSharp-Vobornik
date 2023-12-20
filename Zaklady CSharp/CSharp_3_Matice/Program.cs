using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_3_Matice
{
    internal class Program
    {
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            // Deklarace matice
            int m = 4, n = 5; // 4 řádky, 5 sloupců
            int[,] a = new int[m, n];

            // Naplnění matice

            // Lze i rovnou
            int[,] z = new[,]
            {
                {1, 2, 3, 4, 5 },
                {6, 7, 8, 9, 10 },
                {11, 12, 13, 14, 15 },
                {16, 17, 18, 19, 20 },
            };

            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                    a[i, j] = rnd.Next(10);
            // a[i, j] = i + j * a.GetLength(0) + 1;   // Hodnota vyp. na zíkladě indexů každého člena, na pořadí procházení nazáleží
            // a[i, j] = j + i * a.GetLength(1) + 1;   // To co výše po řádcích :-)

            //// Jiný způsob naplnění matice náhodnými čísly
            //for (int i = 0; i < a.Length; i++)
            //    a[i / a.GetLength(1), i % a.GetLength(1)] = rnd.Next(10);

            VypisMatici(a);
            //  VypisMatici2(z);

            // Součet hodnot
            int soucet = 0;
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                    soucet += a[i, j];
            Console.WriteLine("Součet členů matice je {0}", soucet);
            Console.WriteLine("Průměr členů matice je {0}", soucet / (double)a.Length);

            //  Počet sudých členů
            int pocetSudych = 0;
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                    if (a[i, j] % 2 == 0 && a[i, j] != 0)
                    {
                        pocetSudych++;
                    }
            Console.WriteLine("Počet sudých členů v matici je {0}", pocetSudych);

            //  Poslední lichá hodnota - po řádcích
            int poslLich = 2;
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                    if (a[i, j] % 2 == 1)
                    {
                        poslLich = a[i, j];
                    }
            if (poslLich == 2)
                Console.WriteLine("V matici žádná lichá hodnota není.");
            else
                Console.WriteLine("Poslední lichá hodnota po řádcích je {0}", poslLich);

            //  Poslední lichá hodnota - po sloupcích
            poslLich = 2;
            for (int j = 0; j < a.GetLength(1); j++)
                for (int i = 0; i < a.GetLength(0); i++)
                    if (a[i, j] % 2 == 1)
                    {
                        poslLich = a[i, j];
                    }
            if (poslLich == 2)
                Console.WriteLine("V matici žádná lichá hodnota není.");
            else
                Console.WriteLine("Poslední lichá hodnota po sloupcích je {0}", poslLich);

            // Varianta pro nalezení první liché hodnoty po sloupcich
            int prvniLich = 2;
            for (int j = 0; j < a.GetLength(1) && prvniLich == 2; j++)
            {
                for (int i = 0; i < a.GetLength(0) && prvniLich == 2; i++)
                {
                    if (a[i, j] % 2 != 0)
                    {
                        prvniLich = a[i, j];
                    }
                }
            }
            Console.WriteLine("První lichá hodnota po sloupcích je {0}", prvniLich);

            // Minimální a maximální hodnota
            int min = a[0, 0];
            int max = a[0, 1];
            for (int j = 0; j < a.GetLength(1); j++)
                for (int i = 0; i < a.GetLength(0); i++)
                {
                    if (a[i, j] < min)
                    {
                        min = a[i, j];
                    }
                    if (a[i, j] > max)
                    {
                        max = a[i, j];
                    }
                }
            Console.WriteLine("Nejmenší je {0}\nNejvětší je {1}", min, max);

            // Minimum a počet jeho výskytů
            min = a[0, 0];
            int pocetMinim = 0;
            for (int j = 0; j < a.GetLength(1); j++)
                for (int i = 0; i < a.GetLength(0); i++)
                {
                    if (a[i, j] < min)
                    {
                        min = a[i, j];
                        pocetMinim = 1;
                    }
                    else if (a[i, j] == min)
                    {
                        pocetMinim++;
                    }
                }
            Console.WriteLine("Nejmenších je {0}", pocetMinim);

            // Průměr hodnot na rtém řádku
            Console.Write("Zadej počet řádků (0 až {0}): ", a.GetLength(0) - 1);
            int r = int.Parse(Console.ReadLine());
            int soucetR = 0;
            for (int j = 0; j < a.GetLength(1); j++)
                soucetR += a[r, j];
            Console.WriteLine("Průměr hodnot matice na řádku s indexem {0} je {1}", r,
                soucetR / (double)a.GetLength(1));

            //  Záměna prvního a posledního řádku
            for (int j = 0; j < a.GetLength(1); j++)
            {
                int p = a[0, j];
                a[0,j] = a[a.GetLength(0) - 1, j];
                a[a.GetLength(0) - 1, j] = p;
            }
            Console.WriteLine("\nMatice se zaměněnými řádky:");
            VypisMatici(a);

            //// Součin prvků z s-tého sloupce
            //Console.Write("Zadej index sloupce (0 až {0}): ", a.GetLength(1) - 1);
            //int s = int.Parse(Console.ReadLine());
            //int soucinS = 1;
            //for (int i = 0; i < a.GetLength(0); i++)
            //{
            //    soucinS *= a[i, s];
            //}
            //Console.WriteLine("Souči hodnot sloupce s indexem {0} je {1}", s, soucinS);

            //  Průměry ze všech sloupců
            double[] prS = new double[a.GetLength(1)];
            for (int j = 0; j < a.GetLength(1); j++)
            {
                int soucetS = 1;
                for (int i = 0; i < a.GetLength(0); i++)
                {
                    soucetS += a[i, j];
                }
                prS[j] = soucetS / (double)a.GetLength(0);
            }
            Console.Write("Průměry sloupců: ");
            for (int i = 0; i < prS.Length; i++)
            {
                Console.Write("{0}; ", prS[i]);
            }
            Console.WriteLine();

            Console.ReadKey();
        }
        static void VypisMatici(int[,] a)
        {
            // Vypsání matice
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write("{0,2}, ", a[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        static void VypisMatici2(int[,] a)
        {
            // Jiná verze výpisu matice (1 cyklus, bez čárek na konci řádků)
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write("{0,2}{1}", a[i / a.GetLength(1), i % a.GetLength(1)],
                    (i + 1) % a.GetLength(1) == 0 ? Environment.NewLine : ", ");
            }
            Console.WriteLine();
        }
    }
}
