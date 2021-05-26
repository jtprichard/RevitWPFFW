using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using RevitWPFFW.core;

namespace RevitWPFFW.ui
{
    /// <summary>
    /// Static class to add Revit Ribbon Panel
    /// </summary>
    internal static class TemplatePanel
    {
        /// <summary>
        /// Panel Creation Entry Point
        /// </summary>
        /// <param name="uiApp">UIControlled Application</param>
        /// <param name="tabName">Tab Name</param>
        /// <returns></returns>
        internal static RibbonPanel Create(UIControlledApplication uiApp, string tabName)
        {
            //Panel Name
            string panelName = "TemplatePanel";
            
            //Create Panel
            RibbonPanel rp = uiApp.CreateRibbonPanel(tabName, panelName);

            //Add Buttons and Controls
            AddControls(rp);

            return rp;

        }

        private static void AddControls(RibbonPanel panel)
        {
            #region Pushbutton Template
            //Add a Pushbutton
            //Name is only required if future reference is needed
            //Guid is generated if no name provided
            var buttonData = new RevitPushButtonData("Sample_Button")
            {
                Label = "Sample\nButton",
                Panel = panel,
                Tooltip = "Tooltip Sample",
                CommandNamespacePath = SampleRevitCommand.GetPath(),
                IconImageName = "blank_button.png",
                TooltipImageName = "blank_button.png",
                SmallIconImageName = "blank_button_16x16.png",
                LongDescription = "This is a long description for the ToolTip",
                AvailabilityClassName = AvailabilityProj.GetPath()
            };
            var sampleButton = RevitPushButton.Create(buttonData);

            #endregion

            #region SplitButton Template

            IList<RevitPushButtonData> splitButtons = new List<RevitPushButtonData>();

            //Add a Split Buttons to List
            splitButtons.Add(new RevitPushButtonData()
            {
                Label = "Split\nButton 1",
                Panel = panel,
                Tooltip = "Tooltip Sample",
                CommandNamespacePath = SampleRevitCommand.GetPath(),
                IconImageName = "blank_button.png",
                TooltipImageName = "blank_button.png",
                SmallIconImageName = "blank_button_16x16.png",
                LongDescription = "This is a long description for the ToolTip",
                AvailabilityClassName = AvailabilityProj.GetPath()
            });

            splitButtons.Add(new RevitPushButtonData()
            {
                Label = "Split\nButton 2",
                Panel = panel,
                Tooltip = "Tooltip Sample",
                CommandNamespacePath = SampleRevitCommand.GetPath(),
                IconImageName = "blank_button.png",
                TooltipImageName = "blank_button.png",
                SmallIconImageName = "blank_button_16x16.png",
                LongDescription = "This is a long description for the ToolTip",
                AvailabilityClassName = AvailabilityProj.GetPath()
            });

            splitButtons.Add(new RevitPushButtonData()
            {
                Label = "Split\nButton 3",
                Panel = panel,
                Tooltip = "Tooltip Sample",
                CommandNamespacePath = SampleRevitCommand.GetPath(),
                IconImageName = "blank_button.png",
                TooltipImageName = "blank_button.png",
                SmallIconImageName = "blank_button_16x16.png",
                LongDescription = "This is a long description for the ToolTip",
                AvailabilityClassName = AvailabilityProj.GetPath()
            });

            RevitSplitButton.Create(splitButtons[0], splitButtons);

            #endregion


        }
    }

}
