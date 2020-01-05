using MasterMind.Algorithms.Resources;
using MasterMind.Models;
using System.Collections.Generic;
using System.Linq;

namespace MasterMind.Algorithms.Strategies
{
    /// <summary>
    /// This is the 4th strategy. First test 4 values and then try guessing. Quite fast.
    /// </summary>
    public class CheckFourValuesFirstStrategy : BaseStrategy
    {
        #region Constructor

        /// <summary>
        /// Initialize this strategy. Set the amount of tests and code length.
        /// </summary>
        /// <param name="numberOfTests">How many tests have to be run for this strategy</param>
        /// <param name="length">Length of the code.</param>
        public CheckFourValuesFirstStrategy(int numberOfTests, int length) : base(numberOfTests, length)
        {
            Name = StrategyNames.FourValues;
        }

        #endregion Constructor

        #region Protected Methods

        /// <summary>
        /// Run the tests number of times specified. First test 4 codes and then try guessing.
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