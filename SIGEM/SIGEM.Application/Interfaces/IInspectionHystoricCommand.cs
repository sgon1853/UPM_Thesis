namespace SIGEM.Windows.Interfaces
{
    public interface IInspectionHystoricCommand
    {
        /// <summary>
        /// Shows the inspection hystoric by spaceship id.
        /// </summary>
        /// <param name="spaceshipId">The spaceship id.</param>
        void ShowInspectionHystoricBySpaceshipId(string spaceshipId);
    }
}
