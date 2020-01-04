using MasterMind.Models;
using System.Collections.Generic;
using System.Linq;

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
            Name = "Human Strategy";
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

        #region Private Methods

        /// <summary>
        /// Creates a new list of combinations that would give the same score as previously used one.
        /// </summary>
        /// <param name="combinations">List of possibile combinations.</param>
        /// <param name="previousGuess">Code that was used in as previous guess.</param>
        /// <returns>Filtered list of combinaions.</returns>
        private List<string> FilterCombinations(List<string> combinations, string previousGuess)
        {
            List<string> filteredCombinations = new List<string>();

            var etestet = GetStandardMasterMindScore(previousGuess, Game.Code);
            for (int i = 0; i < combinations.Count; i++)
            {
                int[] output = GetStandardMasterMindScore(combinations[i], string.Concat(previousGuess));

                if (Enumerable.SequenceEqual(etestet, output))
                {
                    filteredCombinations.Add(combinations[i]);
                }
            }

            return filteredCombinations;
        }

        /// <summary>
        /// Creates a standard MasterMind score which is count of whites and blacks.
        /// </summary>
        /// <param name="guess">Current code guess.</param>
        /// <param name="previousGuess">Code that was used in as previous guess.</param>
        /// <returns>A standard score of MasterMind game.</returns>
        private int[] GetStandardMasterMindScore(string guess, string previousGuess)
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

        #endregion Private Methods
    }
}