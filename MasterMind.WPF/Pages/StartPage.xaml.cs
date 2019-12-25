using MasterMind.WPF.ViewModels;
using System.Windows.Controls;

namespace MasterMind.WPF.Pages
{
    /// <summary>
    /// Interaction logic for StartPage.xaml
    /// </summary>
    public partial class StartPage : Page
    {
        public StartPage()
        {
            InitializeComponent();

            DataContext = new StartViewModel();
        }
    }
}
