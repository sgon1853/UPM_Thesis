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
    /// Supply Spaceship View Model
    /// </summary>
    public class SupplySpaceShipViewModel:ViewModelBase
    {
        /// <summary>
        /// Id of the Supply space ship
        /// </summary>
        private string id;

        /// <summary>
        /// Name of the Supply space ship
        /// </summary>
        private string name;

        /// <summary>
        /// List of Supply Space Ships
        /// </summary>
        private IEnumerable<SupplySpaceShip> supplySpaceShips;

        /// <summary>
        /// Initializes a new instance of the <see cref="SupplySpaceShipViewModel"/> class.
        /// </summary>
        public SupplySpaceShipViewModel(ISupplySpaceShipDataRepository supplySpaceShipRepository)
        {
            this.SupplySpaceShipRepository = supplySpaceShipRepository;
            SupplySpaceShips = this.SupplySpaceShipRepository.GetSupplySpaceShips();
        }

        /// <summary>
        /// Gets or sets the supply space ship repository.
        /// </summary>
        /// <value>
        /// The supply space ship repository.
        /// </value>
        protected ISupplySpaceShipDataRepository SupplySpaceShipRepository { get; set; }

        /// <summary>
        /// Gets the save supply space ship.
        /// </summary>
        public ICommand SaveSupplySpaceShip
        {
            get
            {
                return new RelayCommand(execute =>
                                            {
                                                try
                                                {
                                                    if (ArefieldsValid())
                                                    {
                                                        var model = new SupplySpaceShip()
                                                                        {
                                                                            Id = this.Id,
                                                                            Name = this.Name
                                                                        };
                                                        this.SupplySpaceShipRepository.SaveSupplySpaceShip(model);
                                                        this.SupplySpaceShips =
                                                            this.SupplySpaceShipRepository.GetSupplySpaceShips();
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
        /// Arefieldses the valid.
        /// </summary>
        /// <returns>
        /// true if all fields are valid, otherwise returns false.
        /// </returns>
        protected override bool ArefieldsValid()
        {
            if (string.IsNullOrEmpty(this.Id) || string.IsNullOrEmpty(this.Name))
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
        /// Gets or sets the supply space ships.
        /// </summary>
        /// <value>
        /// The supply space ships.
        /// </value>
        public IEnumerable<SupplySpaceShip> SupplySpaceShips
        {
            get { return supplySpaceShips; }
            set
            {
                supplySpaceShips = value;
                this.OnPropertyChanged("SupplySpaceShips");
            }
        }
    }
}
