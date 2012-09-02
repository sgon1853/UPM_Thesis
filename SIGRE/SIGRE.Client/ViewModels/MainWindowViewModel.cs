using SIGRE.Client.Commands;
using SIGRE.Client.Helpers;

namespace SIGRE.Client.ViewModels
{
    class MainWindowViewModel: ViewModelBase
    {
        object content = new object();

        public MainWindowViewModel()
        {
            content = "SIGRE (Sistema de Gestión para una Empresa de Reparación de Electrodomésticos)";
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
        /// Gets the customer command.
        /// </summary>
        public RelayCommand CustomerCommand
        {
            get
            {
                return new RelayCommand(execute =>
                                            {
                                                Content = UserControlHelper.GetView("Customer");
                                            });
            }
        }

        protected override bool ArefieldsValid()
        {
            throw new System.NotImplementedException();
        }
    }
}
