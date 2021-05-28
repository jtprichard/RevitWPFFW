using System;
using Autodesk.Revit.UI;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Windows;
using Autodesk.Revit.DB.Events;
using RevitWPFFW.core;
using RevitWPFFW.ui;

namespace RevitWPFFW
{
    internal class EventFactory
    {
        #region Primary Methods
        /// <summary>
        /// Startup Events
        /// </summary>
        /// <param name="a"></param>
        internal static void Startup(UIControlledApplication a)
        {

            //Register dockable panes on applicaiton initialization
            a.ControlledApplication.ApplicationInitialized += DockablePaneRegisters;

            //Register document opened properties
            a.ControlledApplication.DocumentOpened += new EventHandler<DocumentOpenedEventArgs>(OnDocumentOpened);

            //Register Event Handler to monitor selections
            //a.ControlledApplication.ApplicationInitialized += new EventHandler<ApplicationInitializedEventArgs>(MonitorSelectionInitialized);
        }

        /// <summary>
        /// Shutdown Events
        /// </summary>
        /// <param name="a"></param>
        internal static void ShutDown(UIControlledApplication a)
        {
            a.ControlledApplication.ApplicationInitialized -= DockablePaneRegisters;
            a.ControlledApplication.DocumentOpened -= OnDocumentOpened;

            //a.ControlledApplication.ApplicationInitialized -= MonitorSelectionInitialized;
        }

        #endregion

        #region Private Methods
        /// <summary>
        /// Register the dockable panes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void DockablePaneRegisters(object sender, ApplicationInitializedEventArgs e)
        {
            //register dockable pane
            var mainWPFRegisterCommand = new RegisterMainPageCommand();
            mainWPFRegisterCommand.Execute(new UIApplication(sender as Application));
        }

        /// <summary>
        /// Register the Revit Document for access from the applications
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private static void OnDocumentOpened(object sender, DocumentOpenedEventArgs args)
        // Document Opened Events
        {
            //RevitDocument.RevitDoc = args.Document;
            RevitDocument doc = new RevitDocument(args.Document);

            //SeatPropertiesPageViewModel.UpdateViewModelData();
        }

        #endregion

    }
}
