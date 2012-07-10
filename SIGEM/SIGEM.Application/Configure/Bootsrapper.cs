
using Microsoft.Practices.Unity;
using SIGEM.Data.DataRepository;
using SIGEM.Data.Interfaces;
using System.Windows;
using SIGEM.Windows.Helpers;

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
        }
    }
}
