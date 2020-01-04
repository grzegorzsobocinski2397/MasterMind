using MasterMind.Models;
using System.Collections.Generic;
using System.Linq;

namespace MasterMind.Algorithms.Strategies
{
    public class ColorEliminationStrategy : BaseStrategy
    {
        #region Constructor

        /// <summary>
        /// Set the amount of tests.
        /// </summary>
        /// <param name="numberOfTests">How many tests have to be run for this strategy</param>
        public ColorEliminationStrategy(int numberOfTests, int length) : base(numberOfTests, length)
        {
            Name = "Color Elimination Strategy";
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

        private List<string> EliminateColors()
        {
            List<string> combinations = Combinations;

            foreach (char color in Game.AvailableColors)
            {
                string code = new string(color, CodeLength);
                Game.CheckCode(code);
                bool isTheColorPresent = Game.GetLastRoundsOutput()[0] != Answers.WRONG_GUESS;

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