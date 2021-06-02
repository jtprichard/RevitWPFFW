using System;
using Autodesk.Revit.UI;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Windows;
using Autodesk.Revit.DB.Events;
using RevitWPFFW.core;
using RevitWPFFW.ui;

namespace RevitWPFFW
{
    /// <summary>
    /// Event registration class at startup
    /// </summary>
    internal class EventFactory
    {
        #region Primary Methods
        /// <summary>
        /// Startup Events
        /// </summary>
        /// <param name="a"></param>
        internal static void Startup(UIControlledApplication a)
        {
            //Store UIControlledApplication for use
            _ = new RevitControlledApplication(a);
            
            //Register dockable panes on applicaiton initialization
            a.ControlledApplication.ApplicationInitialized += DockablePaneRegisters;

            //Register document opened properties
            a.ControlledApplication.DocumentOpened += new EventHandler<DocumentOpenedEventArgs>(OnDocumentOpened);

            //Register Event Handler to monitor selections
            a.ControlledApplication.ApplicationInitialized += new EventHandler<ApplicationInitializedEventArgs>(MonitorSelectionInitialized);
        }


        /// <summary>
        /// Shutdown Events
        /// </summary>
        /// <param name="a"></param>
        internal static void ShutDown(UIControlledApplication a)
        {
            a.ControlledApplication.ApplicationInitialized -= DockablePaneRegisters;
            a.ControlledApplication.DocumentOpened -= OnDocumentOpened;
            a.ControlledApplication.ApplicationInitialized -= MonitorSelectionInitialized;
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
            //Instantiating the class automatically creates a static document for reference
            _ = new RevitDocument(args.Document);

            //Hide Dockable Pane on Startup
            var dpid = new DockablePaneId(DockablePaneIdentifier.GetMainPaneIdentifier());
            var dp = RevitControlledApplication.GetCurrentApplication().GetDockablePane(dpid);

            if (dp.IsShown())
                dp.Hide();

            //Initialize WPF ViewModels for Initial Properties
            MainPageViewModel.Initialize();

        }

        /// <summary>
        /// Register Unused (Dummy) Ribbon Panel creation that allows monitoring
        /// of a model element selection.
        /// Blank button is created in quick access toolbar for monitoring
        /// Ref from FAIR59
        /// https://forums.autodesk.com/t5/revit-api-forum/element-selection-changed-event-implementation-struggles/td-p/9229523
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void MonitorSelectionInitialized(object sender, ApplicationInitializedEventArgs e)
        {
            RibbonTab foundTab = null;
            Autodesk.Windows.RibbonPanel foundPanel = null;
            Autodesk.Windows.RibbonItem foundItem = null;

            //Search for the button item to place on quick access toolbar
            foreach (var tab in ComponentManager.Ribbon.Tabs)
            {
                if (tab.Id == MonitorSelectionRibbon.TabName)
                {
                    foundTab = tab;

                    foreach (var panel in tab.Panels)
                    {
                        if (panel.Source.Title == MonitorSelectionRibbon.PanelName)
                        {
                            foundPanel = panel;

                            foreach (var item in panel.Source.Items)
                            {
                                string tmpButton = "CustomCtrl_%CustomCtrl_%" + tab.Id + "%" + panel.Source.Title + "%" + MonitorSelectionRibbon.ButtonName;
                                if (item.Id == tmpButton)
                                {
                                    foundItem = item;
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            //If button is found, place button on quick access toolbar for monitoring 
            if (foundPanel != null && foundItem != null)
            {
                var position = Utilities.GetPositionBeforeButton("ID_REVIT_FILE_PRINT");
                Utilities.PlaceButtonOnQuickAccess(position, foundItem);
                Utilities.RemovePanelFromTab(foundTab, foundPanel);
                Utilities.RemoveTabFromRibbon(foundTab);
            }
        }

        #endregion

    }
}
