using System.Collections.Generic;

namespace SIGEM.Data.Interfaces
{
    public interface IPassengerDataRepository
    {
        /// <summary>
        /// Gets the passenger.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>A Passenger object.</returns>
        Passenger GetPassenger(string id);

        /// <summary>
        /// Gets the passengers.
        /// </summary>
        /// <returns>A passenger object.</returns>
        IEnumerable<Passenger> GetPassengers();

        /// <summary>
        /// Saves the passenger.
        /// </summary>
        /// <param name="passenger">The passenger.</param>
        void SavePassenger(Passenger passenger);
    }
}
