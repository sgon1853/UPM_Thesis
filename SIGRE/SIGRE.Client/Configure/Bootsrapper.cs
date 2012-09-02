using Microsoft.Practices.Unity;
using SIGRE.Client.Helpers;
using SIGRE.Client.Windows;
using SIGRE.Data.DataRepository;
using SIGRE.Data.Interfaces;

namespace SIGRE.Client.Configure
{
    public class Bootsrapper
    {
        /// <summary>
        /// Startups this instance.
        /// </summary>
        public void Startup()
        {
            UnityHelper.Container.RegisterType<ICustomerDataRepository, CustomerDataRepository>();
            UnityHelper.Container.RegisterType<IReparationDataRepository, ReparationDataRepository>();
            
            var mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
