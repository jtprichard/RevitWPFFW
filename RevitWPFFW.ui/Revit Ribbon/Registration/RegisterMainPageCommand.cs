using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;
using System.Windows;
using RevitWPFFW.core;

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
            //Title of Dockable WPF Pane
            string paneTitle = "Revit WPF Template";

            var data = new DockablePaneProviderData();
            var mainPage = new MainPage();

            data.FrameworkElement = mainPage as FrameworkElement;

            //use unique guid identifier for this dockable pane
            var dpid = new DockablePaneId(DockablePaneIdentifier.GetMainPaneIdentifier());

            //register pane
            uiApp.RegisterDockablePane(dpid, paneTitle, mainPage);

            return Result.Succeeded;
        }
    }
}
