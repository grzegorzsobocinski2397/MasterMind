namespace MasterMind.Models
{
    /// <summary>
    /// Contains colors of answers in game Mastermind.
    /// </summary>
    public class Answers
    {
        /// <summary>
        /// Pin was at a correct position with correct color.
        /// </summary>
        public const char CORRECT_ANSWER = '1';
        /// <summary>
        /// Pin was at an incorrect position but the color did exist in the code.
        /// </summary>
        public const char COLOR_EXISTS = '0';
        /// <summary>
        /// The color wasn't used in the code. 
        /// </summary>
        public const char WRONG_GUESS = 'e';
    }
}