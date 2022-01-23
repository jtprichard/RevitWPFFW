using PB.MVVMToolkit.DialogServices;
using System.Windows.Controls;
using PB.RevitWPFFW.core;

namespace PB.RevitWPFFW.ui
{
    /// <summary>
    /// Registration class for dialog services
    /// </summary>
    public static class DialogRegistration
    {
        /// <summary>
        /// Returns service links for dialogs using a Page element as the owner.  
        /// Pages are used for Revit services for dockpanels.
        /// </summary>
        /// <param name="page">Page element</param>
        /// <returns>DialogService element</returns>
        public static void SetServices(Page page)
        {
            DialogService dialogService = new DialogService(page);

            //Register dialog views with viewmodels here
            dialogService.Register<CustomDialogViewModel, CustomDialogView>();

        }

    }
}
