using MasterMind.Models;
using MasterMind.WPF.Models;
using MasterMind.WPF.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace MasterMind.WPF.ViewModels
{
    internal class GameViewModel : BaseViewModel
    {
        #region Constant Fields

        /// <summary>
        /// Contains all the available colors in the game Mastermind..
        /// </summary>
        private const string AvailableColorsString = "rygbmc";

        #endregion Constant Fields

        #region Private Fields

        /// <summary>
        /// Instance of the Mastermind game.
        /// </summary>
        private Game game;

        #endregion Private Fields

        #region Public Properties

        public List<DesktopRound> Rounds { get; set; }

        /// <summary>
        /// Contains the information about current round.
        /// </summary>
        public string RoundInformation { get; set; }

        /// <summary>
        /// Contains the player's input.
        /// </summary>
        public string InputValue { get; set; }

        /// <summary>
        /// Contains information about what player did wrong.
        /// </summary>
        public string ErrorInformation { get; set; }

        /// <summary>
        /// User typed in incorrect input.
        /// </summary>
        public bool IsInputWrong { get; set; }

        #endregion Public Properties

        #region Commands

        /// <summary>
        /// User clicked the 'x' icon.
        /// </summary>
        public ICommand CloseCommand { get; set; }

        /// <summary>
        /// User clicked the 'go' icon. Send the answer to Game.
        /// </summary>
        public ICommand SendInputCommand { get; set; }

        #endregion Commands

        #region Constructors

        /// <summary>
        /// Set the methods for commands.
        /// </summary>
        public GameViewModel()
        {
            CloseCommand = new RelayCommand(() => CloseApplication());
            SendInputCommand = new RelayCommand(() => CheckButtonAction());

            game = new Game();
            Rounds = new List<DesktopRound>();
            RoundInformation = GetRoundInformationText();
        }

        #endregion Constructors

        #region Private Methods

        /// <summary>
        /// Close the application window.
        /// </summary>
        private void CloseApplication()
        {
            Environment.Exit(0);
        }

        private void SendInput()
        {
            game.CheckCode(InputValue);
            InputValue = "";
            Rounds = game.User.Rounds.Select(r => new DesktopRound(r)).ToList();

            if (game.Status == GameStatus.Lost)
            {
                RoundInformation = $"You've lost! The code was {game.Code}. Click Go to play again.";
                return;
            }
            if (game.Status == GameStatus.Won)
            {
                RoundInformation = "You've won! Click Go to play again.";
                return;
            }

            RoundInformation = GetRoundInformationText();
        }

        private void StartNewGame()
        {
            game.StartGame();
            Rounds = new List<DesktopRound>();
            RoundInformation = "";
        }

        private void CheckButtonAction()
        {
            if (game.Status != GameStatus.Ongoing)
            {
                StartNewGame();
            }
            else
            {
                CheckInput();
            }
        }

        private void CheckInput()
        {
            if (InputValue.Length != game.CodeLength)
            {
                SetError("Length of the input was incorrect.");
                return;
            }

            bool doCharactersExist = !Regex.IsMatch(InputValue, $"[^{AvailableColorsString}]");

            if (!doCharactersExist)
            {
                SetError("There were incorrect characters written.");
                return;
            }

            IsInputWrong = false;
            ErrorInformation = null;
            SendInput();
        }

        private void SetError(string error)
        {
            IsInputWrong = true;
            ErrorInformation = error;
        }

        private string GetRoundInformationText()
        {
            return $"Próba {game.Round}/{game.TimeLimit}. Ilość znaków w kodzie: {game.CodeLength}";
        }

        #endregion Private Methods
    }
}