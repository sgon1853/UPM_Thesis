using System.Collections.Generic;
using System.Windows.Input;
using SIGEM.Data;
using SIGEM.Data.DataRepository;
using SIGEM.Windows.Base;
using SIGEM.Windows.Commands;

namespace SIGEM.Windows.ViewModels
{
    /// <summary>
    /// Supply Spaceship View Model
    /// </summary>
    public class SupplySpaceShipViewModel:ViewModelBase
    {
        private readonly SupplySpaceShipDataRepository dataRepository = new SupplySpaceShipDataRepository();

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
        public SupplySpaceShipViewModel()
        {
            SupplySpaceShips = this.dataRepository.GetSupplySpaceShips();
        }

        /// <summary>
        /// Gets the save supply space ship.
        /// </summary>
        public ICommand SaveSupplySpaceShip
        {
            get
            {
                return new RelayCommand(execute =>
                                            {
                                                var model = new SupplySpaceShip()
                                                                {
                                                                    Id = this.Id,
                                                                    Name = this.Name
                                                                };
                                                dataRepository.SaveSupplySpaceShip(model);
                                                this.SupplySpaceShips = dataRepository.GetSupplySpaceShips();
                                            }
                                            , canexecute => true);
            }
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
