using System;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using PB.MVVMToolkit.DialogServices;


namespace PB.RevitWPFFW.core
{
    /// <summary>
    /// A Sample Revit Command Initiated from the Ribbon
    /// </summary>
    /// <seealso cref="Autodesk.Revit.UI.IExternalCommand"/>
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class OpenDialogCommand : IExternalCommand
    {
        private Document _doc;

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
            var dialogService = RevitControlledApplication.GetDialogService();
            
            var vm = new CustomDialogViewModel();
            vm.OkClicked += OptionOk;
            vm.CancelClicked += OptionCancel;
            if (dialogService != null)
                dialogService.ShowDialog(vm);

            return Result.Succeeded;
        }

        #endregion

        #region Private Methods
        /// <summary>
        /// Method actions when dialog OK is clicked
        /// </summary>
        /// <param name="sender">Dialog object</param>
        /// <param name="e">Event arguments from dialog</param>
        private void OptionOk(object sender, EventArgs e)
        {
            //Perform actions based on Ok being clicked on the dialog
        }

        /// <summary>
        /// Method actions when dialog Cancel is clicked
        /// </summary>
        /// <param name="sender">Dialog object</param>
        /// <param name="e">Event arguments from dialog</param>
        private void OptionCancel(object sender, EventArgs e)
        {
            //Perform actions based on Cancel being clicked on the dialog
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Returns the path for the command namespace on the Ribbon
        /// </summary>
        /// <returns></returns>
        public static string GetPath()
        {
            //return constructed namespace path
            return typeof(OpenDialogCommand).Namespace + "." + nameof(OpenDialogCommand);
        }

        #endregion
    }
}
