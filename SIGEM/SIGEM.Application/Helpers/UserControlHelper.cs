﻿using System;
using System.Reflection;
using System.Windows.Controls;

namespace SIGEM.Windows.Helpers
{
    public static class UserControlHelper
    {
        /// <summary>
        /// Gets the view.
        /// </summary>
        /// <param name="moduleName">Name of the module.</param>
        /// <returns></returns>
        public static UserControl GetView(string moduleName)
        {
            var viewType = Assembly.GetExecutingAssembly().GetType("SIGEM.Windows.Views." + moduleName + "View");
            var viewModelName = "SIGEM.Windows.ViewModels." + moduleName + "ViewModel";
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
    }
}
