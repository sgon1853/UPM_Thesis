using System.Collections.Generic;
using System.Linq;
using SIGEM.Data.Interfaces;

namespace SIGEM.Data.DataRepository
{
    public class SupplySpaceShipDataRepository : BaseDataRepository, ISupplySpaceShipDataRepository
    {
        #region IDataRepository Members

        /// <summary>
        /// Saves the supply space ship.
        /// </summary>
        /// <param name="supplySpaceShip">The supply space ship.</param>
        public void SaveSupplySpaceShip(SupplySpaceShip supplySpaceShip)
        {
            DataContext.SupplySpaceShips.InsertOnSubmit(supplySpaceShip);
            DataContext.SubmitChanges();
        }

        /// <summary>
        /// Gets the supply space ships.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SupplySpaceShip> GetSupplySpaceShips()
        {
            var supplySpaceShips = from sps in DataContext.SupplySpaceShips
                                   select sps;

            return supplySpaceShips;
        }

        #endregion
    }
}
