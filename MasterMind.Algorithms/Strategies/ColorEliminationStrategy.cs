using MasterMind.Algorithms.Resources;
using MasterMind.Models;
using System.Collections.Generic;
using System.Linq;

namespace MasterMind.Algorithms.Strategies
{
    /// <summary>
    /// This is the 2nd strategy. First eliminate colors that don't exist in the code and then try guessing by brute force.
    /// </summary>
    public class ColorEliminationStrategy : BaseStrategy
    {
        #region Constructor

        /// <summary>
        /// Initialize this strategy. Set the amount of tests and code length.
        /// </summary>
        /// <param name="numberOfTests">How many tests have to be run for this strategy</param>
        /// <param name="length">Length of the code.</param>
        public ColorEliminationStrategy(int numberOfTests, int length) : base(numberOfTests, length)
        {
            Name = StrategyNames.ColorElimination;
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
            List<string> combinations = EliminateColors();
            int counter = 0;

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

        #region Private Methods

        /// <summary>
        /// Remove colors that are definetly not used in the code.
        /// </summary>
        /// <returns>Filtered list.</returns>
        private List<string> EliminateColors()
        {
            List<string> combinations = RandomizeList(Combinations);

            foreach (char color in Game.AvailableColors)
            {
                string code = new string(color, CodeLength);
                Game.CheckCode(code);
                bool isTheColorPresent = Game.GetLastRound().Output[0] != Answers.WRONG_GUESS;

                if (!isTheColorPresent)
                {
                    combinations = combinations.Where(c => !c.Contains(color)).ToList();
                }
            }

            return combinations;
        }

        #endregion Private Methods
    }
}