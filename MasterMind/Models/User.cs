using System.Collections.Generic;

namespace MasterMind.Models
{
    public class User
    {
        #region Public Propeties

        /// <summary>
        /// Information about how many games user has won.
        /// </summary>
        public int GamesWon { get; set; }

        /// <summary>
        /// Information about how many games user has lost.
        /// </summary>
        public int GamesLost { get; set; }

        /// <summary>
        /// Contains current's round answers.
        /// </summary>
        public List<Round> Rounds { get; }

        #endregion Public Propeties

        #region Constructors

        /// <summary>
        /// Initialize <see cref="Rounds"/>.
        /// </summary>
        public User()
        {
            Rounds = new List<Round>();
        }

        #endregion Constructors

        #region Public Methods

        /// <summary>
        /// Clear the <see cref="Rounds"/> list.
        /// </summary>
        public void ResetAnswers()
        {
            Rounds.Clear();
        }

        /// <summary>
        /// Saves the round in currently played game.
        /// </summary>
        /// <param name="input">What player wrote.</param>
        /// <param name="output">What tip player got.</param>
        public void SaveRound(char[] input, char[] output)
        {
            Round round = new Round(input, output);
            Rounds.Add(round);
        }

        #endregion Public Methods
    }
}