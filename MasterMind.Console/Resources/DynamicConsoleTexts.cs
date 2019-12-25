namespace MasterMind.ConsoleApp.Resources
{
    /// <summary>
    /// Generates dynamic console texts. Used to make <see cref="ConsoleGameHandler"/> more readable.
    /// </summary>
    public static class DynamicConsoleTexts
    {
        #region Public Static Methods

        /// <summary>
        /// Create text information about basic rules of the game.
        /// </summary>
        /// <param name="codeLength">Length of the code generated.</param>
        /// <returns>Information text with basic rules of the game.</returns>
        public static string GetInformationText(int codeLength)
        {
            return $"\nGra rozpoczęta. Komputer wylosował kod o długości {codeLength}. Kody kolorów: red(r),yellow(y), green (g), blue (b), magenta (m), cyan (c) = r,y, g, b, m, c\n";
        }

        /// <summary>
        /// Create text information about next round informing the user about code length and rounds left.
        /// </summary>
        /// <param name="codeLength">Length of the code generated.</param>
        /// <param name="round">Number of rounds left.</param>
        /// <returns>Information text about next round.</returns>
        public static string GetNextRoundInformation(int codeLength, int round)
        {
            return $"\nWpisz proszę swoją odpowiedź o maksymalnej długości {codeLength}. Pozostało Ci {round} prób.\n";
        }

        /// <summary>
        /// Create text information about player's win.
        /// </summary>
        /// <param name="round">Current round in which player won.</param>
        /// <returns>Information text about player's win.</returns>
        public static string GetWinningInformation(int round)
        {
            return $"Gratulacje! Odgadłeś kod :) Zajęlo Ci to {round} prób.";
        }

        /// <summary>
        /// Create text information about player's loss.
        /// </summary>
        /// <param name="round">Current round in which player lost.</param>
        /// <param name="code">Correct code, which user didn't guess right.</param>
        /// <returns>Information text about user's loss.</returns>
        public static string GetLosingInformation(int round, string code)
        {
            return $"Niestety to koniec gry. Nie udało Ci się odgadnąć hasła pomimo {round} prób. A oto kod: {code}. Prosty nieprawdaż?";
        }

        #endregion Public Static Methods
    }
}