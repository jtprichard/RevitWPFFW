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
    internal class TemplatePanel
    {
        #region Constructor
        /// <summary>
        /// Default Constructor
        /// </summary>
        internal TemplatePanel() { }
        #endregion

        #region Panel Creation Method
        /// <summary>
        /// Panel Creation Entry Point
        /// </summary>
        /// <param name="uiApp">UIControlled Application</param>
        /// <param name="tabName">Tab Name</param>
        /// <returns></returns>
        internal RibbonPanel Create(UIControlledApplication uiApp, string tabName, string helpFilePath)
        {
            //Panel Name
            string panelName = "TEMPLATE PANEL";

            //Create Default Contextual Help Object
            var contextualHelp = new RevitContextualHelpData(helpFilePath, ContextualHelpType.ChmFile);

            //Create Panel
            RibbonPanel rp = uiApp.CreateRibbonPanel(tabName, panelName);

            //Add Buttons and Controls
            AddControls(rp, contextualHelp);

            return rp;
        }
        #endregion

        #region Controls Templates Location
        private void AddControls(RibbonPanel panel, RevitContextualHelpData contextualHelp)
        {
            #region Pushbutton Template
            //Add a Pushbutton
            //Name is only required if future reference is needed
            //Guid is generated if no name provided
            var buttonData = new RevitPushButtonData("Show_Dockable_Pane")
            {
                Label = "Show\nPane",
                Panel = panel,
                Tooltip = "Tooltip Sample",
                CommandNamespacePath = ShowDockablePaneCommand.GetPath(),
                IconImageName = ImageNames.BlankButton,
                TooltipImageName = ImageNames.BlankButton,
                SmallIconImageName = ImageNames.BlankButtonSmall,
                LongDescription = "This is a long description for the ToolTip",
                AvailabilityClassName = AvailabilityProj.GetPath(),
                ContextualHelpData = new RevitContextualHelpData(contextualHelp, "Introduction")
            };
            var sampleButton = RevitPushButton.Create(buttonData);

            //For Toggle Button, store button in view model
            RevitRibbonViewModel.Instance.ShowPagePushButton = sampleButton;

            #endregion

            #region SplitButton Template

            IList<RevitPushButtonData> splitButtons = new List<RevitPushButtonData>();
            
            //Add Split Buttons to List
            splitButtons.Add(new RevitPushButtonData()
            {
                Label = "Split\nButton 1",
                Panel = panel,
                Tooltip = "Tooltip Sample",
                CommandNamespacePath = SampleRevitCommand.GetPath(),
                IconImageName = ImageNames.BlankButton,
                TooltipImageName = ImageNames.BlankButton,
                SmallIconImageName = ImageNames.BlankButtonSmall,
                LongDescription = "This is a long description for the ToolTip",
                AvailabilityClassName = AvailabilityProj.GetPath()
            });

            splitButtons.Add(new RevitPushButtonData()
            {
                Label = "Split\nButton 2",
                Panel = panel,
                Tooltip = "Tooltip Sample",
                CommandNamespacePath = SampleRevitCommand.GetPath(),
                IconImageName = ImageNames.BlankButton,
                TooltipImageName = ImageNames.BlankButton,
                SmallIconImageName = ImageNames.BlankButtonSmall,
                LongDescription = "This is a long description for the ToolTip",
                AvailabilityClassName = AvailabilityProj.GetPath()
            });

            splitButtons.Add(new RevitPushButtonData()
            {
                Label = "Split\nButton 3",
                Panel = panel,
                Tooltip = "Tooltip Sample",
                CommandNamespacePath = SampleRevitCommand.GetPath(),
                IconImageName = ImageNames.BlankButton,
                TooltipImageName = ImageNames.BlankButton,
                SmallIconImageName = ImageNames.BlankButtonSmall,
                LongDescription = "This is a long description for the ToolTip",
                AvailabilityClassName = AvailabilityProj.GetPath()
            });

            //Create Main Split Button
            RevitPushButtonData splitButton = new RevitPushButtonData()
            {
                Label = "Split\nButton",
                Panel = panel,
                ContextualHelpData = new RevitContextualHelpData(contextualHelp, "Introduction")
            };

            RevitSplitButton.Create(splitButton, splitButtons);

            #endregion

            #region TextBox Template
            //Create Textbox Data and TextBox
            TextBoxData textBoxData = new TextBoxData("TextBoxName");
            TextBox textBox = panel.AddItem(textBoxData) as TextBox;

            //Add Textbox Properties
            textBox.ToolTip = "Tooltip Sample";
            textBox.LongDescription = "This is a long description for the ToolTip";
            textBox.Image = ResourceImage.GetIcon(ImageNames.CheckMarkSmall);
            textBox.ToolTipImage = ResourceImage.GetIcon(ImageNames.BlankButtonSmall);
            textBox.PromptText = "Prompt";
            textBox.Width = 150;
            textBox.ShowImageAsButton = true;
            //textBox.SelectTextOnFocus = true;
            textBox.SetContextualHelp(new RevitContextualHelpData(contextualHelp,"Introduction").ContextualHelp);

            //Event Handler for Pressing Enter
            textBox.EnterPressed += new EventHandler<TextBoxEnterPressedEventArgs>(ProcessTextBox);

            #endregion

            #region ComboBox Template
            //Create ComboBox Data and ComboBox
            ComboBoxData comboData = new ComboBoxData("ComboBoxName");
            ComboBox comboBox = panel.AddItem(comboData) as ComboBox;

            //Add ComboBox Properties
            comboBox.ItemText = "Combo Box";
            comboBox.ToolTip = "Tooltip Sample";
            comboBox.LongDescription = "This is a long description for the ToolTip";
            comboBox.Image = ResourceImage.GetIcon(ImageNames.BlankButtonSmall);
            comboBox.SetContextualHelp(new RevitContextualHelpData(contextualHelp, "Introduction").ContextualHelp);

            //Create a list of ComboBox Members
            var comboMemberData = new List<ComboBoxMemberData>();

            //Create ComboBox Members
            comboMemberData.Add(new ComboBoxMemberData("Select1", "Selection 1")
            {
                Image = ResourceImage.GetIcon(ImageNames.BlankButtonSmall),
                GroupName = "Group 1"
            });

            comboMemberData.Add(new ComboBoxMemberData("Select2", "Selection 2")
            {
                Image = ResourceImage.GetIcon(ImageNames.BlankButtonSmall),
                GroupName = "Group 1"
            });

            comboMemberData.Add(new ComboBoxMemberData("Select3", "Selection 3")
            {
                Image = ResourceImage.GetIcon(ImageNames.BlankButtonSmall),
                GroupName = "Group 1"
            });

            comboMemberData.Add(new ComboBoxMemberData("Select4", "Selection 4")
            {
                Image = ResourceImage.GetIcon(ImageNames.BlankButtonSmall),
                GroupName = "Group 1"
            });

            comboMemberData.Add(new ComboBoxMemberData("SelectA", "Selection A")
            {
                Image = ResourceImage.GetIcon(ImageNames.BlankButtonSmall),
                GroupName = "Group 2"
            });

            comboMemberData.Add(new ComboBoxMemberData("SelectB", "Selection B")
            {
                Image = ResourceImage.GetIcon(ImageNames.BlankButtonSmall),
                GroupName = "Group 2"
            });

            //Add members to Combobox
            foreach(ComboBoxMemberData cbd in comboMemberData)
            {
                comboBox.AddItem(cbd);
            }

            //Event handler for changed value
            comboBox.CurrentChanged += ComboBox_CurrentChanged;

            //Store default value in ViewModel
            RevitRibbonViewModel.Instance.RibbonComboBox = comboBox.Current.ItemText;

            #endregion

            #region Separator

            panel.AddSeparator();

            #endregion

            #region Stacked Panel Template

            //Create the Button Data
            //Uses RevitButtonData Helper Class
            var stackRvtBtnData1 = new RevitPushButtonData()
            {
                Label = "Stack\nButton 1",
                Panel = panel,
                Tooltip = "Tooltip Sample",
                CommandNamespacePath = SampleRevitCommand.GetPath(),
                IconImageName = ImageNames.BlankButtonSmall,
                TooltipImageName = ImageNames.BlankButton,
                SmallIconImageName = ImageNames.BlankButtonSmall,
                LongDescription = "This is a long description for the ToolTip",
                AvailabilityClassName = AvailabilityProj.GetPath(),
                ContextualHelpData = new RevitContextualHelpData(contextualHelp, "Introduction")
            };
            var stackBtnData1 = stackRvtBtnData1.Create();

            var stackRvtBtnData2 = new RevitPushButtonData()
            {
                Label = "Stack\nButton 2",
                Panel = panel,
                Tooltip = "Tooltip Sample",
                CommandNamespacePath = SampleRevitCommand.GetPath(),
                IconImageName = ImageNames.BlankButtonSmall,
                TooltipImageName = ImageNames.BlankButton,
                SmallIconImageName = ImageNames.BlankButtonSmall,
                LongDescription = "This is a long description for the ToolTip",
                AvailabilityClassName = AvailabilityProj.GetPath(),
                ContextualHelpData = new RevitContextualHelpData(contextualHelp, "Introduction")
            };
            var stackBtnData2 = stackRvtBtnData2.Create();

            var stackRvtBtnData3 = new RevitPushButtonData()
            {
                Label = "Stack\nButton 3",
                Panel = panel,
                Tooltip = "Tooltip Sample",
                CommandNamespacePath = SampleRevitCommand.GetPath(),
                IconImageName = ImageNames.BlankButtonSmall,
                TooltipImageName = ImageNames.BlankButton,
                SmallIconImageName = ImageNames.BlankButtonSmall,
                LongDescription = "This is a long description for the ToolTip",
                AvailabilityClassName = AvailabilityProj.GetPath(),
                ContextualHelpData = new RevitContextualHelpData(contextualHelp, "Introduction")
            };
            var stackBtnData3 = stackRvtBtnData3.Create();

            //Create Stacked Items from Data
            var stackedItems = panel.AddStackedItems(stackBtnData1, stackBtnData2, stackBtnData3);

            //Create Buttons from Button Data
            if(stackedItems.Count() > 1)
            {
                PushButton stackBtn1 = stackedItems[0] as PushButton;
                PushButton stackBtn2 = stackedItems[1] as PushButton;
                PushButton stackBtn3 = stackedItems[2] as PushButton;
            }

            #endregion

            #region Custom Dialog Call Template

            //Add a Pushbutton to call a custom dialog
            //Name is only required if future reference is needed
            //Guid is generated if no name provided
            var dialogButtonData = new RevitPushButtonData("Open_Custom_Dialog")
            {
                Label = "Custom\nDialog",
                Panel = panel,
                Tooltip = "Tooltip Sample",
                CommandNamespacePath = OpenDialogCommand.GetPath(),
                IconImageName = ImageNames.BlankButton,
                TooltipImageName = ImageNames.BlankButton,
                SmallIconImageName = ImageNames.BlankButtonSmall,
                LongDescription = "This is a long description for the ToolTip",
                AvailabilityClassName = AvailabilityProj.GetPath(),
                ContextualHelpData = new RevitContextualHelpData(contextualHelp, "Introduction")
            };
            var customDialogButton = RevitPushButton.Create(dialogButtonData);

            #endregion

            #region More Customization Options

            //There is good information here:
            //https://thebuildingcoder.typepad.com/blog/2011/02/pimp-my-autocad-or-revit-ribbon.html
            //That allows direct access to WPF data in Ribbon panel
            //For much more customization

            #endregion

        }
        #endregion

        #region Internal Event Handlers
        /// <summary>
        /// Process the text input into the textbox and store it in the Core View Model Class
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void ProcessTextBox(object sender, TextBoxEnterPressedEventArgs args)
        {
            //Get Textbox information
            TextBox textBox = sender as TextBox;
            string tbData = textBox.Value as string;

            //Store string in ViewModel
            RevitRibbonViewModel.Instance.RibbonTextBox = tbData;
        }

        /// <summary>
        /// Process the text change when a combobox changes value and store it in the Core View Model Class
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_CurrentChanged(object sender, ComboBoxCurrentChangedEventArgs e)
        {
            var value = e.NewValue.ItemText;

            //Store the value in ViewModel
            RevitRibbonViewModel.Instance.RibbonComboBox = value;
        }

        #endregion


    }

}
