using System;
using System.Collections.Generic;
using System.IO;
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
    public class TestCommand : IExternalCommand
    {
        Document _doc;

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
            //Get UI Document
            var uidoc = commandData.Application.ActiveUIDocument;
            var uiapp = uidoc.Application;

            //Get Document
            var doc = uidoc.Document;
            _doc = doc;

            Element ele;

            using (Transaction t = new Transaction(doc, "TestCommand"))
            {
                t.Start();


                t.Commit();

            }
   
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
            return typeof(TestCommand).Namespace + "." + nameof(TestCommand);
        }

        #endregion
    }
}
