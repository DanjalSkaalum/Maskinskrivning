using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConsoleApp2
{
    internal class Program
    {
        static int points = 0;
        const int numberRounds = 10;
        static string[] highscore = new string[10];

        // Array of the danish alphabet.
        static char[] characters = {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't',
            'u', 'v', 'w', 'x', 'y', 'z', 'æ', 'ø', 'å'};

        // Random operator that makes a pseudo-random selection from the provided input.
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            do
            {

                Console.Clear();
                ShowHighscore();
                Game();
                Console.WriteLine("Try again? (Y/N)", 10, 6);

                Console.Clear();
            }
            while (Console.ReadKey().Key != ConsoleKey.N);

            static void Game()
            {
                points = 0;
                Console.CursorVisible = false;
                //TODO Start a timer
                Show($"Test din skrive hastighed.\n" +
                    "Skrive karakteren som bliver vist så hurtigt som muligt.\n" +
                    "\nTryk en hver knap for at starte.", 0, 0, ConsoleColor.Yellow);
                Console.ReadKey(true);


                Stopwatch stopwatch = new();
                stopwatch.Start();
                for (int i = 0; i < numberRounds; i++)
                {
                    StartHere(i);
                }
                stopwatch.Stop();

                Console.Clear();
                Show($"Du er færdig!", 0, 0, ConsoleColor.Yellow);
                Show($"Du fik {points} points i alt!", 0, 1, ConsoleColor.Yellow);
                Show("Tid: " + stopwatch.Elapsed.ToString("mm\\:ss\\.ff"), 0, 15, ConsoleColor.Yellow);
                Console.Write("");
                Console.ReadLine();

                //Console.WriteLine(characters[0]);
                //Console.WriteLine(characters[characters.Length - 1]);

                static void StartHere(int i)
                {
                    //TODO make char instead of int
                    char randomChar = characters[rnd.Next(characters.Length)];

                    //TODO Show letter same place always
                    Show(randomChar, 20 + i * 2, 10);

                    char c = GetcharInput();

                    if (randomChar == Char.ToLower(c))
                    {
                        Console.WriteLine("");
                        points++;
                        Show($" \n" + $"Korrekt. Du har {points} points.", 20, 10, ConsoleColor.Green);
                    }
                    else
                    {
                        Console.WriteLine("");
                        Show($" \n" + $"Forkert. Du har {points} points.", 20, 10, ConsoleColor.Red);
                    }
                    //TODO ELSE OH NO!
                }
            }
        }

        private static bool Compare(char v, char c)
        {
            return v == c;
        }

        private static char GetcharInput()
        {
            //TODO Don't show char pressed
            return Console.ReadKey(true).KeyChar;
        }
        //TODO Method for showing letters already processed

        static void Show(object text, int x, int y, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(x, y);
            Console.Write(text.ToString());
        }

        static void ShowHighscore()
        {
            Show("***HIGHSCORE***", 50, 2, ConsoleColor.Cyan);
            for (int i = 0; i < highscore.Length; i++)
            {
                Show(points, 50, 3 + i, ConsoleColor.Cyan);
            }
        }
    }
}
