using System.Windows;
using Microsoft.Practices.Unity;

namespace SIGRE.Client.Helpers
{
    internal static class UnityHelper
    {
        /// <summary>
        /// Gets the container.
        /// </summary>
        public static UnityContainer Container
        {
            get
            {
                var app = Application.Current as App;

                if (app != null)
                {
                    return app.Container;
                }

                return null;
            }
        }
    }
}
