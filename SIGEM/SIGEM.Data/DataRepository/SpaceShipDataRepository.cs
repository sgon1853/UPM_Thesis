using System;
using System.Collections.Generic;
using System.Linq;
using SIGEM.Data.Interfaces;

namespace SIGEM.Data.DataRepository
{
    public class SpaceShipDataRepository : BaseDataRepository, ISpaceShipDataRepository
    {
        /// <summary>
        /// Gets the space ships.
        /// </summary>
        /// <returns>
        /// List of spaceships
        /// </returns>
        public IEnumerable<SpaceShip> GetSpaceShips()
        {
            var spaceships = from sps in DataContext.SpaceShips
                             select sps;

            return spaceships;
        }

        /// <summary>
        /// Gets the space ships.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public SpaceShip GetSpaceShip(string id)
        {
            var spaceships = from sps in DataContext.SpaceShips
                             where sps.Id == id
                             select sps;

            return spaceships.FirstOrDefault();
        }

        /// <summary>
        /// Saves the space ship.
        /// </summary>
        /// <param name="spaceShip">The space ship.</param>
        public void SaveSpaceShip(SpaceShip spaceShip)
        {
            try
            {
                DataContext.SpaceShips.InsertOnSubmit(spaceShip);
                DataContext.SubmitChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
