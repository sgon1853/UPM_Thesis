using System;
using System.Collections.Generic;
using SIGEM.Data;
using SIGEM.Data.Interfaces;
using SIGEM.Windows.Base;
using SIGEM.Windows.Commands;
using System.Windows;
using System.Linq;
using SIGEM.Windows.Interfaces;

namespace SIGEM.Windows.ViewModels
{
    public class InspectionViewModel: ViewModelBase
    {
        private string idInspection;
        private string inspectorName;
        private string idSpaceShip;
        private string inspectionDate;
        private IEnumerable<InspectionDetail> inspectionDetails;
        private readonly ISpaceShipOcupationDataRepository spaceShipOccupationDataRepository;
        private readonly IInspectionDataRepository inspectionDataRepository;
        private readonly IInspectionHystoricCommand inspectionHystoricCommand;
        private bool showSpaceShipOccupationCanExecute;
        private bool saveSpaceShipInspectionCanExecute;

        /// <summary>
        /// Initializes a new instance of the <see cref="InspectionViewModel"/> class.
        /// </summary>
        /// <param name="spaceShipOccupationDataRepository">The space ship occupation data repository.</param>
        /// <param name="inspectionDataRepository">The inspection data repository.</param>
        /// <param name="inspectionHystoricCommand">The inspection hystoric command.</param>
        public InspectionViewModel(ISpaceShipOcupationDataRepository spaceShipOccupationDataRepository,
            IInspectionDataRepository inspectionDataRepository,
            IInspectionHystoricCommand inspectionHystoricCommand)
        {
            this.spaceShipOccupationDataRepository = spaceShipOccupationDataRepository;
            this.inspectionDataRepository = inspectionDataRepository;
            showSpaceShipOccupationCanExecute = true;
            saveSpaceShipInspectionCanExecute = false;
            this.inspectionHystoricCommand = inspectionHystoricCommand;
        }

        public string IdInspection { get { return idInspection; } set { idInspection = value; OnPropertyChanged("IdInspection"); } }
        public string InspectorName { get { return inspectorName; } set { inspectorName = value; OnPropertyChanged("InspectorName"); } }
        public string IdSpaceShip { get { return idSpaceShip; } set { idSpaceShip = value; OnPropertyChanged("IdSpaceShip"); } }
        public string InspectionDate { get { return inspectionDate; } set { inspectionDate = value; OnPropertyChanged("InspectionDate"); } }
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
                                                                                  InspectionDate = DateTime.Parse(this.InspectionDate),
                                                                                  InspectorName = this.InspectorName
                                                                              };
                                                         var inspections =
                                                             this.inspectionDataRepository.GetSpaceShipInspectionsByDate
                                                                 (inspection.IdSpaceShip, inspection.InspectionDate);
                                                         if (inspections.Any())
                                                         {
                                                             MessageBox.Show(
                                                                 "La Aeronave solo puede ser revisada una vez por dia",
                                                                 "Error guardando la revision");
                                                         }
                                                         else
                                                         {
                                                             this.inspectionDataRepository.SaveSpaceShipInspection(
                                                                 inspection, InspectionDetails);
                                                             ShowSpaceshipHystoric(this.IdSpaceShip);
                                                         }
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
                                                 else
                                                 {
                                                     MessageBox.Show("Debe rellenar todos los campos, verifique nuevamente.");
                                                 }
                                             }, canexecute => saveSpaceShipInspectionCanExecute);
            }
        }

        /// <summary>
        /// Shows the spaceship hystoric.
        /// </summary>
        /// <param name="spaceshipId">The spaceship id.</param>
        private void ShowSpaceshipHystoric(string spaceshipId)
        {
            inspectionHystoricCommand.ShowInspectionHystoricBySpaceshipId(spaceshipId);
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
                || string.IsNullOrEmpty(this.InspectorName) || string.IsNullOrEmpty(this.InspectionDate))
            {
                return false;
            }

            return true;
        }


    }
}
