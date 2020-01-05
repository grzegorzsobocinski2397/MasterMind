using MasterMind.Algorithms.Strategies;
using MasterMind.ConsoleApp.Resources;
using MasterMind.Models;
using System;
using System.Collections.Generic;
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
        /// Char that acts as a first option. Saved as a field to increase code readability.
        /// </summary>
        private const char FirstOptionKey = '1';

        /// <summary>
        /// Char that acts as a second option. Saved as a field to increase code readability.
        /// </summary>
        private const char SecondOptionKey = '2';

        /// <summary>
        /// Char that acts as a yes option. Saved as a field to increase code readability.
        /// </summary>
        private const char YesOption = 'y';

        /// <summary>
        /// Char that acts as a no option. Saved as a field to increase code readability.
        /// </summary>
        private const char NoOption = 'n';

        #endregion Constant Fields

        #region Private Fields

        /// <summary>
        /// Contains all the available colors in the game Mastermind..
        /// </summary>
        private string availableColorsString = "rygbmc";

        /// <summary>
        /// Instance of the game.
        /// </summary>
        private Game game;

        /// <summary>
        /// Human strategy that will act as AI.
        /// </summary>

        private HumanStrategy AI;

        /// <summary>
        /// How many rounds have the AI been playing for.
        /// </summary>
        private int computerRound = 0;

        /// <summary>
        /// How many rounds can user or computer play.
        /// </summary>
        private int timeLimit = 9;

        /// <summary>
        /// Length of the code used.
        /// </summary>

        private int codeLength = 4;

        #endregion Private Fields

        #region Public Methods

        /// <summary>
        /// Display the start window and ask for input.
        /// </summary>
        public void SetStartScreen()
        {
            Console.WriteLine(StaticConsoleTexts.WelcomeScreen);
            DisplayStartingWindow();
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Start new game or display game rules depending on the user's input.
        /// </summary>
        private void DisplayStartingWindow()
        {
            Console.WriteLine(StaticConsoleTexts.Options);
            char option = Console.ReadKey().KeyChar;

            if (option == FirstOptionKey)
            {
                AskForParameters();
            }
            else if (option == SecondOptionKey)
            {
                Console.WriteLine(StaticConsoleTexts.GameRules);
                DisplayStartingWindow();
            }
            else
            {
                Console.WriteLine(StaticConsoleTexts.TryAgain);
                DisplayStartingWindow();
            }
        }

        /// <summary>
        /// Ask the user if he wants to set parameters for the game.
        /// </summary>
        private void AskForParameters()
        {
            Console.Clear();
            Console.WriteLine($"{StaticConsoleTexts.ParameterizeGame}\n");
            char userInput = Console.ReadKey().KeyChar;

            if (userInput == YesOption)
            {
                TakePossibleArguments();
                SelectGameMode();
            }
            else if (userInput == NoOption)
            {
                SelectGameMode();
            }
            else
            {
                AskForParameters();
            }
        }

        /// <summary>
        /// User will choose whether he wants to guess or make a code.
        /// </summary>
        private void SelectGameMode()
        {
            Console.Clear();
            Console.WriteLine(StaticConsoleTexts.ChooseMode);
            char option = Console.ReadKey().KeyChar;

            if (option == FirstOptionKey)
            {
                AskForCode();
            }
            else if (option == SecondOptionKey)
            {
                StartGame();
            }
            else
            {
                Console.WriteLine(StaticConsoleTexts.TryAgain);
                DisplayStartingWindow();
            }
        }

        /// <summary>
        /// Ask the user to choose from available parameters.
        /// </summary>
        private void TakePossibleArguments()
        {
            Console.WriteLine($"{StaticConsoleTexts.PossibleCodeLength}\n");
            codeLength = int.Parse(Console.ReadKey().KeyChar.ToString());
            Console.WriteLine($"{StaticConsoleTexts.PossibleColors}\n");
            char userInput = Console.ReadKey().KeyChar;

            if (userInput == '1')
            {
                availableColorsString = "rgbycm";
                timeLimit = 9;
            }
            else if (userInput == '2')
            {
                availableColorsString = "rgbycmq";
                timeLimit = 12;
            }
            else
            {
                availableColorsString = "rgbycmqi";
                timeLimit = 15;
            }
        }

        /// <summary>
        /// Ask the user to come up with a code.
        /// </summary>
        private void AskForCode()
        {
            Console.Clear();
            Console.WriteLine(DynamicConsoleTexts.GetAskForCodeInformation(4, availableColorsString));
            AI = new HumanStrategy(codeLength);
            string code = Console.ReadLine();

            bool doCharactersExist = !Regex.IsMatch(code, $"[^{availableColorsString}]");
            if (doCharactersExist || code.Length == codeLength)
            {
                List<string> combinations = new List<string>();
                AskAI(combinations, code);
            }
            else
            {
                Console.WriteLine($"{StaticConsoleTexts.WrongCode}\n");
                AskForCode();
            }
        }

        /// <summary>
        /// Asks the AI for a guess.
        /// </summary>
        /// <param name="combinations">Combinations left.</param>
        /// <param name="code">Secret code that user came up with.</param>
        private void AskAI(List<string> combinations, string code)
        {
            computerRound++;

            if (computerRound == timeLimit)
            {
                Console.WriteLine(DynamicConsoleTexts.GetComputerLostInformation(computerRound, code));
                Console.ReadKey();
                DisplayStartingWindow();
            }

            Tuple<List<string>, string> answer = AI.PlayWithAI(combinations, code);

            Console.Beep();
            Console.Clear();
            Console.WriteLine(StaticConsoleTexts.ComputerAnswer);

            foreach (char color in answer.Item2.ToCharArray())
            {
                WriteColor(color);
            }

            Console.WriteLine($"\n{StaticConsoleTexts.IsCorrect}");

            foreach (char color in code.ToCharArray())
            {
                WriteColor(color);
            }

            AskUserIfTheAnswerIsCorrect(answer, code);
        }

        /// <summary>
        /// Ask the user whether the answer computer came up with was correct.
        /// </summary>
        /// <param name="computerAnswer">Contains computer guess and a list of combinations left.</param>
        /// <param name="code">Secret code that user came up with.</param>
        private void AskUserIfTheAnswerIsCorrect(Tuple<List<string>, string> computerAnswer, string code)
        {
            Console.WriteLine("\n\n");
            char userInput = Console.ReadKey().KeyChar;

            if (userInput == YesOption)
            {
                Console.WriteLine(DynamicConsoleTexts.GetComputerWonInformation(computerRound));
                Console.ReadKey();
                DisplayStartingWindow();
            }
            else if (userInput == NoOption)
            {
                char[] score = AskForScore();
                AskAI(computerAnswer.Item1, code);
            }
            else
            {
                AskUserIfTheAnswerIsCorrect(computerAnswer, code);
            }
        }

        /// <summary>
        /// Ask the user to score computer.
        /// </summary>
        /// <returns>Score that is possible to draw in console.</returns>
        private char[] AskForScore()
        {
            Console.WriteLine("\n");
            Console.WriteLine(StaticConsoleTexts.CorrectAnswers);
            char[] blacks = new string(Answers.CORRECT_ANSWER, int.Parse(Console.ReadLine())).ToCharArray();

            Console.WriteLine(StaticConsoleTexts.CorrectColors);
            char[] whites = new string(Answers.COLOR_EXISTS, int.Parse(Console.ReadLine())).ToCharArray();

            char[] empty = new string(Answers.WRONG_GUESS, codeLength - (blacks.Length + whites.Length)).ToCharArray();

            return blacks.Union(whites).Union(empty).ToArray();
        }

        /// <summary>
        /// Start new game. Display basic information.
        /// </summary>
        private void StartGame()
        {
            game = new Game(codeLength, timeLimit, availableColorsString);
            Console.WriteLine(DynamicConsoleTexts.GetInformationText(game.CodeLength));
            AskForInput();
        }

        /// <summary>
        /// Ask user for his answer.
        /// </summary>
        private void AskForInput()
        {
            int currentRound = game.TimeLimit - game.Round;
            Console.Clear();
            Console.WriteLine(DynamicConsoleTexts.GetNextRoundInformation(game.CodeLength, currentRound));
            GenerateColors(game.User.Rounds);
            TakeInput();
        }

        /// <summary>
        /// Take the user's input and check if it's correct.
        /// </summary>
        private void TakeInput()
        {
            string input = Console.ReadLine();
            bool doCharactersExist = !Regex.IsMatch(input, $"[^{availableColorsString}]");

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

            if (option == YesOption)
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
        private void GenerateColors(List<Round> rounds)
        {
            foreach (Round round in rounds)
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

                case Colors.DARK_YELLOW:
                    return ConsoleColor.DarkYellow;

                case Colors.DARK_RED:
                    return ConsoleColor.DarkRed;

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