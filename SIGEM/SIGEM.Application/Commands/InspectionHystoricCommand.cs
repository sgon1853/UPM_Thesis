using SIGEM.Windows.Helpers;
using SIGEM.Windows.Interfaces;
using SIGEM.Windows.ViewModels;
using System.Windows;

namespace SIGEM.Windows.Commands
{
    public class InspectionHystoricCommand : IInspectionHystoricCommand
    {
        /// <summary>
        /// Shows the inspection hystoric by spaceship id.
        /// </summary>
        /// <param name="spaceshipId">The spaceship id.</param>
        public void ShowInspectionHystoricBySpaceshipId(string spaceshipId)
        {
           var inspectionHystoricView = UserControlHelper.GetView("InspectionHystoric");
            var viewModel = inspectionHystoricView.DataContext as InspectionHystoricViewModel;
            if (viewModel == null)
            {
                MessageBox.Show("Error mostrando el historial del aeronave.");
            }
            else
            {
                viewModel.SpaceshipId = spaceshipId;    
                viewModel.ShowSpaceshipInspectionHystoricCommand.Execute(null);
                UserControlHelper.ShowView(inspectionHystoricView);
            }
        }
    }
}
