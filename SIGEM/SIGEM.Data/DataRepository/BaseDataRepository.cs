namespace SIGEM.Data.DataRepository
{
    public class BaseDataRepository
    {
        protected readonly SIGEMDBDataContext DataContext;

        public BaseDataRepository()
        {
            DataContext = new SIGEMDBDataContext();
        }
    }
}
