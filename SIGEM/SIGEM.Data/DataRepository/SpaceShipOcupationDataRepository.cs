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
        /// Removes the passenger from space ship.
        /// </summary>
        /// <param name="spaceShipOcupation">The space ship ocupation.</param>
        public void RemovePassengerFromSpaceShip(SpaceShipOcupation spaceShipOcupation)
        {
            var occupation = from sps in DataContext.SpaceShipOcupations
                          where sps.Id_SpaceShip == spaceShipOcupation.Id_SpaceShip &
                                sps.Id_Passenger == spaceShipOcupation.Id_Passenger
                          select sps;

            DataContext.SpaceShipOcupations.DeleteOnSubmit(occupation.First());
            DataContext.SubmitChanges();
        }

        /// <summary>
        /// Gets the space ship ocupations.
        /// </summary>
        /// <returns>
        /// A SpaceShipOcupation Object.
        /// </returns>
        public IEnumerable<SpaceShipOcupation> GetAllSpaceShipOcupations()
        {
            var spaceShipOcupations = from sps in DataContext.SpaceShipOcupations
                                      select sps;
            return spaceShipOcupations.OrderBy(ocupation => ocupation.Id_SpaceShip).AsEnumerable();
        }

        /// <summary>
        /// Gets the space ship ocupations.
        /// </summary>
        /// <param name="idSpaceship">The id spaceship.</param>
        /// <returns></returns>
        public IEnumerable<SpaceShipOcupation> GetSpaceShipOcupations(string idSpaceship)
        {
            var spaceShipOcupations = from sps in DataContext.SpaceShipOcupations
                                      where sps.Id_SpaceShip == idSpaceship
                                      select sps;
            return spaceShipOcupations.OrderBy(ocupation => ocupation.Id_SpaceShip).AsEnumerable();
        }
    }
}
