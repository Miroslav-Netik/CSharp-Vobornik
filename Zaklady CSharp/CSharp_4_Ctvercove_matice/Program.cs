using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_4_Ctvercove_matice
{
    internal class Program
    {
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            //  Deklarace pole
            int m = 5;
            int[,] a = new int[m, m];

            //  Naplnění pole
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                    a[i, j] = rnd.Next(10);

            //string vypis = "";
            //for (int i = 0; i < m; i++)
            //{
            //    for (int j = 0; j < m; j++)
            //    {
            //        vypis += ($"{a[i, j],2} ");
            //    }
            //    vypis += "\n";
            //}
            //Console.WriteLine(vypis);

            //  Vypsání pole
            VypisMatici(a);

            //  Hlavní diagonála = 0
            for (int i = 0; i < m; i++)
            {
                a[i, i] = 0;
            }
            VypisMatici(a);

            //  Nad hlavní diagonálou včetně hlavní diagonály
            for (int i = 0; i < m; i++)
            {
                for (int j = i; j < m; j++) //  (j = i) => Zpracuj prvky včetně hl.d
                {
                    a[i, j] = 1;
                }
            }
            VypisMatici(a);

            //  Nad hlavní diagonálou BEZ hlavní diagonály
            for (int i = 0; i < m; i++)
            {
                for (int j = i + 1; j < m; j++)
                {
                    a[i, j] = 0;
                }
            }
            VypisMatici(a);

            //  POD hlavní diagonálou BEZ hlavní diagonály
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    a[i, j] = 2;
                }
            }
            VypisMatici(a);

            //  POD hlavní diagonálou VČETNĚ hlavní diagonály
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < i + 1; j++) // (j < i + 1) => Včetně hlavní diagonály
                {
                    a[i, j] = 3;
                }
            }
            VypisMatici(a);

            //  Vedlejší diagonála = 0
            for (int i = 0; i < m; i++)
            {
                a[i, m - 1 - i] = 0;
            }
            VypisMatici(a);

            //  Nad VEDLEJŠÍ (VČETNĚ) diagonálou = 5
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < m - i; j++) //  (j < m - i) => Zpracuj prvky včetně vedl.d.
                {
                    a[i, j] = 5;
                }
            }
            VypisMatici(a);

            //  Nad VEDLEJŠÍ (BEZ) diagonálou = 7
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < m - i - 1; j++) //  (j < m - i - 1) => Zpracuj prvky bez vedl.d.
                {
                    a[i, j] = 7;
                }
            }
            VypisMatici(a);

            //  Pod VEDLEJŠÍ (BEZ) diagonálou = 8
            for (int i = 0; i < m; i++)
            {
                for (int j = m - i; j < m; j++) //  (j = m - i) => Zpracuj prvky bez vedl.d.
                {
                    a[i, j] = 8;
                }
            }
            VypisMatici(a);

            //  Pod VEDLEJŠÍ (VČETNĚ) diagonálou = 9
            for (int i = 0; i < m; i++)
            {
                for (int j = m - i - 1; j < m; j++) //  (j = m - i - 1) => Zpracuj prvky včetně vedl.d.
                {
                    a[i, j] = 9;
                }
            }
            VypisMatici(a);

            //  Trojúhelník nahoře ( hranice určují hlavní a vedlejší diagonála) = 0
            for (int i = 0; i < m / 2; i++) // Dělím dvěma, protože stačí projít jen vrchní polovinu matice
            {
                for (int j = i + 1; j < m - i - 1; j++)
                {
                    a[i, j] = 5;
                }
            }
            VypisMatici(a);

            //  Trojúhelník dole ( hranice určují hlavní a vedlejší diagonála) = 0
            for (int i = m / 2; i < m; i++) // Dělím dvěma, protože stačí projít jen spodní polovinu matice, pokud chcem zahrnou diag -> m/2+1
            {
                for (int j = m - i; j < i; j++)
                {
                    a[i, j] = 5;
                }
            }
            VypisMatici(a);

            //  Trojúhelník vlevo ( hranice určují hlavní a vedlejší diagonála) = 8
            //  Teď to procházím po sloupcích, proto je cyklus i a j přehozený
            for (int j = 0; j < m / 2; j++) // Dělím dvěma, protože stačí projít jen levou polovinu matice
            {
                for (int i = j + 1; i < m - 1 - j; i++)
                {
                    a[i, j] = 8;
                }
            }
            VypisMatici(a);

            //  Trojúhelník vpravo ( hranice určují hlavní a vedlejší diagonála) = 8
            //  Teď to procházím po sloupcích, proto je cyklus i a j přehozený
            for (int j = m / 2 /* Začínám od půlky*/; j < m /* Do konce matice*/; j++) // Dělím dvěma, protože stačí projít jen levou polovinu matice
            {
                for (int i = m - j /* Sloupce začínám čím dál tím výš*/; i < j /* A sjíždím čím dál tím níž*/; i++)
                {
                    a[i, j] = 8;
                }
            }
            VypisMatici(a);

            // ****************************************

            //  Naplnění pole
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                    a[i, j] = rnd.Next(10);
            VypisMatici(a);

            //  Je větší průměr členů nad hlavní diag. nebo pod ní?
            //  Varianta 1 - dva dvojcykly

            int soucetNad = 0; int pocetNad = 0; // pocetNad = pocetPod = (m * (m - 1)) / 2
            for (int i = 0; i < m; i++)
            {
                for (int j = i + 1; j < m; j++)
                {
                    soucetNad += a[i, j];
                    pocetNad++;
                    Console.Write($"{a[i, j]}, ");
                }
            }
            Console.WriteLine();
            int soucetPod = 0; int pocetPod = 0; // pocetNad = pocetPod = (m * (m - 1)) / 2
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    soucetPod += a[i, j];
                    pocetPod++;
                    Console.Write($"{a[i, j]}, ");
                }
            }
            Console.WriteLine();

            //  Vypsání výsledku
            double prumerNad = soucetNad / (double)pocetNad;
            double prumerPod = soucetPod / (double)pocetPod;
            if (prumerNad == prumerPod)
            {
                Console.WriteLine($"Průměr nad hlavní diagonálou{prumerNad} je stejný jako průměr pod hlavní diagonálou{prumerPod}.");
            }
            else if (prumerNad > prumerPod)
            {
                Console.WriteLine($"Průměr nad hlavní diagonálou {prumerNad} je větší než průměr pod hlavní diagonálou {prumerPod}.");
            }
            else { Console.WriteLine($"Průměr nad hlavní diagonálou {prumerNad} je menší než průměr pod hlavní diagonálou {prumerPod}"); }

            //  Je větší průměr členů nad hlavní diag. nebo pod ní?
            //  Varianta 2 - v jednom cyklu

            for (int i = 0; i < m; i++)
            {
                for (int j = i + 1; j < m; j++)
                {

                    if (j > i)
                    {
                        soucetNad += a[i, j];
                        pocetNad++;
                        Console.Write($"{a[i, j]}, ");
                    }
                    else if (j < i)
                    {
                        soucetPod += a[i, j];
                        pocetPod++;
                        Console.Write($"{a[i, j]}, ");
                    }
                }
            }
            Console.WriteLine();

            //  Vypsání výsledku
            prumerNad = soucetNad / (double)pocetNad;
            prumerPod = soucetPod / (double)pocetPod;
            if (prumerNad == prumerPod)
            {
                Console.WriteLine($"Průměr nad hlavní diagonálou{prumerNad} je stejný jako průměr pod hlavní diagonálou{prumerPod}.");
            }
            else if (prumerNad > prumerPod)
            {
                Console.WriteLine($"Průměr nad hlavní diagonálou {prumerNad} je větší než průměr pod hlavní diagonálou {prumerPod}.");
            }
            else { Console.WriteLine($"Průměr nad hlavní diagonálou {prumerNad} je menší než průměr pod hlavní diagonálou {prumerPod}"); }

            //  Prohození hodnot členů trojůhelníku nahoře adole

            for (int i = 0; i < m / 2; i++) // Dělím dvěma, protože stačí projít jen vrchní polovinu matice
            {
                for (int j = i + 1; j < m - i - 1; j++)
                {
                    int p = a[m - i - 1, j];
                    a[m - i - 1, j] = a[i, j];
                    a[i, j] = p;
                }
            }
            VypisMatici(a);
            Console.WriteLine();

            //  Prohození hodnot členů trojůhelníku vůevo a vpravo
            for (int j = 0; j < m / 2; j++) // Dělím dvěma, protože stačí projít jen levou polovinu matice
            {
                for (int i = j + 1; i < m - 1 - j; i++)
                {
                    int p = a[i, m - j - 1];
                    a[i, m - j - 1] = a[i, j];
                    a[i, j] = p;
                }
            }
            VypisMatici(a);
            Console.WriteLine();

            //  Naplnění pole řadou čísel
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    a[i, j] = j + i * m + 1;
                }
            }
            VypisMatici(a);

            //  Otočení matice o 90 stupňů ve směru hodinových ručiček

            for (int i = 0; i < m / 2; i++)
            {
                for (int j = i; j < m - i - 1; j++)
                {
                    int p = a[i, j];
                    a[i, j] = a[m - j - 1, i];
                    a[m - j - 1, i] = a[m - i - 1, m - j - 1];
                    a[m - i - 1, m - j - 1] = a[j, m - i - 1];
                    a[j, m - i - 1] = p;
                }
            }
            VypisMatici(a);

            //  Ukončovací výpis
            Console.WriteLine("\nPro ukončení stiskni jakoukoliv klávesu...");
            Console.ReadKey();
        }

        //  ********************
        //      Níže metody
        //  ********************

        static void VypisMatici(int[,] vstupmiPole)

        {
            for (int i = 0; i < vstupmiPole.GetLength(0); i++)
            {
                for (int j = 0; j < vstupmiPole.GetLength(1); j++)
                {
                    Console.Write("{0,2} ", vstupmiPole[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}

