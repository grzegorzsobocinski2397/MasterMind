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
    class WindowViewModel : BaseViewModel
    {
        #region Private Members
        /// <summary>
        /// The window for this view model
        /// </summary>
        private readonly Window window;
        /// <summary>
        /// Radius of the edges
        /// </summary>
        private readonly int windowCorner = 10;
        /// <summary>
        /// Outer margin for the drop shadow
        /// </summary>
        private readonly int outerMargin = 10;
        #endregion
        #region Public Properties
        /// <summary>
        /// Outer margin for the drop shadow
        /// </summary>
        public Thickness OuterMarginThickness => new Thickness(outerMargin);
        /// <summary>
        /// Radius of the edges
        /// </summary>
        public CornerRadius WindowCornerRadius => new CornerRadius(windowCorner);
        /// <summary>
        /// Current page being displayed in the application.
        /// </summary>
        public ApplicationPage CurrentPage { get; set; }
        #endregion
        #region Commands
        /// <summary>
        /// Closes the application
        /// </summary>
        public ICommand CloseWindowCommand { get; set; }
        #endregion
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
        #endregion
    }
}
