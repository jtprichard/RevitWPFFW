using System.Windows;
using System.Windows.Interop;
using Autodesk.Revit.DB.Events;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Events;
using Autodesk.Windows;
using PB.RevitWPFFW.core;
using PB.RevitWPFFW.ui;
using Application = Autodesk.Revit.ApplicationServices.Application;

namespace PB.RevitWPFFW
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

            //Register event handler to update document on view activated
            a.ViewActivated += OnViewActivated;

            //Register document opened properties
            a.ControlledApplication.DocumentOpened += OnDocumentOpened;

            //Register Event Handler to monitor selections
            a.ControlledApplication.ApplicationInitialized += MonitorSelectionInitialized;

            //Register Dialog Services
            RegisterDialogs(a);
        }

        private static void OnViewActivated(object sender, ViewActivatedEventArgs e)
        {
            RevitDocument.SetCurrentDocument(e.Document);
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
            a.ViewActivated -= OnViewActivated;
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
            //Instantiate new RevitDocument object and associated ViewModels for reference
            RevitDocument.SetCurrentDocument(args.Document);

            var dpid = new DockablePaneId(DockablePaneIdentifier.GetMainPaneIdentifier());
            var dp = RevitControlledApplication.GetCurrentApplication().GetDockablePane(dpid);

            //Hide Dockable Pane on Startup
            //if (dp.IsShown())
            //    dp.Hide();

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
                var position = global::PB.RevitWPFFW.ui.Utilities.GetPositionBeforeButton("ID_REVIT_FILE_PRINT");
                global::PB.RevitWPFFW.ui.Utilities.PlaceButtonOnQuickAccess(position, foundItem);
                global::PB.RevitWPFFW.ui.Utilities.RemovePanelFromTab(foundTab, foundPanel);
                global::PB.RevitWPFFW.ui.Utilities.RemoveTabFromRibbon(foundTab);
            }
        }

        /// <summary>
        /// Register DialogServices Object with Revit Window as Owner
        /// </summary>
        /// <param name="uiapp">Revit UIControlledApplication Object</param>
        private static void RegisterDialogs(UIControlledApplication uiapp)
        {
            var rvtHandle = uiapp.MainWindowHandle;

            HwndSource hwndSource = HwndSource.FromHwnd(rvtHandle);
            Window wnd = hwndSource.RootVisual as Window;

            DialogRegistration.SetServices(wnd);

        }

        #endregion

    }
}
