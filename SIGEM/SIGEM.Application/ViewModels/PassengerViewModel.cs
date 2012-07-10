using System;
using System.Windows;
using SIGEM.Data;
using SIGEM.Data.Interfaces;
using SIGEM.Windows.Base;
using SIGEM.Windows.Commands;

namespace SIGEM.Windows.ViewModels
{
    internal class PassengerViewModel : ViewModelBase
    {
        private readonly IPassengerDataRepository passengerDataRepository;

        private string id;

        private string name;

        public PassengerViewModel(IPassengerDataRepository passengerDataRepository)
        {
            this.passengerDataRepository = passengerDataRepository;
        }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>
        /// The id.
        /// </value>
        public string Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public RelayCommand SavePassengerCommand
        {
            get
            {
                return new RelayCommand(
                    execute =>
                        {
                            try
                            {
                                if (ArefieldsValid())
                                {
                                    var passenger = new Passenger()
                                                        {
                                                            Id = Id,
                                                            Name = Name
                                                        };
                                    passengerDataRepository.SavePassenger(passenger);
                                    MessageBox.Show("Pasajero creado!.");
                                }
                            }
                            catch (Exception e)
                            {
                                MessageBox.Show(e.Message);
                            }
                        }, canexecute => true);
            }
        }

        /// <summary>
        /// Are the fields validated.
        /// </summary>
        /// <returns>
        /// true if all fields are valid, otherwise returns false.
        /// </returns>
        protected override bool ArefieldsValid()
        {
            if (string.IsNullOrEmpty(this.Id) ||
                string.IsNullOrEmpty(this.Name))
            {
                MessageBox.Show("Debe rellenar todos los campos.");
                return false;
            }

            return true;
        }
    }
}
