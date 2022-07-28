using System.Windows;
using PB.MVVMToolkit.DialogServices;
using PB.RevitWPFFW.core;

namespace PB.RevitWPFFW.ui
{
    /// <summary>
    /// Registration class for dialog services
    /// </summary>
    public static class DialogRegistration
    {
        /// <summary>
        /// Returns service links for dialogs using a Window element as the owner.  
        /// For Revit, the main Revit Window should be obtained via the MainWindowHandle property
        /// in the UIApplication or UIControlledApplication class.
        /// </summary>
        /// <param name="window">Window element</param>
        /// <returns>DialogService element</returns>
        public static void SetServices(Window window)
        {
            DialogService dialogService = new DialogService(window);

            //Register dialog views with viewmodels here
            dialogService.Register<CustomDialogViewModel, CustomDialogView>();

            //Store the Dialog Service in the RevitControlledApplication Object
            RevitControlledApplication.SetDialogService(dialogService);

        }

    }
}
