using SIGEM.Windows.Base;
using SIGEM.Windows.Commands;
using SIGEM.Windows.Helpers;

namespace SIGEM.Windows.ViewModels
{
    class MainWindowViewModel: ViewModelBase
    {
        object content = new object();

        public MainWindowViewModel()
        {
            content = "SIGEM Software";
        }

        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        /// <value>
        /// The content.
        /// </value>
        public object Content
        {
            get { return content; }
            set
            {
                content = value;
                OnPropertyChanged("Content");
            }
        }

        /// <summary>
        /// Gets the supply space ship command.
        /// </summary>
        public RelayCommand SupplySpaceShipCommand
        {
            get
            {
                return new RelayCommand(execute =>
                                            {
                                                Content = UserControlHelper.GetView("SupplySpaceShip");
                                            });
            }
        }
    
    }
}
