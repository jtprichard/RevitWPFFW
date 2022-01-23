using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace PB.RevitWPFFW.core
{
    /// <summary>
    /// A Sample Revit Command Initiated from the Ribbon
    /// </summary>
    /// <seealso cref="Autodesk.Revit.UI.IExternalCommand"/>
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class SampleRevitCommand : IExternalCommand
    {
        #region Command Execution
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

            var testdocs = RevitDocument.CurrentDocument;
            
            TaskDialog.Show("Test Command", RevitRibbonViewModel.Instance.RibbonComboBox);
            
            return Result.Succeeded;
        }

        #endregion

        #region Private Methods


        #endregion

        #region Public Methods
        /// <summary>
        /// Returns the path for the command namespace on the Ribbon
        /// </summary>
        /// <returns></returns>
        public static string GetPath()
        {
            //return constructed namespace path
            return typeof(SampleRevitCommand).Namespace + "." + nameof(SampleRevitCommand);
        }

        #endregion
    }
}
