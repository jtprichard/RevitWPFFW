using Autodesk.Revit.UI;
using System.Reflection;
using PB.RevitWPFFW.core;

namespace PB.RevitWPFFW.ui
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
        /// <summary>
        /// CurrentViewModel of Ribbon
        /// Creates instance if none exists
        /// </summary>
        public static RibbonInterface Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new RibbonInterface();
                return _instance;
            }
        }
        /// <summary>
        /// Name of Ribbon Tab
        /// </summary>
        public string TabName { get; private set; }
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
        /// <param name="helpFilePath">Help File Path as String</param>
        public void Initialize(UIControlledApplication uiapp, string tabName, string helpFilePath)
        {
            //Initialize the Ribbon ViewModel to Store Ribbon Data
            _ = RevitRibbonViewModel.Instance;

            //Create Ribbon Tab
            uiapp.CreateRibbonTab(tabName);
            TabName = tabName;

            //Create Ribbon Panels from Static Classes for Each Panel
            _ = new TemplatePanel().Create(uiapp, tabName, helpFilePath);
            _ = new TestRibbonPanel().Create(uiapp, tabName);

        }

        #endregion
    }
}
