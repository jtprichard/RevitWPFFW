using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace PB.RevitWPFFW.core
{
    /// <summary>
    /// Command Class required for Selection Monitoring Event
    /// Used only because button requires an associated command
    /// Command does not performan a function
    /// </summary>
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    public class MonitorSelectionCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            return Result.Succeeded;
        }

        #region Public Methods
        /// <summary>
        /// Returns the path for the command namespace on the Ribbon
        /// </summary>
        /// <returns></returns>
        public static string GetPath()
        {
            //return constructed namespace path
            return typeof(MonitorSelectionCommand).Namespace + "." + nameof(MonitorSelectionCommand);
        }

        #endregion
    }
}
