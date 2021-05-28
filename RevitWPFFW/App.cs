using RevitWPFFW.ui;
using Autodesk.Revit.UI;

namespace RevitWPFFW
{
    /// <summary>
    /// Entry Application
    /// </summary>
    class App : IExternalApplication
    {

        #region Fields

        public static UIControlledApplication UIContApp;
        public static RibbonInterface Ribbon;

        #endregion


        /// <summary>
        /// Main startup application
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public Result OnStartup(UIControlledApplication a)
        {
            //Initialize Fields
            UIContApp = a;
            string tabName = "REVIT TEMPLATE";

            //Initialize ribbon panels
            var ri = RibbonInterface.Instance;
            ri.Initialize(a, tabName);
            Ribbon = ri;

            //Initialize Selection Monitor Ribbon
            //MonitorSelectionRibbon.CreateRibbon(UIContApp);

            //Startup Events
            EventFactory.Startup(a);

            return Result.Succeeded;
        }

        /// <summary>
        /// Shutdown Events
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public Result OnShutdown(UIControlledApplication a)
        {
            //EventFactory.ShutDown(a);
            return Result.Succeeded;
        }

    }
}
