using MasterMind.Models;
using System;
using System.Linq;

namespace MasterMind
{
    public class Game
    {
        #region Const Fields

        /// <summary>
        /// Default length of the code that the user has to guess.
        /// </summary>
        private const int CODE_LENGTH = 4;

        /// <summary>
        /// Default amount of guesses user can make.
        /// </summary>
        private const int TIME_LIMIT = 9;

        #endregion Readonly Fields

        #region Public Properties

        /// <summary>
        /// Length of the code that the user has to guess.
        /// </summary>
        public int CodeLength { get; }

        /// <summary>
        /// Amount of guesses user can make.
        /// </summary>
        public int TimeLimit { get; }

        /// <summary>
        /// Contains all available colors in the game.
        /// </summary>
        public char[] AvailableColors { get; } = { Colors.Red, Colors.Green, Colors.Blue, Colors.Cyan, Colors.Magenta, Colors.Yellow };

        /// <summary>
        /// Code that is currently used in the game.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Current number of user try.
        /// </summary>
        public int Round { get; set; }

        /// <summary>
        /// Status of the current game.
        /// </summary>
        public GameStatus Status { get; set; } = GameStatus.Unstarted;

        #endregion Public Properties

        #region Constructors

        /// <summary>
        /// Change the settings on creation.
        /// </summary>
        /// <param name="codeLength">Length of the that the user has to guess.</param>
        /// <param name="timeLimit">Amount of guesses user can make.</param>
        public Game(int codeLength, int timeLimit)
        {
            CodeLength = codeLength;
            TimeLimit = timeLimit;
            StartGame();
        }

        /// <summary>
        /// Take default settings.
        /// </summary>
        public Game()
        {
            CodeLength = CODE_LENGTH;
            TimeLimit = TIME_LIMIT;
            StartGame();
        }

        #endregion Constructors

        #region Public Methods

        /// <summary>
        /// Creates new game with limits described earlier.
        /// </summary>
        public void StartGame()
        {
            SetDefaults();
        }

        /// <summary>
        /// Check how the user guess matches <see cref="Code"/>.
        /// </summary>
        /// <param name="input">User's input.</param>
        public string CheckCode(string input)
        {
            char[] userColors = input.ToCharArray();
            char[] code = Code.ToCharArray();
            char[] answer = new char[CodeLength];

            for (int index = 0; index < CodeLength; index++)
            {
                if (userColors[index] == code[index])
                {
                    answer[index] = Answers.Black;
                }
                else if (userColors.Contains(userColors[index]))
                {
                    answer[index] = Answers.White;
                }
                else
                {
                    answer[index] = Answers.Empty;
                }
            }

            if (answer.All(c => c == Answers.Black))
            {
                Status = GameStatus.Won;
            }

            if (Round > TimeLimit)
            {
                Status = GameStatus.Lost;
            }

            Round++;

            return RandomizeArray(answer);
        }

        #endregion Public Methods

        #region Private Members

        /// <summary>
        /// Shuffles the elements inside array and returns code split by <see cref="CodeLength"/>
        /// </summary>
        /// <param name="array">Unsorted char[] array containg colors or answers</param>
        /// <returns>Joined string that has length of <see cref="CodeLength"/></returns>
        private string RandomizeArray(char[] array)
        {
            Random random = new Random();
            return string.Concat(array.OrderBy(c => random.Next()).Take(CodeLength));
        }

        private void SetDefaults()
        {
            Status = GameStatus.Ongoing;
            Code = RandomizeArray(AvailableColors);
            Round = 0;
        }

        #endregion Private Members
    }
}