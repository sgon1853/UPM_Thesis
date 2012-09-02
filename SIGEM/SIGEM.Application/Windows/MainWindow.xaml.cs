using System.Windows;
using SIGEM.Windows.ViewModels;

namespace SIGEM.Windows.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var viewModel = new MainWindowViewModel();
            this.DataContext = viewModel;
        }
    }
}
