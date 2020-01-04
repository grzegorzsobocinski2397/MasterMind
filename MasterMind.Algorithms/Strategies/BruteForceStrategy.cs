using MasterMind.Models;
using System.Collections.Generic;

namespace MasterMind.Algorithms.Strategies
{
    public class BruteForceStrategy : BaseStrategy
    {
        #region Constructor

        /// <summary>
        /// Set the amount of tests.
        /// </summary>
        /// <param name="numberOfTests">How many tests have to be run for this strategy</param>
        public BruteForceStrategy(int numberOfTests, int length) : base(numberOfTests, length)
        {
            Name = "Brute force strategy";
        }

        #endregion Constructor

        #region Protected Methods

        /// <summary>
        /// Run the tests number of times specified.
        /// </summary>
        /// <returns>Overall score and information about performed tests.</returns>
        protected override int RunStrategy()
        {
            List<string> combinations = RandomizeList(Combinations);
            int counter = 0;
            Game.StartGame();

            while (Game.Status != GameStatus.Won)
            {
                string testCode = combinations[counter];
                Game.CheckCode(testCode);

                if (Game.Status != GameStatus.Won)
                    counter++;
            }

            return counter;
        }

        #endregion Protected Methods
    }
}