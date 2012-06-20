using System.Windows;
using Microsoft.Practices.Unity;
using SIGEM.Windows.Configure;
using SIGEM.Windows.Windows;

namespace SIGEM.Windows
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public UnityContainer Container;

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Application.Startup"/> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.StartupEventArgs"/> that contains the event data.</param>
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            this.Container = new UnityContainer();
            var bootsrapper = new Bootsrapper();
            bootsrapper.Startup();
            var mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
