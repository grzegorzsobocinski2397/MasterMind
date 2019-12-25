using MasterMind.WPF.ViewModels;
using System.Windows.Controls;

namespace MasterMind.WPF.Pages
{
    /// <summary>
    /// Interaction logic for GamePage.xaml
    /// </summary>
    public partial class GamePage : Page
    {
        public GamePage()
        {
            InitializeComponent();

            DataContext = new GameViewModel();
        }
    }
}
