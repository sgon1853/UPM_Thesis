using System;
using System.Collections.Generic;
using SIGEM.Data;
using SIGEM.Data.Interfaces;
using SIGEM.Windows.Base;
using SIGEM.Windows.Commands;
using System.Windows;
using System.Linq;
using SIGEM.Windows.Helpers;

namespace SIGEM.Windows.ViewModels
{
    public class InspectionHystoricViewModel: ViewModelBase
    {
        private string spaceshipId;
        private IEnumerable<Inspection> inspections;
        private readonly IInspectionDataRepository inspectionDataRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="InspectionViewModel"/> class.
        /// </summary>
        /// <param name="inspectionDataRepository">The inspection data repository.</param>
        public InspectionHystoricViewModel(IInspectionDataRepository inspectionDataRepository)
        {
            this.inspectionDataRepository = inspectionDataRepository;
        }

        /// <summary>
        /// Gets or sets the spaceship id.
        /// </summary>
        /// <value>
        /// The spaceship id.
        /// </value>
        public string SpaceshipId { get { return spaceshipId; } set { spaceshipId = value; OnPropertyChanged("SpaceshipId"); } }

        /// <summary>
        /// Gets or sets the inspections.
        /// </summary>
        /// <value>
        /// The inspections.
        /// </value>
        public IEnumerable<Inspection> Inspections { get { return inspections; } set { inspections = value; OnPropertyChanged("Inspections"); } }

        /// <summary>
        /// Gets the show space ship occupation command.
        /// </summary>
        public RelayCommand ShowSpaceshipInspectionHystoricCommand
        {
            get
            {
                return  new RelayCommand(execute =>
                                             {
                                                 this.Inspections = this.inspectionDataRepository.GetSpaceShipInspections(this.SpaceshipId);
                                             }, canExecute => true);
            }
        }
    }
}
