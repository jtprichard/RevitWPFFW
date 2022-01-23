using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace PB.RevitWPFFW.core
{
    /// <summary>
    /// Show Family Manager dockable pane
    /// </summary>
    /// <seealso cref="Autodesk.Revit.UI.IExternalCommand"/>
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class ShowDockablePaneCommand : IExternalCommand
    {
        #region Public Methods
        /// <summary>
        /// Executes the specified command data
        /// </summary>
        /// <param name="commandData">The command data</param>
        /// <param name="message">The message</param>
        /// <param name="elements">The elements</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            var dpid = new DockablePaneId(DockablePaneIdentifier.GetMainPaneIdentifier());
            var dp = commandData.Application.GetDockablePane(dpid);

            TogglePane(dp);

            return Result.Succeeded;
        }

        /// <summary>
        /// Returns the path for the command namespace on the Ribbon
        /// </summary>
        /// <returns></returns>
        public static string GetPath()
        {
            //return constructed namespace path
            return typeof(ShowDockablePaneCommand).Namespace + "." + nameof(ShowDockablePaneCommand);
        }
        #endregion

        #region Private Methods
        private void TogglePane(DockablePane dp) 
        {
            if (null != dp)
            {
                if (dp.IsShown())
                {
                    dp.Hide();
                    RevitRibbonViewModel.TurnPageButtonImageOff();
                }
                else
                {
                    dp.Show();
                    RevitRibbonViewModel.TurnPageButtonImageOn();
                }
            }
            else
                return;

        }


        #endregion
    }
}
