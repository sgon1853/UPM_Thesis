using System;
using System.Collections.Generic;
using SIGEM.Data;
using SIGEM.Data.Interfaces;
using SIGEM.Windows.Base;
using SIGEM.Windows.Commands;
using System.Windows;
using System.Linq;

namespace SIGEM.Windows.ViewModels
{
    public class InspectionViewModel: ViewModelBase
    {
        private string idInspection;
        private string inspectorName;
        private string idSpaceShip;
        private DateTime inspectionDate;
        private IEnumerable<InspectionDetail> inspectionDetails;
        private readonly ISpaceShipOcupationDataRepository spaceShipOccupationDataRepository;
        private readonly IInspectionDataRepository inspectionDataRepository;
        private bool showSpaceShipOccupationCanExecute;
        private bool saveSpaceShipInspectionCanExecute;

        /// <summary>
        /// Initializes a new instance of the <see cref="InspectionViewModel"/> class.
        /// </summary>
        /// <param name="spaceShipOccupationDataRepository">The space ship occupation data repository.</param>
        /// <param name="inspectionDataRepository">The inspection data repository.</param>
        public InspectionViewModel(ISpaceShipOcupationDataRepository spaceShipOccupationDataRepository,
            IInspectionDataRepository inspectionDataRepository)
        {
            this.spaceShipOccupationDataRepository = spaceShipOccupationDataRepository;
            this.inspectionDataRepository = inspectionDataRepository;
            showSpaceShipOccupationCanExecute = true;
            saveSpaceShipInspectionCanExecute = false;
        }

        public string IdInspection { get { return idInspection; } set { idInspection = value; OnPropertyChanged("IdInspection"); } }
        public string InspectorName { get { return inspectorName; } set { inspectorName = value; OnPropertyChanged("InspectorName"); } }
        public string IdSpaceShip { get { return idSpaceShip; } set { idSpaceShip = value; OnPropertyChanged("IdSpaceShip"); } }
        public DateTime InspectionDate { get { return inspectionDate; } set { inspectionDate = value; OnPropertyChanged("InspectionDate"); } }
        public IEnumerable<InspectionDetail> InspectionDetails { get { return inspectionDetails; } set { inspectionDetails = value; OnPropertyChanged("InspectionDetails"); } }

        /// <summary>
        /// Gets the show space ship occupation command.
        /// </summary>
        public RelayCommand ShowSpaceShipOccupationCommand
        {
            get
            {
                return  new RelayCommand(execute =>
                                             {
                                                 var spaceShipOcupations = this.spaceShipOccupationDataRepository.GetSpaceShipOcupations(IdSpaceShip);
                                                 var inspectionDetailsList = spaceShipOcupations.Select(
                                                     spaceShipOcupation => new InspectionDetail()
                                                                               {
                                                                                   IdInspection = this.IdInspection,
                                                                                   IdPassenger =
                                                                                       spaceShipOcupation.Id_Passenger,
                                                                                   PassengerName =
                                                                                       spaceShipOcupation.PassengerName,
                                                                                   isPassengerPresent = false
                                                                               }).ToList();
                                                 InspectionDetails = inspectionDetailsList;

                                                 saveSpaceShipInspectionCanExecute = true;
                                                 showSpaceShipOccupationCanExecute = false;
                                             }, canexecute => showSpaceShipOccupationCanExecute);
            }
        }

        /// <summary>
        /// Gets the save space ship inspection command.
        /// </summary>
        public RelayCommand SaveSpaceShipInspectionCommand
        {
            get
            {
                return  new RelayCommand(execute =>
                                             {
                                                 if (ArefieldsValid())
                                                 {
                                                     try
                                                     {
                                                         var inspection = new Inspection()
                                                                              {
                                                                                  IdInspection = this.IdInspection,
                                                                                  IdSpaceShip = this.IdSpaceShip,
                                                                                  InspectionDate = this.InspectionDate,
                                                                                  InspectorName = this.InspectorName
                                                                              };
                                                         this.inspectionDataRepository.SaveSpaceShipInspection(inspection, InspectionDetails);
                                                         //TODO: show inspection hystoric.
                                                         MessageBox.Show("Inspection hystoric.");
                                                     }
                                                     catch (Exception exc)
                                                     {
                                                         MessageBox.Show(
                                                             string.Format("Error guardando la revision: {0}",
                                                                           exc.Message));
                                                     }
                                                     saveSpaceShipInspectionCanExecute = false;
                                                     showSpaceShipOccupationCanExecute = true;
                                                 }
                                             }, canexecute => saveSpaceShipInspectionCanExecute);
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
            if (string.IsNullOrEmpty(this.IdInspection) || string.IsNullOrEmpty(this.IdSpaceShip)
                || string.IsNullOrEmpty(this.InspectorName) || this.InspectionDate == DateTime.MinValue)
            {
                return false;
            }

            return true;
        }


    }
}
