using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;
using System.Windows;
using RevitWPFFW.core;
using System;

namespace RevitWPFFW.ui
{
    /// <summary>
    /// Register Main Page in zero state document
    /// </summary>
    /// <seealso cref="Autodesk.Revit.UI.IExternalCommand"/>

    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class RegisterMainPageCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            return Execute(commandData.Application);
        }

        public Result Execute(UIApplication uiApp)
        {

            var data = new DockablePaneProviderData();
            var mainPage = new MainPage();

            data.FrameworkElement = mainPage as FrameworkElement;

            //use unique guid identifier for this dockable pane
            var dpid = new DockablePaneId(DockablePaneIdentifier.GetMainPaneIdentifier());

            //register pane
            uiApp.RegisterDockablePane(dpid, "Revit WPF Template", mainPage as IDockablePaneProvider);

            return Result.Succeeded;
        }
    }
}
