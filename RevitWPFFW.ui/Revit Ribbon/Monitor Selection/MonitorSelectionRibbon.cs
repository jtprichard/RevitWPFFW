using Autodesk.Revit.UI;
using PB.RevitWPFFW.core;

namespace PB.RevitWPFFW.ui
{
    /// <summary>
    /// Creates temporary ribbon tab, panel, and button
    /// That is then translated to quick access toolbar
    /// To allow for selection monitoring events
    /// </summary>
    public class MonitorSelectionRibbon
    {
        #region Public Fields
        public static readonly string TabName = "MonitorSelectionTab";
        public static readonly string PanelName = "MonitorSelectionPanel";
        public static readonly string ButtonName = "MonitorSelectionButton";
        #endregion

        #region Public Methods
        /// <summary>
        /// Create Ribbonb Panel
        /// </summary>
        /// <param name="uiapp"></param>
        public static void CreateRibbon(UIControlledApplication uiapp)
        {
            uiapp.CreateRibbonTab(TabName);
            RibbonPanel rp = uiapp.CreateRibbonPanel(TabName, PanelName);
            string thisAssemblyPath = ApplicationAssembly.GetAssemblyLocation();
            string commandPath = MonitorSelectionCommand.GetPath();
            PushButtonData buttonData = new PushButtonData(ButtonName, string.Format("X"), thisAssemblyPath, commandPath)
            {
                AvailabilityClassName = MonitorSelectionEnabler.GetPath()
            };
            rp.AddItem(buttonData);
        }
        #endregion
    }
}
