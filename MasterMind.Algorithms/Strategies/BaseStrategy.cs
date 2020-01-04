using MasterMind.Algorithms.Models;
using System.Collections.Generic;

namespace MasterMind.Algorithms.Strategies
{
    public abstract class BaseStrategy
    {
        #region Public Properties

        /// <summary>
        /// Name of the strategy.
        /// </summary>
        public string Name { get; set; }

        #endregion
        #region Protected Properties

        /// <summary>
        /// Instance of the Mastermind game.
        /// </summary>
        protected Game Game { get; }

        /// <summary>
        /// How many tests have to be performed of this strategy.
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
        public BaseStrategy(int numberOfTests, int length)
        {
            NumberOfTests = numberOfTests;
            CodeLength = length;
            Game = new Game(length, int.MaxValue);
            Combinations = CreateAllCombinations();
        }

        #endregion Constructor

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
        /// Run the tests number of times specified in <see cref="NumberOfTests"/>.
        /// </summary>
        /// <returns>Overall score and information about performed tests.</returns>
        public Result RunTests()
        {
            Result result = new Result();

            for (int i = 0; i < NumberOfTests; i++)
            {
                int numberOfTries = RunStrategy();
                result.AddTestResult(numberOfTries);
            }

            return result;
        }

        /// <summary>
        /// Generates every possible variation of code with length of <see cref="codeLength"/>.
        /// </summary>
        /// <returns>List of all possibile values.</returns>
        protected List<string> CreateAllCombinations()
        {
            List<char> availableColors = new List<char>(Game.AvailableColors);
            return new List<string>(GenerateCombinations(availableColors, CodeLength));
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

        #endregion Private Methods
    }
}