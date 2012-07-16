using System.Collections.Generic;

namespace SIGEM.Data.Interfaces
{
    public interface ISpaceShipDataRepository
    {
        /// <summary>
        /// Gets the space ships.
        /// </summary>
        /// <returns>List of spaceships</returns>
        IEnumerable<SpaceShip> GetSpaceShips();

        /// <summary>
        /// Gets the space ships.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        SpaceShip GetSpaceShip(string id);

        /// <summary>
        /// Saves the space ship.
        /// </summary>
        /// <param name="spaceShip">The space ship.</param>
        void SaveSpaceShip(SpaceShip spaceShip);
    }
}
