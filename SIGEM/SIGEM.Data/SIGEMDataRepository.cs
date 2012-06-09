using System.Linq;
using SIGEM.Data.Interfaces;

namespace SIGEM.Data
{
    public class SigemDataRepository:IDataRepository
    {
        private readonly SIGEMDBDataContext dataContext = new SIGEMDBDataContext();

        #region IDataRepository Members

        public void SaveSupplySpaceShip(SupplySpaceShip supplySpaceShip)
        {
            dataContext.SupplySpaceShips.InsertOnSubmit(supplySpaceShip);
        }

        public System.Collections.Generic.IEnumerable<SupplySpaceShip> GetSupplySpaceShips()
        {
            var supplySpaceShips = from sps in dataContext.SupplySpaceShips
                                   select sps;

            return supplySpaceShips;
        }

        #endregion
    }
}
