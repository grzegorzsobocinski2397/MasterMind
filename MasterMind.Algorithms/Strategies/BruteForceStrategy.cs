using MasterMind.Algorithms.Resources;
using MasterMind.Models;
using System.Collections.Generic;

namespace MasterMind.Algorithms.Strategies
{
    /// <summary>
    /// This is the first strategy. Test every possible variation of code. Very inefficient.
    /// </summary>
    public class BruteForceStrategy : BaseStrategy
    {
        #region Constructor

        /// <summary>
        /// Initialize this strategy. Set the amount of tests and code length.
        /// </summary>
        /// <param name="numberOfTests">How many tests have to be run for this strategy</param>
        /// <param name="length">Length of the code.</param>
        public BruteForceStrategy(int numberOfTests, int length) : base(numberOfTests, length)
        {
            Name = StrategyNames.BruteForce;
        }

        #endregion Constructor

        #region Protected Methods

        /// <summary>
        /// Run the tests number of times specified. Test every possible variation until correct guess.
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