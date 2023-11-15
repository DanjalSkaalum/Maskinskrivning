using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Xml.Serialization;

namespace ConsoleApp2
{
    internal class Program
    {
        static int points = 0;
        const int numberRounds = 2;
        static int[] highscore = new int[10];

        // Array of the danish alphabet.
        static char[] characters = {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't',
            'u', 'v', 'w', 'x', 'y', 'z', 'æ', 'ø', 'å'};

        // Random operator that makes a pseudo-random selection from the provided input.
        static Random rnd = new Random();

        // Min main metode som referere til de andre metoder
        static void Main(string[] args)
        {
            //highscore = Maskinskrivning.Io.LoadHighscore();
            Console.ReadKey();
            do
            {

                Console.Clear();
                ShowHighscore();
                Game();
                Show("Prøv Igen? (J/N)", 10, 8, ConsoleColor.Magenta);
            }
            while (Console.ReadKey().Key != ConsoleKey.N);
            Console.Clear();
        }

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

            string time = stopwatch.Elapsed.ToString(@"mm\\:ss\\.ff");

            Console.Clear();
            AddToHighScore(points);
            Show($"Du er færdig!", 10, 5, ConsoleColor.Yellow);
            Show($"Du fik {points} points i alt!", 10, 6, ConsoleColor.Yellow);
            Show("Tid: " + time, 10, 7, ConsoleColor.Yellow);
            Console.Write("");
            Console.ReadLine();
        }

        //Console.WriteLine(characters[0]);
        //Console.WriteLine(characters[characters.Length - 1]);

        static void StartHere(int i)
        {
            //TODO make char instead of int
            char randomChar = characters[rnd.Next(characters.Length)];

            Stopwatch keyStopWatch = new();
            keyStopWatch.Start();
            //TODO Show letter same place always
            Show(randomChar, 10 + i * 2, 5);

            char c = GetcharInput();
            keyStopWatch.Stop();
            if (randomChar == Char.ToLower(c))
            {
                points += Math.Max(0, 3000 - (int)keyStopWatch.ElapsedMilliseconds);
                Console.WriteLine(""); ;
                Show($" \n" + $"Korrekt. Du har {points} points.".PadRight(30), 10, 6, ConsoleColor.Green);
            }
            else
            {
                Console.WriteLine("");
                Show($" \n" + $"Forkert. Du har {points} points.".PadRight(30), 10, 6, ConsoleColor.Red);
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
            Show("***HIGHSCORE***", 70, 2, ConsoleColor.Cyan);
            for (int i = 0; i < highscore.Length; i++)
            {
                if (highscore[i] != null)
                {
                    Show(highscore, 70, 13 - i, ConsoleColor.Cyan);
                }
            }
        }

        // I've made a mistake here, but I'm not sure what.
        static void AddToHighScore(int newPoints)
        {
            bool isHighScore = false;
            foreach (var points in highscore)
            {
                if (newPoints > points)
                {
                    isHighScore = true;
                    break;
                }
            }

            if (!isHighScore) return;

            highscore[0] = newPoints;
            Array.Sort(highscore);
        }
    }
}
