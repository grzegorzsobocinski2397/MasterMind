namespace MasterMind.Models
{
    /// <summary>
    /// Contains information about current game status.
    /// </summary>
    public enum GameStatus
    {
        /// <summary>
        /// Default enum.
        /// </summary>
        None,
        /// <summary>
        /// The game hasn't started yet.
        /// </summary>
        Unstarted,
        /// <summary>
        /// User/computer won the game.
        /// </summary>
        Won,
        /// <summary>
        /// User/computer lost the game.
        /// </summary>
        Lost,
        /// <summary>
        /// Game is currently in progress.
        /// </summary>
        Ongoing
    }
}
