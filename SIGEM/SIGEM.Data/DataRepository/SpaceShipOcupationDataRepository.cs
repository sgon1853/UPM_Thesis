using System.Collections.Generic;
using System.Linq;
using SIGEM.Data.Interfaces;

namespace SIGEM.Data.DataRepository
{
    public class SpaceShipOcupationDataRepository : BaseDataRepository, ISpaceShipOcupationDataRepository
    {
        /// <summary>
        /// Assigns the passenger to space ship.
        /// </summary>
        /// <param name="spaceShipOcupation">The space ship ocupation.</param>
        public void AssignPassengerToSpaceShip(SpaceShipOcupation spaceShipOcupation)
        {
            DataContext.SpaceShipOcupations.InsertOnSubmit(spaceShipOcupation);
            DataContext.SubmitChanges();
        }

        /// <summary>
        /// Gets the space ship ocupations.
        /// </summary>
        /// <returns>
        /// A SpaceShipOcupation Object.
        /// </returns>
        public IEnumerable<SpaceShipOcupation> GetSpaceShipOcupations()
        {
            var spaceShipOcupations = from sps in DataContext.SpaceShipOcupations
                                      select sps;
            return spaceShipOcupations.OrderBy(ocupation => ocupation.Id_SpaceShip).AsEnumerable();
        }
    }
}
