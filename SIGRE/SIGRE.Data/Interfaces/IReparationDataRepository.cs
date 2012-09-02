using System.Collections.Generic;

namespace SIGRE.Data.Interfaces
{
    public interface IReparationDataRepository
    {
        IEnumerable<Reparation> GetAllReparations();

        Reparation GetReparationById(string idReparation);

        void SaveReparation(Reparation reparation);
    }
}
