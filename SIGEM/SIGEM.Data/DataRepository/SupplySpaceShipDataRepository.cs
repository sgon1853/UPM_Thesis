using System.Collections.Generic;
using System.Linq;
using SIGEM.Data.Interfaces;

namespace SIGEM.Data.DataRepository
{
    public class SupplySpaceShipDataRepository : ISupplySpaceShipDataRepository
    {
        private readonly SIGEMDBDataContext dataContext = new SIGEMDBDataContext();

        #region IDataRepository Members

        /// <summary>
        /// Saves the supply space ship.
        /// </summary>
        /// <param name="supplySpaceShip">The supply space ship.</param>
        public void SaveSupplySpaceShip(SupplySpaceShip supplySpaceShip)
        {
            dataContext.SupplySpaceShips.InsertOnSubmit(supplySpaceShip);
            dataContext.SubmitChanges();
        }

        /// <summary>
        /// Gets the supply space ships.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SupplySpaceShip> GetSupplySpaceShips()
        {
            var supplySpaceShips = from sps in dataContext.SupplySpaceShips
                                   select sps;

            return supplySpaceShips;
        }

        #endregion
    }
}
