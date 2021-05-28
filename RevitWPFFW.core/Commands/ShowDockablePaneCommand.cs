using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitWPFFW.core
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

            if (dp.IsShown())
                dp.Hide();
            else
                dp.Show();

            return Result.Succeeded;
        }

        public static string GetPath()
        {
            //return constructed namespace path
            return typeof(ShowDockablePaneCommand).Namespace + "." + nameof(ShowDockablePaneCommand);
        }
        #endregion
    }
}
