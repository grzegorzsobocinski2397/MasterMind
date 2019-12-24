using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public List<char[]> CurrentAnswers { get; set; }
        #endregion
    }
}
