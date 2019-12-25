using MasterMind.WPF.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MasterMind.WPF.ViewModels
{
    class GameViewModel : BaseViewModel
    {
        #region Commands

        /// <summary>
        /// User clicked the 'x' icon.
        /// </summary>
        public ICommand CloseCommand { get; set; }
        #endregion
        #region Constructors

        /// <summary>
        /// Set the methods for commands.
        /// </summary>
        public GameViewModel()
        {
            CloseCommand = new RelayCommand(() => CloseApplication());
        }
        #endregion
        #region Public Methods

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
