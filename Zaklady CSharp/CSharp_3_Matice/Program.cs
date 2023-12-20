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
