using PB.MVVMToolkit.DialogServices;
using System.Windows.Controls;
using RevitWPFFW.core;

namespace RevitWPFFW.ui
{
    /// <summary>
    /// Registration class for dialog services
    /// </summary>
    public class DialogRegistration
    {
        /// <summary>
        /// Singleton Instantiation
        /// </summary>
        private DialogRegistration(){}

        private static DialogRegistration _registration = null;
        /// <summary>
        /// Registration element
        /// </summary>
        public static DialogRegistration Registration
        {
            get
            {
                if (_registration == null)
                    _registration = new DialogRegistration();
                return _registration;
            }
        }
        /// <summary>
        /// Returns service links for dialogs using a Page element as the owner.  
        /// Pages are used for Revit services for dockpanels.
        /// </summary>
        /// <param name="page">Page element</param>
        /// <returns>DialogService element</returns>
        public DialogService GetServices(Page page)
        {

            DialogService dialogService = new DialogService(page);

            //Register dialog views with viewmodels here
            //dialogService.Register<DialogOkCancelViewModel, DialogOkCancelView>();
            //dialogService.Register<CustomDialogViewModel, CustomBaseDialogView>();
            dialogService.Register<CustomDialogViewModel, CustomDialogView>();

            return dialogService;
        }

    }
}
