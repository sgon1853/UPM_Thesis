using System;
using System.Collections.Generic;
using System.Windows;
using SIGRE.Client.Commands;
using SIGRE.Data;
using SIGRE.Data.Interfaces;

namespace SIGRE.Client.ViewModels
{
    class ReparationViewModel: ViewModelBase
    {
        private readonly IReparationDataRepository reparationDataRepository;
        private string idReparation, idCustomer, commentsReparation, repairmanName, dateReparation;
        private decimal valueReparation;
        private IEnumerable<Reparation> reparations;

        public ReparationViewModel(IReparationDataRepository reparationDataRepository)
        {
            this.reparationDataRepository = reparationDataRepository;
            Reparations = this.reparationDataRepository.GetAllReparations();
        }

        public string IdReparation { get { return idReparation; } set { idReparation = value; OnPropertyChanged("IdReparation"); } }
        public string IdCustomer { get { return idCustomer; } set { idCustomer = value; OnPropertyChanged("IdCustomer"); } }
        public string CommentsReparation { get { return commentsReparation; } set { commentsReparation = value; OnPropertyChanged("CommentsReparation"); } }
        public string RepairmanName { get { return repairmanName; } set { repairmanName = value; OnPropertyChanged("RepairmanName"); } }
        public string DateReparation { get { return dateReparation; } set { dateReparation = value; OnPropertyChanged("DateReparation"); } }
        public decimal ValueReparation { get { return valueReparation; } set { valueReparation = value; OnPropertyChanged("ValueReparation"); } }
        public IEnumerable<Reparation> Reparations { get { return reparations; } set { reparations = value; OnPropertyChanged("Reparations"); } }


        public RelayCommand SaveReparationCommand
        {
            get
            {
                return new RelayCommand(o=>
                                            {
                                                try
                                                {
                                                    if (ArefieldsValid())
                                                    {
                                                        this.reparationDataRepository.SaveReparation(
                                                            new Reparation()
                                                                {
                                                                    IdReparation = IdReparation,
                                                                    IdCustomer                                                                    = IdCustomer,
                                                                    CommentsReparation                                                                    = CommentsReparation,
                                                                    RepairmanName                                                                    = RepairmanName,
                                                                    DateReparation                                                                    = DateTime.Parse(DateReparation),
                                                                    ValueReparation = ValueReparation
                                                                }
                                                            );
                                                        Reparations = this.reparationDataRepository.GetAllReparations();
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("Todos los campos deben rellenarse!");
                                                    }
                                                }
                                                catch (Exception e)
                                                {
                                                    MessageBox.Show(e.Message);
                                                }
                                            });
            }
        }


        protected override bool ArefieldsValid()
        {
            var areFieldsValid = true;

            if (string.IsNullOrEmpty(IdReparation) ||
            string.IsNullOrEmpty(IdCustomer) ||
                string.IsNullOrEmpty(CommentsReparation) ||
                    string.IsNullOrEmpty(DateReparation))
            {
                areFieldsValid = false;
            }

            return areFieldsValid;
        }
    }
}
