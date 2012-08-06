using System;
using System.Collections.Generic;

namespace SIGEM.Data.Interfaces
{
    public interface IInspectionDataRepository
    {
        /// <summary>
        /// Saves the space ship inspection.
        /// </summary>
        /// <param name="inspection">The inspection.</param>
        /// <param name="inspectionDetails">The inspection details.</param>
        void SaveSpaceShipInspection(Inspection inspection, IEnumerable<InspectionDetail> inspectionDetails);

        /// <summary>
        /// Gets the space ship inspections.
        /// </summary>
        /// <param name="idSpaceShip">The id space ship.</param>
        /// <returns></returns>
        IEnumerable<Inspection> GetSpaceShipInspections(string idSpaceShip);

        /// <summary>
        /// Gets the space ship inspections by date.
        /// </summary>
        /// <param name="idSpaceShip">The id space ship.</param>
        /// <param name="inspectionDate">The inspection date.</param>
        /// <returns>
        /// List of inspections
        /// </returns>
        IEnumerable<Inspection> GetSpaceShipInspectionsByDate(string idSpaceShip, DateTime inspectionDate);

        /// <summary>
        /// Gets the inspection details.
        /// </summary>
        /// <param name="idInspection">The id inspection.</param>
        /// <returns></returns>
        IEnumerable<InspectionDetail> GetInspectionDetails(string idInspection);
    }
}
