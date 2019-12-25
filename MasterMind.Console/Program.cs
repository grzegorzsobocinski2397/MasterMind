namespace MasterMind.ConsoleApp
{
    public class Program
    {
        /// <summary>
        /// Create instance of <see cref="ConsoleGameHandler"/> and start new game.
        /// </summary>
        private static void Main()
        {
            ConsoleGameHandler consoleGame = new ConsoleGameHandler();
            consoleGame.SetStartScreen();
        }
    }
}