
using Microsoft.Practices.Unity;
using SIGEM.Data.DataRepository;
using SIGEM.Data.Interfaces;
using SIGEM.Windows.Commands;
using SIGEM.Windows.Helpers;
using SIGEM.Windows.Interfaces;

namespace SIGEM.Windows.Configure
{
    public class Bootsrapper
    {
        /// <summary>
        /// Startups this instance.
        /// </summary>
        public void Startup()
        {
            UnityHelper.Container.RegisterType<ISupplySpaceShipDataRepository, SupplySpaceShipDataRepository>();
            UnityHelper.Container.RegisterType<ISpaceShipDataRepository, SpaceShipDataRepository>();
            UnityHelper.Container.RegisterType<ISpaceShipDataRepository, SpaceShipDataRepository>();
            UnityHelper.Container.RegisterType<ISpaceShipOcupationDataRepository, SpaceShipOcupationDataRepository>();
            UnityHelper.Container.RegisterType<IPassengerDataRepository, PassengerDataRepository>();
            UnityHelper.Container.RegisterType<IInspectionDataRepository, InspectionDataRepository>();
            UnityHelper.Container.RegisterType<IInspectionHystoricCommand, InspectionHystoricCommand>();
        }
    }
}
