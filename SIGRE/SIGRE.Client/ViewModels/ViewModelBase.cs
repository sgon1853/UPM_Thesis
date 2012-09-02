using System;
using System.ComponentModel;
using System.Diagnostics;

namespace SIGRE.Client.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        // In ViewModelBase.cs
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            this.VerifyPropertyName(propertyName);

            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }

        [Conditional("DEBUG")]
        [DebuggerStepThrough]
        public void VerifyPropertyName(string propertyName)
        {
            // Verify that the property name matches a real,  
            // public, instance property on this object.
            if (TypeDescriptor.GetProperties(this)[propertyName] == null)
            {
                string msg = "Invalid property name: " + propertyName;

                throw new Exception(msg);
            }
        }

        /// <summary>
        /// Arefieldses the valid.
        /// </summary>
        /// <returns>true if all fields are valid, otherwise returns false.</returns>
        protected abstract bool ArefieldsValid();
    }
}
