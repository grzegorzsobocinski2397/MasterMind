using MasterMind.Models;
using System.Collections.Generic;
using System.Linq;

namespace MasterMind.Algorithms.Strategies
{
    public class CheckFourValuesFirstStrategy : BaseStrategy
    {
        #region Constructor

        /// <summary>
        /// Set the amount of tests.
        /// </summary>
        /// <param name="numberOfTests">How many tests have to be run for this strategy</param>
        public CheckFourValuesFirstStrategy(int numberOfTests, int length) : base(numberOfTests, length)
        {
            Name = "Check Four Values First Strategy";
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
            List<string> firstCodes = new List<string> { "rryy", "rgrg", "bbmm", "bcbc" };
            List<string> combinations = RandomizeList(Combinations).Where(c => !firstCodes.Contains(c)).ToList();
            int counter = 0;

            while (Game.Status != GameStatus.Won)
            {
                string testCode = counter < firstCodes.Count ? firstCodes[counter] : combinations[0];
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