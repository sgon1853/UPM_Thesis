using System.Collections.Generic;

namespace SIGEM.Data.Interfaces
{
    public interface ISupplySpaceShipDataRepository
    {
        void SaveSupplySpaceShip(SupplySpaceShip supplySpaceShip);
        IEnumerable<SupplySpaceShip> GetSupplySpaceShips();
    }
}
