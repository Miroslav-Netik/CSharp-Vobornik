using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_2_Posloupnosti
{
    internal class Program
    {
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            // Deklarace posloupnosti (1Dpole)
            int[] z = new int[] { 1, 2, 3, 4, 5 };    // 5 hodnot (indexy 0 - 9)
            int[] a = new int[10];  // indexy 0-9

            //  Načtení hodnot od uživatele
            //for (int i = 0; i < a.Length; i++)
            //{
            //    a[i] = Convert.ToInt32(Console.ReadLine());
            //}

            //// Načtení hodnot od 1 do N
            //for (int i = 0; i < a.Length; i++)
            //{
            //    a[i] = i + 1;
            //}

            // Načtení náhodných hodnot od 1 do N
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = rnd.Next(1, 11);
            }

            VypisPosloupnost(a);    // Volání metody

            //// Výpis posloupnosti pod sebe
            //for (int i = 0; i < a.Length; i++)
            //{
            //    Console.WriteLine("{0}. {1} ", i, a[i]);
            //}

            // Součet členů poslouonosti
            int soucet = 0;
            for (int i = 0; i < a.Length; i++)
            {
                soucet += a[i];
            }
            Console.WriteLine("Součet = {0}", soucet);
            Console.WriteLine("Průměr = {0}", soucet / (double)a.Length);

            //  Počet sudých členů
            int pocet = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (true)
                {
                    if (a[i] % 2 == 0 && a[i] != 0)
                    {
                        pocet++;
                    }
                }
            }
            Console.WriteLine("Počet sudých je {0}", pocet);

            //// Nalezení minimální hodnoty
            //int min = a[0];
            //for (int i = 0; i < a.Length; i++)
            //    if (a[i] < min)
            //        min = a[i];
            //Console.WriteLine("Minimum je {0}", min);

            //// Počet minim
            //int pocetMinim = 0;
            //for (int i = 0; i < a.Length; i++)
            //{
            //    if (a[i] == min)
            //    {
            //        pocetMinim++;
            //    }
            //}
            //Console.WriteLine("Minimum = {0} je tam {1} krát.", min, pocetMinim);

            // Počet minim v rámci jednoho cyklu
            int min = a[0];
            int pocetMinim = 1; // Toto výchozí minimum je zam zatím 1x
            for (int i = 1; i < a.Length; i++)  // Od 2. indexu, první už tam je vložený
            {
                if (a[i] < min) // Našli jsme o něco menší než akt. minimum
                {
                    min = a[i]; // Uloží hodnotu nového minima
                    pocetMinim = 1; // Toto nové minimum jsme našli zatím 1x
                }
                else if (a[i] == min)   // Znovu našel hodnotu aktuálního minima
                {
                    pocetMinim++;   // Zapožítá jeho další výskyt
                }
            }
            Console.WriteLine("Minimum = {0} je tam {1} krát.", min, pocetMinim);

            // Index 1. minima
            int indexMin = 0;
            for (int i = 1; i < a.Length; i++)
            {
                if (a[i] < a[indexMin])
                {
                    indexMin = i;
                }
            }
            Console.WriteLine("Minimum = {0} a poprvé je na indexu {1}", a[indexMin], indexMin);

            // Index posledního minima -> <=
            //int indexMin = 0;
            indexMin = 0;
            for (int i = 1; i < a.Length; i++)
            {
                if (a[i] <= a[indexMin])
                {
                    indexMin = i;
                }
            }
            Console.WriteLine("Minimum = {0} a naposled je na indexu {1}", a[indexMin], indexMin);

            ////  Odebrání člena posloupnosti
            //Console.Write("Zadej index člena pro odebrání: ");
            //int k = Convert.ToInt32(Console.ReadLine());
            //VypisPosloupnost(a);
            //for (int i = k; i < a.Length - 1; i++)
            //{
            //    a[i] = a[i + 1];
            //}
            //Array.Resize(ref a, a.Length - 1);  // Změna velikosti pole - zmenšení
            //VypisPosloupnost(a);

            ////  Vložení člena posloupnosti
            //Console.Write("Zadej index člena pro vložení: ");
            //int k_2 = Convert.ToInt32(Console.ReadLine());
            //Console.Write("Zadej hodnotu nového člena: ");
            //int h = Convert.ToInt32(Console.ReadLine());
            //VypisPosloupnost(a);
            //Array.Resize(ref a, a.Length + 1);  // Změna velikosti pole - zvětšení
            //for (int i = a.Length - 1; i > k_2; i--)
            //{
            //    a[i] = a[i - 1];
            //}
            //a[k_2] = h;
            //VypisPosloupnost(a);

            // Cyklický posun vpřed (doleva)
            int p = a[0];   // Do p vložím první člen
            for (int i = 0; i < a.Length - 1; i++) 
            {
                a[i] = a[i + 1];    // Předchozí člen přepíšu následujícím
            }
            a[a.Length - 1] = p;    // Poskední člen přepíšu tím prvním
            VypisPosloupnost(a);

            // Cyklický posun vzad (doprava)
            p = a[a.Length - 1];   // Do p vložím poslední člen
            for (int i = a.Length - 1; i > 0; i--)
            {
                a[i] = a[i - 1];    // Předchozí člen přepíšu následujícím (ale sestupně, jedu od konce)
            }
            a[0] = p;    // První člen přepíšu tím uloženým posledním
            VypisPosloupnost(a);

            // Práce s více posloupnostmi
            // Zkopírování sudých členů z A do B
            int[] b = new int[0];   // Nevím, jak ta posloupnost bude dlouhá
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] % 2 == 0)
                {
                    Array.Resize(ref b, b.Length + 1);
                    b[b.Length - 1] += a[i];
                }
            }
            VypisPosloupnost(b);

            //  Spojení posloupností A a B do C
            int[] c = new int[a.Length + b.Length];
            for (int i = 0; i < a.Length; i++)
            {
                c[i] = a[i];
            }
            for (int i = 0; i < b.Length; i++)
            {
                c[a.Length + i] = b[i];
            }
            VypisPosloupnost(c);

            Console.ReadKey();
        }
        static void VypisPosloupnost(int[] a)
        { // Výpis posloupnosti vedle sebe
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write("{0}, ", a[i]);
            }
            Console.WriteLine();
        }
    }
}
