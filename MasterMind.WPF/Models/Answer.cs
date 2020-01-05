namespace MasterMind.WPF.Models
{
    /// <summary>
    /// Contains information about user answer. It's used here, because I couldn't iterate over List of chars in WPF page.
    /// </summary>
    public class Answer
    {
        #region Public Properties

        /// <summary>
        /// Color of the answer. Range of colors varies on the MasterMind settings.
        /// </summary>
        public char Color { get; set; }

        #endregion Public Properties

        #region Constructor

        /// <summary>
        /// Contains information about one of the player's output or input.
        /// </summary>
        /// <param name="color">Color of the answer</param>
        public Answer(char color)
        {
            Color = color;
        }

        #endregion Constructor
    }
}