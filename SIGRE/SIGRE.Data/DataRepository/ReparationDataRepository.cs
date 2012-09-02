using System.Collections.Generic;
using System.Linq;
using SIGRE.Data.Interfaces;

namespace SIGRE.Data.DataRepository
{
    public class ReparationDataRepository : BaseDataRepository, IReparationDataRepository
    {
        public IEnumerable<Reparation> GetAllReparations()
        {
            var reparations = from r in DataContext.Reparations
                              select r;

            return reparations;
        }

        public Reparation GetReparationById(string idReparation)
        {
            var reparation = (from r in DataContext.Reparations
                              where r.IdReparation == idReparation
                              select r).SingleOrDefault();

            return reparation;
        }

        public void SaveReparation(Reparation reparation)
        {
            DataContext.Reparations.InsertOnSubmit(reparation);
            DataContext.SubmitChanges();
        }
    }
}
