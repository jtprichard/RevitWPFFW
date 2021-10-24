using System;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using PB.MVVMToolkit.DialogServices;


namespace RevitWPFFW.core
{
    /// <summary>
    /// A Sample Revit Command Initiated from the Ribbon
    /// </summary>
    /// <seealso cref="Autodesk.Revit.UI.IExternalCommand"/>
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class OpenDialogCommand : IExternalCommand
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
            var dialogService = DialogService.Instance;
            
            var vm = new CustomDialogViewModel();
            vm.OkClicked += OptionOk;
            vm.CancelClicked += OptionCancel;
            if (dialogService != null)
                dialogService.ShowDialog(vm);

            return Result.Succeeded;
        }

        #endregion

        #region Private Methods

        private void OptionOk(object sender, EventArgs e)
        {

        }

        private void OptionCancel(object sender, EventArgs e)
        {

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
