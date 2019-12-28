namespace MasterMind.WPF.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Answer
    {
        #region Public Properties
        /// <summary>
        /// Color of the answer. Range of colors varies on the MasterMind settings.
        /// </summary>
        public char Color { get; set; }
        #endregion
        #region Constructor
        /// <summary>
        /// Contains information about one of the player's output or input.
        /// </summary>
        /// <param name="color">Color of the answer</param>
        public Answer(char color)
        {
            Color = color;
        }
        #endregion
    }
}
