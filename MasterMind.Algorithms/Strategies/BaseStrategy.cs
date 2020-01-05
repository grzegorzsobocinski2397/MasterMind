using MasterMind.Algorithms.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MasterMind.Algorithms.Strategies
{
    /// <summary>
    /// Base strategy that contains shared methods and base setup.
    /// </summary>
    public abstract class BaseStrategy
    {
        #region Public Properties

        /// <summary>
        /// Name of the strategy.
        /// </summary>
        public string Name { get; set; }

        #endregion Public Properties

        #region Protected Properties

        /// <summary>
        /// Contains all the available colors.
        /// </summary>
        protected char[] AvailableColors { get; }

        /// <summary>
        /// Instance of the Mastermind game.
        /// </summary>
        protected Game Game { get; }

        /// <summary>
        /// Number of tests that have to be performed of this strategy.
        /// </summary>
        protected int NumberOfTests { get; }

        /// <summary>
        /// Specifies the length of code.
        /// </summary>
        protected int CodeLength { get; }

        /// <summary>
        /// Contains all of the possible combinations for available characters and code length.
        /// </summary>
        protected List<string> Combinations { get; }

        #endregion Protected Properties

        #region Constructor

        /// <summary>
        /// Initialize the <see cref="Game"/> instance with code length specified and time limit of max int value.
        /// </summary>
        /// <param name="numberOfTests">Number of tests that have to be performed of this strategy.</param>
        /// <param name="length">Code length.</param>
        public BaseStrategy(int numberOfTests, int length)
        {
            NumberOfTests = numberOfTests;
            CodeLength = length;
            Game = new Game(length, int.MaxValue);
            Combinations = CreateAllCombinations();
        }

        /// <summary>
        /// Initialize the strategy just for playing against human player.
        /// </summary>
        /// <param name="length">Code length.</param>
        public BaseStrategy(int length)
        {
            CodeLength = length;
            Game = new Game(length, int.MaxValue);
            AvailableColors = Game.AvailableCharacters;
            Combinations = CreateAllCombinations();
        }

        /// <summary>
        /// Initialize the strategy just for playing against human with parameterized options.
        /// </summary>
        /// <param name="length">Code length.</param>
        /// <param name="availableColors">Available colors in the code.</param>
        public BaseStrategy(int length, string availableColors)
        {
            CodeLength = length;
            AvailableColors = availableColors.ToCharArray();
            Game = new Game(length, int.MaxValue);
            Combinations = CreateAllCombinations();
        }

        #endregion Constructor

        #region Internal Methods

        /// <summary>
        /// Run the tests number of times specified in <see cref="NumberOfTests"/>.
        /// </summary>
        /// <returns>Overall score and information about performed tests.</returns>
        internal Result RunTests()
        {
            Result result = new Result();

            for (int i = 0; i < NumberOfTests; i++)
            {
                int numberOfTries = RunStrategy();
                result.AddTestResult(numberOfTries);
            }

            return result;
        }

        #endregion Internal Methods

        #region Protected Methods

        /// <summary>
        /// Creates new Mastermind code.
        /// </summary>
        /// <returns>New Mastermind code.</returns>
        protected string GetCode()
        {
            Game.StartGame();
            return Game.Code;
        }

        /// <summary>
        /// Run the test once.
        /// </summary>
        /// <returns>Number of tries it took to guess correct answer.</returns>
        protected abstract int RunStrategy();

        /// <summary>
        /// Randomize array using Fisher-Yates shuffle.
        /// </summary>
        /// <param name="list">List to be shuffled.</param>
        /// <returns>Shuffled list.</returns>
        protected List<string> RandomizeList(List<string> list)
        {
            Random random = new Random();
            int length = list.Count;

            while (length > 1)
            {
                length--;
                int randomNumber = random.Next(length + 1);
                string value = list[randomNumber];
                list[randomNumber] = list[length];
                list[length] = value;
            }

            return list;
        }

        /// <summary>
        /// Creates a standard MasterMind score which is count of whites and blacks.
        /// </summary>
        /// <param name="guess">Current code guess.</param>
        /// <param name="previousGuess">Code that was used in as previous guess.</param>
        /// <returns>A standard score of MasterMind game.</returns>
        protected int[] GetStandardMasterMindScore(string guess, string previousGuess)
        {
            int black = 0;
            int white = 0;

            bool[] checkedGuess = new bool[CodeLength];
            bool[] checkedSecret = new bool[CodeLength];

            for (int index = 0; index < CodeLength; index++)
            {
                if (guess[index] == previousGuess[index])
                {
                    black++;
                    checkedGuess[index] = checkedSecret[index] = true;
                }
            }

            for (int i = 0; i < CodeLength; i++)
            {
                if (checkedGuess[i])
                    continue;

                for (int j = 0; j < CodeLength; j++)
                {
                    if ((i != j) && !checkedSecret[j] && (guess[i] == previousGuess[j]))
                    {
                        white++;
                        checkedSecret[j] = true;
                        break;
                    }
                }
            }

            return new int[] { black, white };
        }

        /// <summary>
        /// Creates a new list of combinations that would give the same score as previously used one.
        /// </summary>
        /// <param name="combinations">List of possibile combinations.</param>
        /// <param name="previousGuess">Code that was used in as previous guess.</param>
        /// <returns>Filtered list of combinaions.</returns>
        protected List<string> FilterCombinations(List<string> combinations, string previousGuess, string previousSecret)
        {
            List<string> filteredCombinations = new List<string>();

            int[] previousScore = GetStandardMasterMindScore(previousGuess, previousSecret);

            for (int i = 0; i < combinations.Count; i++)
            {
                int[] currentScore = GetStandardMasterMindScore(combinations[i], string.Concat(previousGuess));

                if (Enumerable.SequenceEqual(previousScore, currentScore))
                {
                    filteredCombinations.Add(combinations[i]);
                }
            }

            return filteredCombinations;
        }

        #endregion Protected Methods

        #region Private Methods

        /// <summary>
        /// Generate permutations with repetition.
        /// </summary>
        /// <param name="input">Available characters.</param>
        /// <param name="length">Length of the combination.</param>
        /// <returns></returns>
        private IEnumerable<string> GenerateCombinations(List<char> input, int length)
        {
            if (length <= 0)
                yield return "";
            else
            {
                foreach (char i in input)
                    foreach (var list in GenerateCombinations(input, length - 1))
                        yield return i.ToString() + list;
            }
        }

        /// <summary>
        /// Generates every possible variation of code with length of <see cref="codeLength"/>.
        /// </summary>
        /// <returns>List of all possibile values.</returns>
        private List<string> CreateAllCombinations()
        {
            List<char> availableColors = new List<char>(AvailableColors);
            return new List<string>(GenerateCombinations(availableColors, CodeLength));
        }

        #endregion Private Methods
    }
}