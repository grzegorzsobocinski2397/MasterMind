using MasterMind.Models;
using System.Collections.Generic;

namespace MasterMind.Algorithms.Strategies
{
    internal class HumanStrategy : BaseStrategy
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

        #endregion Constructor

        #region Protected Methods

        /// <summary>
        /// Run the tests number of times specified.
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
                combinations = FilterCombinations(combinations, testCode);

                if (Game.Status != GameStatus.Won)
                    counter++;
            }

            return counter;
        }

        #endregion Protected Methods
    }
}