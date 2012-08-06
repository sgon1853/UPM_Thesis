using System;
using System.Collections.Generic;
using System.Windows;
using SIGEM.Data;
using SIGEM.Data.Interfaces;
using SIGEM.Windows.Base;
using SIGEM.Windows.Commands;
using SIGEM.Windows.Helpers;
using System.Linq;

namespace SIGEM.Windows.ViewModels
{
    internal class ManagePassengersViewModel : ViewModelBase
    {
        private string idPassenger;

        private string idSpaceship;

        private readonly IPassengerDataRepository passengerDataRepository;

        private readonly ISpaceShipOcupationDataRepository spaceShipOcupationDataRepository;

        private readonly ISpaceShipDataRepository spaceShipDataRepository;
        
        private IEnumerable<SpaceShipOcupation> spaceShipOcupations;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ManagePassengersViewModel"/> class.
        /// </summary>
        /// <param name="passengerDataRepository">The passenger data repository.</param>
        /// <param name="spaceShipOcupationDataRepository">The space ship ocupation data repository.</param>
        /// <param name="spaceShipDataRepository">The space ship data repository.</param>
        public ManagePassengersViewModel(
            IPassengerDataRepository passengerDataRepository, 
            ISpaceShipOcupationDataRepository spaceShipOcupationDataRepository,
            ISpaceShipDataRepository spaceShipDataRepository)
        {
            this.passengerDataRepository = passengerDataRepository;
            this.spaceShipOcupationDataRepository = spaceShipOcupationDataRepository;
            this.spaceShipDataRepository = spaceShipDataRepository;
            this.spaceShipOcupations = this.spaceShipOcupationDataRepository.GetAllSpaceShipOcupations();
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
                                                if (ArefieldsValid())
                                                {
                                                    var passenger = passengerDataRepository.GetPassenger(IdPassenger);
                                                    if (passenger == null)
                                                    {
                                                        var result =
                                                            MessageBox.Show("El pasajero no existe, desea crearlo?",
                                                                            "Pasajero no existe", MessageBoxButton.YesNo);
                                                        if (result == MessageBoxResult.Yes)
                                                        {
                                                            UserControlHelper.ShowView("Passenger");
                                                        }
                                                    }
                                                    else
                                                    {
                                                        var spaceship =
                                                            this.spaceShipDataRepository.GetSpaceShip(IdSpaceship);
                                                        if (spaceship == null)
                                                        {
                                                            MessageBox.Show(
                                                                "La aeronave no existe, verifique nuevamente.");
                                                        }
                                                        else
                                                        {
                                                            if (IsSpaceShipOccupationAvailable(spaceship))
                                                            {
                                                                var spaceShipOcupation = new SpaceShipOcupation()
                                                                                             {
                                                                                                 Id_Passenger = IdPassenger,
                                                                                                 Id_SpaceShip = IdSpaceship,
                                                                                                 PassengerName =
                                                                                                     passenger.Name,
                                                                                                 SpaceShipName =
                                                                                                     spaceship.Name
                                                                                             };
                                                                try
                                                                {
                                                                    spaceShipOcupationDataRepository.
                                                                        AssignPassengerToSpaceShip(spaceShipOcupation);
                                                                    this.SpaceShipOcupations =
                                                                        spaceShipOcupationDataRepository.
                                                                            GetAllSpaceShipOcupations();
                                                                }
                                                                catch (Exception e)
                                                                {
                                                                    MessageBox.Show(
                                                                        string.Format(
                                                                            "Error al asignar el pasajero a la Aeronave: {0}",
                                                                            e.Message));
                                                                }
                                                            }
                                                            else
                                                            {
                                                                MessageBox.Show(
                                                                    "La capacidad de pasajeros para esta aeronave esta en el maximo permitido.");
                                                            }
                                                        }

                                                    }
                                                }
                                            });
            }
        }

        /// <summary>
        /// Gets the remove space ship ocupation command.
        /// </summary>
        public RelayCommand RemoveSpaceShipOcupationCommand
        {
            get
            {
                return new RelayCommand(execute =>
                                            {
                                                if (ArefieldsValid())
                                                {
                                                    var passenger = passengerDataRepository.GetPassenger(IdPassenger);
                                                    if (passenger == null)
                                                    {
                                                        var result =
                                                            MessageBox.Show(
                                                                "El pasajero no existe, verifique nuevamente.");

                                                    }
                                                    else
                                                    {
                                                        var spaceship =
                                                            this.spaceShipDataRepository.GetSpaceShip(IdSpaceship);
                                                        if (spaceship == null)
                                                        {
                                                            MessageBox.Show(
                                                                "La aeronave no existe, verifique nuevamente.");
                                                        }
                                                        else
                                                        {
                                                            var spaceShipOcupation = new SpaceShipOcupation()
                                                                                         {
                                                                                             Id_Passenger = IdPassenger,
                                                                                             Id_SpaceShip = IdSpaceship,
                                                                                             PassengerName =
                                                                                                 passenger.Name,
                                                                                             SpaceShipName =
                                                                                                 spaceship.Name
                                                                                         };
                                                            try
                                                            {
                                                                spaceShipOcupationDataRepository.
                                                                    RemovePassengerFromSpaceShip(spaceShipOcupation);
                                                                this.SpaceShipOcupations =
                                                                    spaceShipOcupationDataRepository.
                                                                        GetAllSpaceShipOcupations();
                                                            }
                                                            catch (Exception e)
                                                            {
                                                                MessageBox.Show(
                                                                    string.Format(
                                                                        "Error al bajar el pasajero de la Aeronave: {0}",
                                                                        e.Message));
                                                            }
                                                        }

                                                    }
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Debe rellenar todos los campos, verifique nuevamente.");
                                                }
                                            }
                    );
            }
        }

        /// <summary>
        /// Arefieldses the valid.
        /// </summary>
        /// <returns>
        /// true if all fields are valid, otherwise returns false.
        /// </returns>
        protected override bool ArefieldsValid()
        {
            if (string.IsNullOrEmpty(this.IdPassenger) || string.IsNullOrEmpty(this.IdSpaceship))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Determines whether [is space ship occupation available] [the specified spaceship].
        /// </summary>
        /// <param name="spaceship">The spaceship.</param>
        /// <returns>
        ///   <c>true</c> if [is space ship occupation available] [the specified spaceship]; otherwise, <c>false</c>.
        /// </returns>
        private bool IsSpaceShipOccupationAvailable(SpaceShip spaceship)
        {
            var ocupationsCurrentSpaceship = this.spaceShipOcupationDataRepository.GetSpaceShipOcupations(IdSpaceship);
            return ocupationsCurrentSpaceship.Count() < spaceship.MaximumPassengers;
        }
    }
}
