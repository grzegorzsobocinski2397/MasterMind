using System.Collections.Generic;
using System.Linq;

namespace MasterMind.Algorithms.Models
{
    /// <summary>
    /// Contains information about performance of performed tests.
    /// </summary>
    internal class Result
    {
        #region Private Fields

        /// <summary>
        /// List of all performed tests and how many tries did it take to guess correct answer.
        /// </summary>
        private readonly List<int> testResults = new List<int>();

        #endregion Private Fields

        #region Internal Methods

        /// <summary>
        /// Adds another test result into list. Add 1 to change it from zero indexed number.
        /// </summary>
        /// <param name="numberOfTries">How many tries did it take to guess correct answer.</param>
        internal void AddTestResult(int numberOfTries)
        {
            testResults.Add(numberOfTries + 1);
        }

        /// <summary>
        /// Searches for the test with the highest number of tries.
        /// </summary>
        /// <returns>Number of tries in test with the highest number of tries.</returns>
        internal int GetMax() => testResults.Max();

        /// <summary>
        /// Searches for the test with the lowest number of tries.
        /// </summary>
        /// <returns>Number of tries in test with the lowest number of tries.</returns>
        internal int GetMin() => testResults.Min();

        /// <summary>
        /// Calculates an average of performed tests.
        /// </summary>
        /// <returns>Average number of tries for specific strategy.</returns>
        internal double GetAverage() => testResults.Average();

        #endregion Internal Methods
    }
}