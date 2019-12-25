using MasterMind.ConsoleApp.Resources;
using MasterMind.Models;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace MasterMind.ConsoleApp
{
    /// <summary>
    /// Contains logic for the Console version of game Mastermind.
    /// </summary>
    public class ConsoleGameHandler
    {
        #region Constant Fields

        /// <summary>
        /// Char that starts new game in Console App. Saved as a field to increase code readability.
        /// </summary>
        private const char StartGameOption = '1';

        /// <summary>
        /// Char that shows the game options in Console App. Saved as a field to increase code readability.
        /// </summary>
        private const char DisplayGameRulesOption = '2';

        /// <summary>
        /// Char creates new game in Console App. Saved as a field to increase code readability.
        /// </summary>
        private const char PlayAgainOption = 'Y';

        /// <summary>
        /// Contains all the available colors in the game Mastermind..
        /// </summary>
        private const string AvailableColorsString = "rygbmc";

        #endregion Constant Fields

        #region Private Fields

        /// <summary>
        /// Instance of the game.
        /// </summary>
        private readonly Game game;

        #endregion Private Fields

        #region Constructors

        /// <summary>
        /// Creates a new instance of the game. Contains logic for the Console version of game Mastermind.
        /// </summary>
        public ConsoleGameHandler()
        {
            game = new Game();
        }

        #endregion Constructors

        #region Public Methods

        /// <summary>
        /// Display the start window and ask for input.
        /// </summary>
        public void SetStartScreen()
        {
            Console.WriteLine(StaticConsoleTexts.WelcomeScreen);
            TakeFirstOption();
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Start new game or display game rules depending on the user's input.
        /// </summary>
        private void TakeFirstOption()
        {
            Console.WriteLine(StaticConsoleTexts.Options);
            char option = Console.ReadKey().KeyChar;

            if (option == StartGameOption)
            {
                StartGame();
            }
            else if (option == DisplayGameRulesOption)
            {
                Console.WriteLine(StaticConsoleTexts.GameRules);
                TakeFirstOption();
            }
            else

            {
                Console.WriteLine(StaticConsoleTexts.TryAgain);
                TakeFirstOption();
            }
        }

        /// <summary>
        /// Start new game. Display basic information.
        /// </summary>
        private void StartGame()
        {
            Console.WriteLine(DynamicConsoleTexts.GetInformationText(game.CodeLength));
            AskForInput();
        }

        /// <summary>
        /// Ask user for his answer.
        /// </summary>
        private void AskForInput()
        {
            int currentRound = game.TimeLimit - game.Round;
            Console.WriteLine(DynamicConsoleTexts.GetNextRoundInformation(game.CodeLength, currentRound));
            GenerateColors();
            TakeInput();
        }

        /// <summary>
        /// Take the user's input and check if it's correct.
        /// </summary>
        private void TakeInput()
        {
            string input = Console.ReadLine();
            bool doCharactersExist = !Regex.IsMatch(input, $"[^{AvailableColorsString}]");

            if (!doCharactersExist)
            {
                Console.WriteLine(StaticConsoleTexts.WrongColor);
                AskForInput();
                return;
            }

            game.CheckCode(input);

            if (game.Status == GameStatus.Won)
            {
                Console.WriteLine(DynamicConsoleTexts.GetWinningInformation(game.Round));
                AskForNewGame();
            }
            else if (game.Status == GameStatus.Lost)
            {
                Console.WriteLine(DynamicConsoleTexts.GetLosingInformation(game.Round, game.Code));
                AskForNewGame();
            }
            else
            {
                AskForInput();
            }
        }

        /// <summary>
        /// Ask the user if she/he wants to play again.
        /// </summary>
        private void AskForNewGame()
        {
            Console.WriteLine(StaticConsoleTexts.PlayAgain);
            char option = Console.ReadKey().KeyChar;

            if (option == PlayAgainOption)
            {
                StartGame();
            }
            else
            {
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// Generate colorful rectangles instead of plain characters.
        /// </summary>
        private void GenerateColors()
        {
            foreach (Round round in game.User.Rounds)
            {
                foreach (char color in round.Input)
                {
                    WriteColor(color);
                }

                Console.Write(" ");

                foreach (char tip in round.Output)
                {
                    WriteColor(tip);
                }
                Console.Write(GetStatus(round.Output) + "\n");
            }
        }

        /// <summary>
        /// Checks the output from previous guess and generates a text information for the player.
        /// </summary>
        /// <param name="output">Output from the previous round.</param>
        /// <returns>Information text about previous guess.</returns>
        private string GetStatus(char[] output)
        {
            int correctAnswersCount = output.Count(c => c == Answers.CORRECT_ANSWER);
            int correctColorsCount = output.Count(c => c == Answers.COLOR_EXISTS);
            int badAnswerCount = output.Count(c => c == Answers.WRONG_GUESS);

            return DynamicConsoleTexts.GetAnswerOutput(correctAnswersCount, correctColorsCount, badAnswerCount);
        }

        /// <summary>
        /// Create colorful rectangle for the character.
        /// </summary>
        /// <param name="character">Character available in the application.</param>
        private void WriteColor(char character)
        {
            Console.BackgroundColor = GetConsoleColor(character);
            Console.ForegroundColor = GetConsoleColor(character);
            Console.Write($"  ");
            Console.ResetColor();
        }

        /// <summary>
        /// Get colorful rectangle for the character.
        /// </summary>
        /// <param name="character">Character available in the application.</param>
        /// <returns>Color of the console.</returns>
        private ConsoleColor GetConsoleColor(char character)
        {
            switch (character)
            {
                case Colors.BLUE:
                    return ConsoleColor.Blue;

                case Colors.CYAN:
                    return ConsoleColor.Cyan;

                case Colors.GREEN:
                    return ConsoleColor.Green;

                case Colors.MAGENTA:
                    return ConsoleColor.Magenta;

                case Colors.RED:
                    return ConsoleColor.Red;

                case Colors.YELLOW:
                    return ConsoleColor.Yellow;

                case Answers.CORRECT_ANSWER:
                    return ConsoleColor.DarkGray;

                case Answers.COLOR_EXISTS:
                    return ConsoleColor.White;

                case Answers.WRONG_GUESS:
                    return ConsoleColor.DarkRed;

                default:
                    return ConsoleColor.Black;
            }
        }

        #endregion Private Methods
    }
}