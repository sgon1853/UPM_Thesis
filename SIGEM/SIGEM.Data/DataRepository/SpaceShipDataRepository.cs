using System.Collections.Generic;
using System.Linq;
using SIGEM.Data.Interfaces;

namespace SIGEM.Data.DataRepository
{
    public class SpaceShipDataRepository : ISpaceShipDataRepository
    {
        private readonly SIGEMDBDataContext dataContext = new SIGEMDBDataContext();

        /// <summary>
        /// Gets the space ships.
        /// </summary>
        /// <returns>
        /// List of spaceships
        /// </returns>
        public IEnumerable<SpaceShip> GetSpaceShips()
        {
            var spaceships = from sps in dataContext.SpaceShips
                             select sps;

            return spaceships;
        }

        /// <summary>
        /// Saves the space ship.
        /// </summary>
        /// <param name="spaceShip">The space ship.</param>
        public void SaveSpaceShip(SpaceShip spaceShip)
        {
            dataContext.SpaceShips.InsertOnSubmit(spaceShip);
            dataContext.SubmitChanges();
        }
    }
}
