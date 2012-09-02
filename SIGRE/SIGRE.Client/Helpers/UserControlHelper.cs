using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace SIGRE.Client.Helpers
{
    public static class UserControlHelper
    {
        private const string NamespaceBase = "SIGRE.Client.";

        /// <summary>
        /// Gets the view.
        /// </summary>
        /// <param name="moduleName">Name of the module.</param>
        /// <returns></returns>
        public static UserControl GetView(string moduleName)
        {
            var viewType = Assembly.GetExecutingAssembly().GetType(string.Concat(NamespaceBase,"Views.", moduleName, "View"));
            var viewModelName = string.Concat(NamespaceBase,"ViewModels.", moduleName, "ViewModel");
            var viewModelType = Assembly.GetExecutingAssembly().GetType(viewModelName);
            var viewInstance = Activator.CreateInstance(viewType) as UserControl;
            var viewModelInstance = UnityHelper.Container.Resolve(viewModelType,viewModelName);

            if (viewInstance != null)
            {
                viewInstance.DataContext = viewModelInstance;
                return viewInstance;
            }


            return null;
        }

        /// <summary>
        /// Shows the view.
        /// </summary>
        /// <param name="viewName">Name of the view.</param>
        public static void ShowView(string viewName)
        {
            var view = GetView(viewName);

            var window = new Window
                                {
                                    Content = view
                                };
            window.Show();
        }

        /// <summary>
        /// Shows the view.
        /// </summary>
        /// <param name="viewControl">The view control.</param>
        public static void ShowView(UserControl viewControl)
        {
            var window = new Window
            {
                Content = viewControl
            };
            window.Show();
        }
    }
}
