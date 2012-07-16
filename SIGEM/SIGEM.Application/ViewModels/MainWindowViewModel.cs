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
            content = "SIGEM (SIstema de GEstión de Naves Marcianas)";
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

        /// <summary>
        /// Gets the space ship command.
        /// </summary>
        public RelayCommand SpaceShipCommand
        {
            get
            {
                return new RelayCommand(execute =>
                {
                    Content = UserControlHelper.GetView("SpaceShip");
                });
            }
        }

        /// <summary>
        /// Gets the manage passengers command.
        /// </summary>
        public RelayCommand ManagePassengersCommand
        {
            get
            {
                return new RelayCommand(execute =>
                {
                    Content = UserControlHelper.GetView("ManagePassengers");
                });
            }
        }

        /// <summary>
        /// Gets the inspection command.
        /// </summary>
        public RelayCommand InspectionCommand
        {
            get
            {
                return new RelayCommand(execute =>
                {
                    Content = UserControlHelper.GetView("Inspection");
                });
            }
        }
    
    }
}
