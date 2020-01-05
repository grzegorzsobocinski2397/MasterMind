using MasterMind.Models;
using System;
using System.Collections.Generic;

namespace MasterMind.Algorithms.Strategies
{
    public class HumanStrategy : BaseStrategy
    {
        #region Constructor

        /// <summary>
        /// Set the amount of tests.
        /// </summary>
        /// <param name="numberOfTests">How many tests have to be run for this strategy</param>
        public HumanStrategy(int numberOfTests, int length) : base(numberOfTests, length)
        {
            Name = "Human Strategy (little too fast)";
        }
        /// <summary>
        /// Initialize the strategy to play against humans.
        /// </summary>
        /// <param name="length">Code length.</param>
        public HumanStrategy(int length) : base(length) { }

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