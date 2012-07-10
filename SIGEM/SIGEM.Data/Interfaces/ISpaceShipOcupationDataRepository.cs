using System.Collections.Generic;

namespace SIGEM.Data.Interfaces
{
    public interface ISpaceShipOcupationDataRepository
    {
        /// <summary>
        /// Assigns the passenger to space ship.
        /// </summary>
        /// <param name="spaceShipOcupation">The space ship ocupation.</param>
        void AssignPassengerToSpaceShip(SpaceShipOcupation spaceShipOcupation);

        /// <summary>
        /// Gets the space ship ocupations.
        /// </summary>
        /// <returns>A SpaceShipOcupation Object.</returns>
        IEnumerable<SpaceShipOcupation> GetSpaceShipOcupations();
    }
}
