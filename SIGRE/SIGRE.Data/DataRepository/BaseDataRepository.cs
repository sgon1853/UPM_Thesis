namespace SIGRE.Data.DataRepository
{
    public class BaseDataRepository
    {
        protected readonly SIGREDBDataContext DataContext;

        public BaseDataRepository()
        {
            DataContext = new SIGREDBDataContext();
        }
    }
}
