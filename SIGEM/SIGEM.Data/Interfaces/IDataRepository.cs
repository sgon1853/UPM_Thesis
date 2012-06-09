using System.Collections.Generic;

namespace SIGEM.Data.Interfaces
{
    interface IDataRepository
    {
        void SaveSupplySpaceShip(SupplySpaceShip supplySpaceShip);
        IEnumerable<SupplySpaceShip> GetSupplySpaceShips();
    }
}
