using MasterMind.Models;
using System;

namespace MasterMind.ConsoleApp.Helpers
{
    /// <summary>
    /// Helper class that draws the rectangles for input and output of user's round.
    /// </summary>
    internal static class ConsoleColorHelper
    {
        #region Interal Methods

        /// <summary>
        /// Create colorful rectangle for the character.
        /// </summary>
        /// <param name="character">Character available in the application.</param>
        internal static void WriteColor(char character)
        {
            Console.BackgroundColor = GetConsoleColor(character);
            Console.ForegroundColor = GetConsoleColor(character);
            Console.Write($"  ");
            Console.ResetColor();
        }

        #endregion Interal Methods

        #region Private Methods

        /// <summary>
        /// Get colorful rectangle for the character.
        /// </summary>
        /// <param name="character">Character available in the application.</param>
        /// <returns>Color of the console.</returns>
        private static ConsoleColor GetConsoleColor(char character)
        {
            switch (character)
            {
                case Colors.BLUE:
                    return ConsoleColor.Blue;

                case Colors.CYAN:
                    return ConsoleColor.Cyan;

                case Colors.GREEN:
                    return ConsoleColor.Green;

                case Colors.MAGENTA:
                    return ConsoleColor.Magenta;

                case Colors.RED:
                    return ConsoleColor.Red;

                case Colors.YELLOW:
                    return ConsoleColor.Yellow;

                case Colors.DARK_YELLOW:
                    return ConsoleColor.DarkYellow;

                case Colors.DARK_RED:
                    return ConsoleColor.DarkRed;

                case Answers.CORRECT_ANSWER:
                    return ConsoleColor.DarkGray;

                case Answers.COLOR_EXISTS:
                    return ConsoleColor.White;

                case Answers.WRONG_GUESS:
                default:
                    return ConsoleColor.Black;
            }
        }

        #endregion Private Methods
    }
}