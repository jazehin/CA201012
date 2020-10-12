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
            //változók létrehozása
            int[] tomb = new int[100];
            int[] kivalogatas = new int[100];
            int sum = 0;
            int avg = 0;
            int db = 0; 
            int index = 0;
            int ev = 2003;

            //feltöltés + összegzés + 4000-5000 közti átlagszámolás első fele 
            for (int i = 0; i < tomb.Length; i++)
            {
                tomb[i] = rnd.Next(200, 2000) * 5;
                if (tomb[i] >= 4000 && tomb[i] < 5000)
                {
                    avg += tomb[i];
                    db++;
                }
                sum += tomb[i];
            }

            //kiírás
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if ((i * 10 + j + 1) % 7 == 0) Console.ForegroundColor = ConsoleColor.Green;
                    
                    Console.Write($"{tomb[i*10+j]} ");

                    Console.ResetColor();
                }
                Console.WriteLine();
            }

            //tömb elemeinek összege
            Console.WriteLine($"\nA tömb elemeinek az összege {sum}");

            //4000-5000 közti átlag kiírása
            Console.WriteLine($"A 4000-nél nem kisebb, de 5000-nél kisebb elemek átlaga {(double)avg/db}");

            //van-e 65 többszöröse
            while (index < tomb.Length && tomb[index] % 65 != 0) index++;
            if (index < tomb.Length) Console.WriteLine($"Van 65 valamelyik többszöröse a tömbben - a(z) {index}. indexen : {tomb[index]}");
            else Console.WriteLine("Nincs 65 többszöröse a tömbben");

            //hány darab 3-mal kezdődő szám van
            for (int i = 0; i < tomb.Length; i++)
            {
                if (tomb[i] / 1000 == 3) db++;
            }
            Console.WriteLine($"A tömbben {db} db 3-mal kezdődő szám van");

            //elfogadható órabér van-e a tömbben
            index = 0;
            while (index < tomb.Length && tomb[index] < 3000) index++;
            if (index < tomb.Length) Console.WriteLine($"{index}. indexű elem elfogadható órabér");
            else Console.WriteLine("Nincs elfogadható órabér");

            //kerek 100-asok kiválogatása
            index = 0;
            for (int i = 0; i < tomb.Length; i++)
            {
                if (tomb[i] % 100 == 0)
                {
                    kivalogatas[index] = tomb[i];
                    index++;
                }
            }

            //kiválogatás eredményének kiírása
            for (int i = 0; i < index; i++)
            {
                if (kivalogatas[i] / 1000 == kivalogatas[i] / 100 - kivalogatas[i] / 1000 * 10) Console.BackgroundColor = ConsoleColor.Red;
                Console.Write($"{kivalogatas[i]}");
                Console.ResetColor();
                Console.Write(" ");
            }

            //évszám kerekítés
            switch (ev % 10)
            {
                case 1:
                    ev -= 1;
                    break;
                case 2:
                    ev -= 2;
                    break;
                case 3:
                    ev += 2;
                    break;
                case 4:
                    ev += 1;
                    break;
                case 6:
                    ev -= 1;
                    break;
                case 7:
                    ev -= 2;
                    break;
                case 8:
                    ev += 2;
                    break;
                case 9:
                    ev += 1;
                    break;
            }
            //évszám keresése a tömbben
            index = 0;
            while (index < tomb.Length && tomb[index] != ev) index++;
            if (index < tomb.Length) Console.WriteLine($"\nVan a tömbben {ev}");
            else Console.WriteLine($"\nNincs a tömbben {ev}");





            Console.ReadKey();
        }
    }
}
