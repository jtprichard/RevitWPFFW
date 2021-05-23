using Autodesk.Revit.UI;
using System.Reflection;
using RevitWPFFW.core;

namespace RevitWPFFW.ui
{
    /// <summary>
    /// Creates Ribbon Tabs and Buttons for Project
    /// Uses Singlton (non-Thread Safe) pattern
    /// </summary>
    public sealed class RibbonInterface
    {
        #region Fields
        private static RibbonInterface _instance = null;
        #endregion

        #region Properties
        public static RibbonInterface Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new RibbonInterface();
                return _instance;
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Default Constructor
        /// </summary>
        private RibbonInterface() { }
        #endregion

        #region Public Methods

        /// <summary>
        /// Ribbon Initialize Method
        /// </summary>
        /// <param name="uiapp">UIControlled Application</param>
        /// <param name="tabName">Revit Ribbon Tab Name</param>
        /// <param name="panelName">Revit Ribbon Panel Name</param>
        public void Initialize(UIControlledApplication uiapp, string tabName, string panelName)
        {
            //Get assembly path 
            string path = Assembly.GetExecutingAssembly().Location;

            //Create Ribbon Tab
            uiapp.CreateRibbonTab(tabName);

            //Create Ribbon Panels
            RibbonPanel panel = uiapp.CreateRibbonPanel(tabName, panelName);

            #region Button - Show Form

            //Family Mangaer - Show Form Command

            var seatTestFormButtonData = new RevitPushButtonData
            {
                Label = "Show Test\nForm",
                Panel = panel,
                Tooltip = "Tooltip Sample",
                CommandNamespacePath = ShowWPFMainFormCommand.GetPath(),
                IconImageName = "duplicate.png",
                //TooltipImageName = "tooltip_ShowFamilyManger_32x32.png"
            };
            var testButton = RevitPushButton.Create(seatTestFormButtonData);

            #endregion

            #region Button - Show Form Info

            var showFormInfoButtonData = new RevitPushButtonData
            {
                Label = "Show Form\nInfo",
                Panel = panel,
                CommandNamespacePath = ShowFormInfo.GetPath(),

            };
            var showFormInfoButton = RevitPushButton.Create(showFormInfoButtonData);

            #endregion
        }

        #endregion
    }
}
