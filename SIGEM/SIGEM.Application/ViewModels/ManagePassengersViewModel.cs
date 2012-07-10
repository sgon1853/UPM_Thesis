using System.Collections.Generic;
using System.Windows;
using SIGEM.Data;
using SIGEM.Data.Interfaces;
using SIGEM.Windows.Base;
using SIGEM.Windows.Commands;
using SIGEM.Windows.Helpers;

namespace SIGEM.Windows.ViewModels
{
    internal class ManagePassengersViewModel : ViewModelBase
    {
        private string idPassenger;

        private string idSpaceship;

        private readonly IPassengerDataRepository passengerDataRepository;

        private readonly ISpaceShipOcupationDataRepository spaceShipOcupationDataRepository;

        private IEnumerable<SpaceShipOcupation> spaceShipOcupations;

        /// <summary>
        /// Initializes a new instance of the <see cref="ManagePassengersViewModel"/> class.
        /// </summary>
        /// <param name="passengerDataRepository">The passenger data repository.</param>
        /// <param name="spaceShipOcupationDataRepository">The space ship ocupation data repository.</param>
        public ManagePassengersViewModel(
            IPassengerDataRepository passengerDataRepository, 
            ISpaceShipOcupationDataRepository spaceShipOcupationDataRepository)
        {
            this.passengerDataRepository = passengerDataRepository;
            this.spaceShipOcupationDataRepository = spaceShipOcupationDataRepository;
        }

        /// <summary>
        /// Gets or sets the id passenger.
        /// </summary>
        /// <value>
        /// The id passenger.
        /// </value>
        public string IdPassenger
        {
            get { return idPassenger; }
            set
            {
                idPassenger = value;
                OnPropertyChanged("IdPassenger");
            }
        }

        /// <summary>
        /// Gets or sets the id spaceship.
        /// </summary>
        /// <value>
        /// The id spaceship.
        /// </value>
        public string IdSpaceship
        {
            get { return idSpaceship; }
            set
            {
                idSpaceship = value;
                OnPropertyChanged("IdSpaceship");
            }
        }

        /// <summary>
        /// Gets or sets the space ship ocupations.
        /// </summary>
        /// <value>
        /// The space ship ocupations.
        /// </value>
        public IEnumerable<SpaceShipOcupation> SpaceShipOcupations
        {
            get { return spaceShipOcupations; }
            set
            {
                spaceShipOcupations = value;
                OnPropertyChanged("SpaceShipOcupations");
            }
        }

        /// <summary>
        /// Gets the save space ship ocupation command.
        /// </summary>
        public RelayCommand SaveSpaceShipOcupationCommand
        {
            get
            {
                return new RelayCommand(execute =>
                                            {
                                                var passenger = passengerDataRepository.GetPassenger(IdPassenger);
                                                if (passenger == null)
                                                {
                                                    var result = MessageBox.Show("El pasajero no existe, desea crearlo?", 
                                                        "Pasajero no existe", MessageBoxButton.YesNo);
                                                    if (result == MessageBoxResult.Yes)
                                                    {
                                                        UserControlHelper.ShowView("Passenger");
                                                    }
                                                    
                                                }
                                                else
                                                {
                                                    var spaceShipOcupation = new SpaceShipOcupation()
                                                                                 {
                                                                                     Id_Passenger = IdPassenger,
                                                                                     Id_SpaceShip = IdSpaceship
                                                                                 };
                                                    spaceShipOcupationDataRepository.AssignPassengerToSpaceShip(spaceShipOcupation);
                                                    this.SpaceShipOcupations = spaceShipOcupationDataRepository.GetSpaceShipOcupations();
                                                }

                });
            }
        }
    }
}
