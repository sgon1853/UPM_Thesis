using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using SIGEM.Data;
using SIGEM.Data.Interfaces;
using SIGEM.Windows.Base;
using SIGEM.Windows.Commands;

namespace SIGEM.Windows.ViewModels
{
    /// <summary>
    /// Spaceship View Model
    /// </summary>
    public class SpaceShipViewModel : ViewModelBase
    {
        /// <summary>
        /// Id of the space ship
        /// </summary>
        private string id;

        /// <summary>
        /// Name of the space ship
        /// </summary>
        private string name;

        /// <summary>
        /// Maximum of passengers
        /// </summary>
        private int maximumPassengers;

        /// <summary>
        /// Origin SupplySpaceship
        /// </summary>
        private string supplySpaceShipOrigin;


        /// <summary>
        /// Destination Supplyspaceship
        /// </summary>
        private string supplySpaceShipDestination;


        /// <summary>
        /// List of Space Ships
        /// </summary>
        private IEnumerable<SpaceShip> spaceShips;

        /// <summary>
        /// Initializes a new instance of the <see cref="SpaceShipViewModel"/> class.
        /// </summary>
        /// <param name="spaceShipRepository">The space ship repository.</param>
        public SpaceShipViewModel(ISpaceShipDataRepository spaceShipRepository)
        {
            this.SpaceShipRepository = spaceShipRepository;
            this.SpaceShips = this.SpaceShipRepository.GetSpaceShips();
        }

        /// <summary>
        /// Gets or sets the supply space ship repository.
        /// </summary>
        /// <value>
        /// The supply space ship repository.
        /// </value>
        protected ISpaceShipDataRepository SpaceShipRepository { get; set; }

        /// <summary>
        /// Gets the save supply space ship.
        /// </summary>
        public ICommand SaveSpaceShip
        {
            get
            {
                return new RelayCommand(execute =>
                                            {
                                                try
                                                {
                                                    if (this.ArefieldsValid())
                                                    {
                                                        var model = new SpaceShip()
                                                                        {
                                                                            Id = this.Id,
                                                                            Name = this.Name,
                                                                            MaximumPassengers = this.MaximumPassengers,
                                                                            SupplySpaceShipOrigin =
                                                                                this.SupplySpaceShipOrigin,
                                                                            SupplySpaceShipDestination =
                                                                                this.SupplySpaceShipDestination

                                                                        };
                                                        this.SpaceShipRepository.SaveSpaceShip(model);
                                                        this.SpaceShips = this.SpaceShipRepository.GetSpaceShips();
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("Debe rellenar todos los campos.");
                                                    }
                                                }
                                                catch (Exception exc)
                                                {
                                                    MessageBox.Show(exc.Message);
                                                }
                                                
                                            }
                                            , canexecute => true);
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
                string.IsNullOrEmpty(this.Name)||
                this.MaximumPassengers == 0||
                string.IsNullOrEmpty(this.SupplySpaceShipOrigin)||
                string.IsNullOrEmpty(this.SupplySpaceShipDestination))
            {
                return false;
            }

            return true;
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
                this.OnPropertyChanged("Id");
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
                this.OnPropertyChanged("Name");
            }
        }

        /// <summary>
        /// Gets or sets the maximum passengers.
        /// </summary>
        /// <value>
        /// The maximum passengers.
        /// </value>
        public int MaximumPassengers
        {
            get { return maximumPassengers; }
            set
            {
                maximumPassengers = value;
                OnPropertyChanged("MaximumPassengers");
            }
        }

        /// <summary>
        /// Gets or sets the supply space ship origin.
        /// </summary>
        /// <value>
        /// The supply space ship origin.
        /// </value>
        public string SupplySpaceShipOrigin
        {
            get { return supplySpaceShipOrigin; }
            set
            {
                supplySpaceShipOrigin = value;
                OnPropertyChanged("SupplySpaceShipOrigin");
            }
        }

        /// <summary>
        /// Gets or sets the supply space ship destination.
        /// </summary>
        /// <value>
        /// The supply space ship destination.
        /// </value>
        public string SupplySpaceShipDestination
        {
            get { return supplySpaceShipDestination; }
            set
            {
                supplySpaceShipDestination = value;
                OnPropertyChanged("SupplySpaceShipDestination");
            }
        }

        /// <summary>
        /// Gets or sets the supply space ships.
        /// </summary>
        /// <value>
        /// The supply space ships.
        /// </value>
        public IEnumerable<SpaceShip> SpaceShips
        {
            get { return spaceShips; }
            set
            {
                spaceShips = value;
                this.OnPropertyChanged("SpaceShips");
            }
        }
    }
}
