using System.Collections.Generic;

namespace SIGEM.Data.Interfaces
{
    interface ISupplySpaceShipDataRepository
    {
        void SaveSupplySpaceShip(SupplySpaceShip supplySpaceShip);
        IEnumerable<SupplySpaceShip> GetSupplySpaceShips();
    }
}
