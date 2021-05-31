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

        public static RibbonInterface Ribbon;

        #endregion

        #region Entry and Exit Points
        /// <summary>
        /// Main startup application
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public Result OnStartup(UIControlledApplication uiApp)
        {            
            //Initialize Fields
            string tabName = "REVIT TEMPLATE";

            //Initialize ribbon panels
            var ri = RibbonInterface.Instance;
            ri.Initialize(uiApp, tabName);
            Ribbon = ri;

            //Initialize Selection Monitor Ribbon
            MonitorSelectionRibbon.CreateRibbon(uiApp);

            //Startup Events
            EventFactory.Startup(uiApp);

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

        #endregion
    }
}
