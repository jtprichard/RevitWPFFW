using System;
using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.UI;
using PB.RevitWPFFW.core;
using PB.RevitWPFFW.res;
using Autodesk.Revit.UI.Events;

namespace PB.RevitWPFFW.ui
{
    /// <summary>
    /// Class to add Revit Ribbon Panel
    /// </summary>
    internal class TestRibbonPanel
    {
        #region Constructor
        /// <summary>
        /// Default Constructor
        /// </summary>
        internal TestRibbonPanel() { }
        #endregion

        #region Panel Creation Method
        /// <summary>
        /// Panel Creation Entry Point
        /// </summary>
        /// <param name="uiApp">UIControlled Application</param>
        /// <param name="tabName">Tab Name</param>
        /// <returns></returns>
        internal RibbonPanel Create(UIControlledApplication uiApp, string tabName)
        {
            //Panel Name
            string panelName = "Application Tests";
            
            //Create Panel
            RibbonPanel rp = uiApp.CreateRibbonPanel(tabName, panelName);

            //Add Buttons and Controls
            AddControls(rp);

            return rp;
        }
        #endregion

        #region Controls
        private void AddControls(RibbonPanel panel)
        {

            //A TEST BUTTON LOCATION
            var testButtonData = new RevitPushButtonData()
            {
                Label = "Test\nCommand",
                Panel = panel,
                Tooltip = "A Test Command",
                CommandNamespacePath = TestCommand.GetPath(),
                IconImageName = ImageNames.TestIconShow,
                TooltipImageName = ImageNames.TestIconTooltip,
                SmallIconImageName = ImageNames.TestIconSmall,
                LongDescription = "This is a test command used for development and debugging.  If you see this command," +
                                  "please disregard and inform the developer immediately.",
                //AvailabilityClassName = AvailabilityProj.GetPath()
            };
            _ = RevitPushButton.Create(testButtonData);


        }

        #endregion


    }

}
