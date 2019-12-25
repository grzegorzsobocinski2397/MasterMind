using MasterMind.WPF.Models;
using MasterMind.WPF.ViewModels.Base;
using System;
using System.Windows.Input;

namespace MasterMind.WPF.ViewModels
{
    internal class StartViewModel : BaseViewModel
    {
        #region Commands

        /// <summary>
        /// User clicked the 'x' icon.
        /// </summary>
        public ICommand CloseCommand { get; set; }

        /// <summary>
        /// User clicked the 'Start' button.
        /// </summary>
        public ICommand StartCommand { get; set; }

        #endregion Commands

        #region Constructors
        /// <summary>
        /// Set the methods for commands.
        /// </summary>
        public StartViewModel()
        {
            CloseCommand = new RelayCommand(() => CloseApplication());
            StartCommand = new RelayCommand(() => StartGame());
        }

        #endregion Constructors
        #region Private Methods
        /// <summary>
        /// Move user to new page and start the game.
        /// </summary>
        private void StartGame()
        {
            ChangePage(ApplicationPage.Game);
        }
        /// <summary>
        /// Close the application window.
        /// </summary>
        private void CloseApplication()
        {
            Environment.Exit(0);
        }
        #endregion
    }
}