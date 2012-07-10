using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using SIGEM.Data.Interfaces;

namespace SIGEM.Data.DataRepository
{
    public class PassengerDataRepository: BaseDataRepository, IPassengerDataRepository
    {
        /// <summary>
        /// Gets the passenger.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>
        /// A Passenger object.
        /// </returns>
        public Passenger GetPassenger(string id)
        {
            var passenger = from p in DataContext.Passengers
                            where p.Id == id
                            select p;

            return passenger.SingleOrDefault();
        }

        /// <summary>
        /// Gets the passengers.
        /// </summary>
        /// <returns>
        /// A passenger object.
        /// </returns>
        public IEnumerable<Passenger> GetPassengers()
        {
            var passengers = from p in DataContext.Passengers
                            select p;

            return passengers;
        }

        /// <summary>
        /// Saves the passenger.
        /// </summary>
        /// <param name="passenger">The passenger.</param>
        public void SavePassenger(Passenger passenger)
        {
            DataContext.Passengers.InsertOnSubmit(passenger);
            DataContext.SubmitChanges();
        }
    }
}
