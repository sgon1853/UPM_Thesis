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
        /// Removes the passenger from space ship.
        /// </summary>
        /// <param name="spaceShipOcupation">The space ship ocupation.</param>
        void RemovePassengerFromSpaceShip(SpaceShipOcupation spaceShipOcupation);

        /// <summary>
        /// Gets the space ship ocupations.
        /// </summary>
        /// <returns>A SpaceShipOcupation Object.</returns>
        IEnumerable<SpaceShipOcupation> GetAllSpaceShipOcupations();

        /// <summary>
        /// Gets the space ship ocupations.
        /// </summary>
        /// <param name="idSpaceship">The id spaceship.</param>
        /// <returns></returns>
        IEnumerable<SpaceShipOcupation> GetSpaceShipOcupations(string idSpaceship);

    }
}
