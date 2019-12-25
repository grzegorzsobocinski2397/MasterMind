namespace MasterMind.Models
{
    /// <summary>
    /// Contains information about the round.
    /// </summary>
    public class Round
    {
        #region Public Properties

        /// <summary>
        /// Contains what player wrote. For example, 'cmyk'.
        /// </summary>
        public char[] Input { get; }

        /// <summary>
        /// Contains the tip for the player. For example, 'wwwb'.
        /// </summary>
        public char[] Output { get; }

        #endregion Public Properties

        #region Constructor

        /// <summary>
        /// Creates new instance of a round.
        /// </summary>
        /// <param name="input">What player wrote.</param>
        /// <param name="output">Tip for the player.</param>
        public Round(char[] input, char[] output)
        {
            Input = input;
            Output = output;
        }

        #endregion Constructor
    }
}