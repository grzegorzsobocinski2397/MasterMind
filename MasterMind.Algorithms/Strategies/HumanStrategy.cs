using MasterMind.Algorithms.Resources;
using MasterMind.Models;
using System;
using System.Collections.Generic;

namespace MasterMind.Algorithms.Strategies
{
    /// <summary>
    /// This is the 3rd strategy. Should be slower than the 4th one but I didn't know how to implement human-like actions.
    /// This is just an algorythm that finishes the game very fast.
    /// </summary>
    public class HumanStrategy : BaseStrategy
    {
        #region Constructor

        /// <summary>
        /// Initialize this strategy. Set the amount of tests and code length.
        /// </summary>
        /// <param name="numberOfTests">How many tests have to be run for this strategy</param>
        /// <param name="length">Length of the code.</param>
        public HumanStrategy(int numberOfTests, int length) : base(numberOfTests, length)
        {
            Name = StrategyNames.Human;
        }

        /// <summary>
        /// Initialize the strategy to play against humans.
        /// </summary>
        /// <param name="length">Length of the code.</param>
        public HumanStrategy(int length) : base(length) { }

        /// <summary>
        /// Initialize the strategy to play against humans with parameters.
        /// </summary>
        /// <param name="length">Length of the code.</param>
        /// <param name=availableColors">Available colors in a code.</param>
        public HumanStrategy(int length, string availableColors) : base(length, availableColors) { }

        #endregion Constructor

        #region Public Methods

        /// <summary>
        /// Ask the AI to guess the code.
        /// </summary>
        /// <param name="combinations">List of combinations remaining.</param>
        /// <param name="secret">Secret code that is used only to count the score in standard Mastermind style. f(b,w)</param>
        /// <returns>A tuple that contains combinations and the AI's guess.</returns>
        public Tuple<List<string>, string> PlayWithAI(List<string> combinations, string secret)
        {
            combinations = combinations.Count == 0 ? RandomizeList(Combinations) : combinations;

            string testCode = combinations[0];

            combinations = FilterCombinations(combinations, testCode, secret);

            return new Tuple<List<string>, string>(combinations, testCode);
        }

        #endregion Public Methods

        #region Protected Methods

        /// <summary>
        /// Run tests number of times specified.
        /// </summary>
        /// <returns>Overall score and information about performed tests.</returns>
        protected override int RunStrategy()
        {
            Game.StartGame();
            List<string> combinations = RandomizeList(Combinations);
            int counter = 0;

            while (Game.Status != GameStatus.Won)
            {
                string testCode = combinations[0];
                Game.CheckCode(testCode);
                // Give the previous code to count the score as MasterMind standard score.
                combinations = FilterCombinations(combinations, testCode, Game.Code);

                if (Game.Status != GameStatus.Won)
                    counter++;
            }

            return counter;
        }

        #endregion Protected Methods
    }
}