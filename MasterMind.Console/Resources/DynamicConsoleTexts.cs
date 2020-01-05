namespace MasterMind.ConsoleApp.Resources
{
    /// <summary>
    /// Generates dynamic console texts. Used to make <see cref="ConsoleGameHandler"/> more readable.
    /// </summary>
    internal static class DynamicConsoleTexts
    {
        #region Internal Static Methods

        /// <summary>
        /// Create text information about basic rules of the game.
        /// </summary>
        /// <param name="codeLength">Length of the code generated.</param>
        /// <returns>Information text with basic rules of the game.</returns>
        internal static string GetInformationText(int codeLength)
        {
            return $"\nGra rozpoczęta. Komputer wylosował kod o długości {codeLength}. Kody kolorów: red (r), yellow (y), green (g), blue (b), magenta (m), cyan (c) oraz kolory dostępne tylko po wybraniu parametrów: dark yellow (q), dark red (i) = r,y, g, b, m, c, q, i\n W naszej aplikacji wyniki przedstawione są jako: szary kolor - dobrze odgadnięta pozycja i kolor, biały - dobrze odganięty kolor oraz ciemnoczerwony - kolor nie występuje w kodzie.";
        }

        /// <summary>
        /// Create text information about next round informing the user about code length and rounds left.
        /// </summary>
        /// <param name="codeLength">Length of the code generated.</param>
        /// <param name="round">Number of rounds left.</param>
        /// <returns>Information text about next round.</returns>
        internal static string GetNextRoundInformation(int codeLength, int round)
        {
            return $"\nWpisz proszę swoją odpowiedź o maksymalnej długości {codeLength}. Pozostało Ci {round} prób.\n";
        }

        /// <summary>
        /// Create text information about player's win.
        /// </summary>
        /// <param name="round">Current round in which player won.</param>
        /// <returns>Information text about player's win.</returns>
        internal static string GetWinningInformation(int round)
        {
            return $"Gratulacje! Odgadłeś kod :) Zajęlo Ci to {round} prób.";
        }

        /// <summary>
        /// Create text information about player's loss.
        /// </summary>
        /// <param name="round">Current round in which player lost.</param>
        /// <param name="code">Correct code, which user didn't guess right.</param>
        /// <returns>Information text about user's loss.</returns>
        internal static string GetLosingInformation(int round, string code)
        {
            return $"Niestety to koniec gry. Nie udało Ci się odgadnąć hasła pomimo {round} prób. A oto kod: {code}. Prosty nieprawdaż?";
        }

        /// <summary>
        /// Create text information about previous guess.
        /// </summary>
        /// <param name="correctAnswersCount">Pin at correct position and with correct color.</param>
        /// <param name="correctColorsCount">Pin at incorrect position but with correct color.</param>
        /// <param name="badAnswerCount">Pin at incorrect position and with incorrect color.</param>
        /// <returns>Information text about previous guess.</returns>
        internal static string GetAnswerOutput(int correctAnswersCount, int correctColorsCount, int badAnswerCount)
        {
            return $" {correctAnswersCount} poprawnie odganiętych pozycji i kolorów, {correctColorsCount} - poprawnie odgadniętych kolorów, {badAnswerCount} - złych odpowiedzi";
        }

        /// <summary>
        /// Create text information asking for a code in mode which computer guesses code.
        /// </summary>
        /// <param name="length">Length of the code required.</param>
        /// <param name="characters">Available characters</param>
        /// <returns>Information asking for a code in mode which computer guesses code</returns>
        internal static string GetAskForCodeInformation(int length, string characters)
        {
            return $"Wymyśl kod o długości {length} i znakach {characters}.";
        }

        /// <summary>
        /// Create text information about computer's loss.
        /// </summary>
        /// <param name="round">How many rounds have passed.</param>
        /// <param name="code">What was the code.</param>
        /// <returns>Text information about computer's loss</returns>
        internal static string GetComputerLostInformation(int round, string code)
        {
            return $"Nadszedł koniec gry. Komputerowi nie udało się odgadnąć hasła pomimo {round} prób. A oto kod: {code}.";
        }

        /// <summary>
        /// Create text information about computer's win.
        /// </summary>
        /// <param name="round">How many rounds have passed.</param>
        /// <returns>Text information about computer's win.</returns>
        internal static string GetComputerWonInformation(int round)
        {
            return $"Komputer wygrał po {round} próbach!";
        }

        #endregion Internal Static Methods
    }
}