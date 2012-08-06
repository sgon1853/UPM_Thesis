using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using SIGEM.Data.Interfaces;
using System;

namespace SIGEM.Data.DataRepository
{
    public class InspectionDataRepository : BaseDataRepository, IInspectionDataRepository
    {
        /// <summary>
        /// Saves the space ship inspection.
        /// </summary>
        /// <param name="inspection">The inspection.</param>
        /// <param name="inspectionDetails">The inspection details.</param>
        public void SaveSpaceShipInspection(Inspection inspection, IEnumerable<InspectionDetail> inspectionDetails)
        {
            using (var scope = new TransactionScope())
            {
                DataContext.Inspections.InsertOnSubmit(inspection);
                foreach (var inspectionDetail in inspectionDetails)
                {
                    DataContext.InspectionDetails.InsertOnSubmit(inspectionDetail);
                }
                
                DataContext.SubmitChanges();
                scope.Complete();
            }
            
        }

        /// <summary>
        /// Gets the space ship inspections.
        /// </summary>
        /// <param name="idSpaceShip">The id space ship.</param>
        /// <returns>List of inspections</returns>
        public IEnumerable<Inspection> GetSpaceShipInspections(string idSpaceShip)
        {
            var inspections = from insps in DataContext.Inspections
                              where insps.IdSpaceShip == idSpaceShip
                              select insps;

            return inspections;
        }

        /// <summary>
        /// Gets the space ship inspections by date.
        /// </summary>
        /// <param name="idSpaceShip">The id space ship.</param>
        /// <param name="inspectionDate">The inspection date.</param>
        /// <returns>
        /// List of inspections
        /// </returns>
        public IEnumerable<Inspection> GetSpaceShipInspectionsByDate(string idSpaceShip, DateTime inspectionDate)
        {
            var inspections = from insps in DataContext.Inspections
                              where insps.IdSpaceShip == idSpaceShip &&
                              insps.InspectionDate.Date == inspectionDate.Date
                              select insps;

            return inspections;
        }

        /// <summary>
        /// Gets the inspection details.
        /// </summary>
        /// <param name="idInspection">The id inspection.</param>
        /// <returns></returns>
        public IEnumerable<InspectionDetail> GetInspectionDetails(string idInspection)
        {
            var inspectionDetails = from inspdets in DataContext.InspectionDetails
                                    where inspdets.IdInspection == idInspection
                                    select inspdets;

            return inspectionDetails;
        }
    }
}
