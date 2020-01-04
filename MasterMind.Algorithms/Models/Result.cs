using System.Collections.Generic;
using System.Linq;

namespace MasterMind.Algorithms.Models
{
    /// <summary>
    /// Contains information about performance of performed tests.
    /// </summary>
    public class Result
    {
        #region Public Properties

        /// <summary>
        /// List of all performed tests and how many tries did it take to guess correct answer.
        /// </summary>
        private readonly List<int> testResults = new List<int>();

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Adds another test result into list. Add 1 to change it from zero indexed number.
        /// </summary>
        /// <param name="numberOfTries">How many tries did it take to guess correct answer.</param>
        public void AddTestResult(int numberOfTries)
        {
            testResults.Add(numberOfTries + 1);
        }

        /// <summary>
        /// Searches for the test with the highest number of tries.
        /// </summary>
        /// <returns>Number of tries in test with the highest number of tries.</returns>
        public int GetMax() => testResults.Max();

        /// <summary>
        /// Searches for the test with the lowest number of tries.
        /// </summary>
        /// <returns>Number of tries in test with the lowest number of tries.</returns>
        public int GetMin() => testResults.Min();

        /// <summary>
        /// Calculates an average of performed tests.
        /// </summary>
        /// <returns>Average number of tries for specific strategy.</returns>
        public double GetAverage() => testResults.Average();

        #endregion Public Methods
    }
}