using MasterMind.Models;
using MasterMind.Resources;
using System;

namespace MasterMind.ConsoleApp
{
    public class Program
    {
        /// <summary>
        /// Instance of the game.
        /// </summary>
        private static Game game;

        private static void Main()
        {
            SetStartScreen();
        }
        /// <summary>
        /// Display the start window and ask for input.
        /// </summary>
        private static void SetStartScreen()
        {
            Console.WriteLine($"Witaj w grze Mastermind!");
            TakeFirstOption();
        }
        /// <summary>
        /// Start new game or display game rules depending on the user's input.
        /// </summary>
        private static void TakeFirstOption()
        {
            Console.WriteLine("\nWybierz opcję: \n1 - rozpoczęcie gry.\n2 - wyświetlenie zasad gry.\n");
            char option = Console.ReadKey().KeyChar;

            if (option == '1')
            {
                StartGame();
                AskForInput();
            }
            else if (option == '2')
            {
                Console.WriteLine(Texts.GameRules);
                TakeFirstOption();
            }
            else

            {
                Console.WriteLine("Proszę spróbować jeszcze raz.");
                TakeFirstOption();
            }
        }
        /// <summary>
        /// Start new game. Display basic information.
        /// </summary>
        private static void StartGame()
        {
            game = new Game();
            Console.WriteLine($"\nGra rozpoczęta. Komputer wylosował kod o długości {game.CodeLength}. Kody kolorów: red(r),yellow(y), green (g), blue (b), magenta (m), cyan (c) = r,y, g, b, m, c\n");
        }
        /// <summary>
        /// Ask user for his answer.
        /// </summary>
        private static void AskForInput()
        {
            Console.WriteLine($"\nWpisz proszę swoją odpowiedź o maksymalnej długości {game.CodeLength}. Pozostało Ci {game.TimeLimit - game.Round} prób.\n");
            TakeInput();
        }
        /// <summary>
        /// Take the user's input and check if it's correct.
        /// </summary>
        private static void TakeInput()
        {
            string input = Console.ReadLine();
            string answer = game.CheckCode(input);

            if (game.Status == GameStatus.Won)
            {
                Console.WriteLine($"Gratulacje! Odgadłeś kod :) Zajęlo Ci to {game.Round} prób.");
                AskForNewGame();
            }
            else if (game.Status == GameStatus.Lost)
            {
                Console.WriteLine($"Niestety to koniec gry. Nie udało Ci się odgadnąć hasła pomimo {game.Round} prób. A oto kod: {game.Code}. Prosty nieprawdaż?");
                AskForNewGame();
            }
            else
            {
                Console.WriteLine($"Przeciwnik odpowiada: {answer}");
                AskForInput();
            }
        }
        /// <summary>
        /// Ask the user if she/he wants to play again.
        /// </summary>
        private static void AskForNewGame()
        {
            Console.WriteLine("Chcesz spróbować ponownie? Wciśnij Y aby zatwierdzić");
            char option = Console.ReadKey().KeyChar;

            if (option == 'Y')
            {
                StartGame();
                AskForInput();
            }
            else
            {
                Environment.Exit(0);
            }
        }
    }
}