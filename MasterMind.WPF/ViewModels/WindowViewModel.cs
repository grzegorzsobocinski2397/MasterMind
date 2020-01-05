using MasterMind.WPF.Models;
using MasterMind.WPF.ViewModels.Base;
using System.Windows;
using System.Windows.Input;

namespace MasterMind.WPF.ViewModels
{
    /// <summary>
    /// View Model for the MainWindow contains basic information about the application such as round corners
    /// or currently active page.
    /// </summary>
    internal class WindowViewModel : BaseViewModel
    {
        #region Private Members

        /// <summary>
        /// The window for this view model
        /// </summary>
        private readonly Window window;

        #endregion Private Members

        #region Public Properties

        /// <summary>
        /// Current page being displayed in the application.
        /// </summary>
        public ApplicationPage CurrentPage { get; set; }

        #endregion Public Properties

        #region Commands

        /// <summary>
        /// Closes the application
        /// </summary>
        public ICommand CloseWindowCommand { get; set; }

        #endregion Commands

        #region Constructor

        public WindowViewModel(Window window)
        {
            // Binds the window to the view model
            this.window = window;

            // Creates commands
            CloseWindowCommand = new RelayCommand(() => window.Close());

            // Sets the first page as ChooseGamePage
            CurrentPage = ApplicationPage.Start;
        }

        #endregion Constructor
    }
}