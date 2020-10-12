using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA201012
{
    class Program
    {
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            int[] tomb = new int[100];
            int[] kivalogatas = new int[100];
            int avg = 0;
            int db = 0; 
            int index = 0;
            
            for (int i = 0; i < tomb.Length; i++)
            {
                tomb[i] = rnd.Next(200, 2000) * 5;
                if (tomb[i] >= 4000 && tomb[i] < 5000)
                {
                    avg += tomb[i];
                    db++;
                }
            }

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (j == 7) Console.ForegroundColor = ConsoleColor.Green;
                    else Console.ResetColor();
                    Console.Write($"{tomb[i*10+j]} ");
                }
                Console.WriteLine();
            }

            Console.WriteLine($"\nA tömb elemeinek az összege {tomb.Sum()}");

            Console.WriteLine($"A 4000-nél nem kisebb, de 5000-nél kisebb elemek átlaga {(double)avg/db}");

            while (index < tomb.Length && tomb[index] % 65 != 0) index++;
            if (index < tomb.Length) Console.WriteLine($"Van 65 valamelyik többszöröse a tömbben - a(z) {index}. indexen : {tomb[index]}");
            else Console.WriteLine("Nincs 65 többszöröse a tömbben");

            for (int i = 0; i < tomb.Length; i++)
            {
                if (tomb[i] / 1000 == 3) db++;
            }
            Console.WriteLine($"A tömbben {db} db 3-mal kezdődő szám van");

            index = 0;
            while (index < tomb.Length && tomb[index] < 3000) index++;
            if (index < tomb.Length) Console.WriteLine($"{tomb[index]} Ft");
            else Console.WriteLine("Nincs elfogadható órabér");

            index = 0;
            for (int i = 0; i < tomb.Length; i++)
            {
                if (tomb[i] % 100 == 0)
                {
                    kivalogatas[index] = tomb[i];
                    index++;
                }
            }
            for (int i = 0; i < index; i++)
            {
                if (kivalogatas[i] / 1000 == kivalogatas[i] / 100 - kivalogatas[i] / 1000 * 10) Console.BackgroundColor = ConsoleColor.Red;
                Console.Write($"{kivalogatas[i]}");
                Console.ResetColor();
                Console.Write(" ");
            }

            double ev = 2003;
            ev /= 10;
            ev = Math.Round(ev) * 10;
            index = 0;
            while (index < tomb.Length && tomb[index] != (int)ev) index++;
            if (index < tomb.Length) Console.WriteLine($"\nVan a tömbben {ev}");
            else Console.WriteLine($"\nNincs a tömbben {ev}");





            Console.ReadKey();
        }
    }
}
