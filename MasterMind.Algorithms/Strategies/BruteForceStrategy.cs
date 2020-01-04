using MasterMind.Algorithms.Models;
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

        #region Public Methods

        /// <summary>
        /// Run the test once.
        /// </summary>
        /// <returns>Number of tries it took to guess correct answer.</returns>
        public override Result RunTests()
        {
            Result result = new Result();

            for (int i = 0; i < NumberOfTests; i++)
            {
                int numberOfTries = RunStrategy();
                result.AddTestResult(numberOfTries);
            }

            return result;
        }

        #endregion Public Methods

        #region Protected Methods

        /// <summary>
        /// Run the tests number of times specified.
        /// </summary>
        /// <returns>Overall score and information about performed tests.</returns>
        protected override int RunStrategy()
        {
            List<string> combinations = Combinations;
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