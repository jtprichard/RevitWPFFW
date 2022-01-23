using Autodesk.Revit.UI;
using System.Collections.Generic;
using PB.RevitWPFFW.res;
using PB.RevitWPFFW.core;


namespace PB.RevitWPFFW.ui
{
    /// <summary>
    /// Revit split button methods
    /// </summary>
    public static class RevitSplitButton
    {
        /// <summary>
        /// Creates a Split Button from RevitPushButtonData Class
        /// </summary>
        /// <param name="splitButtonData">Split Button information in RevitPushButtonData Class</param>
        /// <param name="buttondata">A list of RevitPushButtonData items</param>
        /// <returns></returns>
        public static SplitButton Create(RevitPushButtonData splitButtonData, IList<RevitPushButtonData> buttondata)
        {
            //Create the Split Button
            SplitButtonData sbd = new SplitButtonData(splitButtonData.Name, splitButtonData.Label);
            SplitButton sb = splitButtonData.Panel.AddItem(sbd) as SplitButton;

            //Create pushbuttons for each of the buttons provided
            foreach (RevitPushButtonData data in buttondata)
            {
                //Create The button
                var btnData = new PushButtonData(data.Name, data.Label, ApplicationAssembly.GetAssemblyLocation(), data.CommandNamespacePath);

                //Add Tooltips, Image Data, and Availability Class Info
                if (null != data.Tooltip)
                    btnData.ToolTip = data.Tooltip;

                if (null != data.LongDescription)
                    btnData.LongDescription = data.LongDescription;

                if (null != ResourceImage.GetIcon(data.IconImageName))
                    btnData.LargeImage = ResourceImage.GetIcon(data.IconImageName);

                if (null != ResourceImage.GetIcon(data.TooltipImageName))
                    btnData.ToolTipImage = ResourceImage.GetIcon(data.TooltipImageName);

                if (null != data.SmallIconImageName)
                    btnData.Image = ResourceImage.GetIcon(data.IconImageName);

                if (null != data.AvailabilityClassName)
                    btnData.AvailabilityClassName = data.AvailabilityClassName;

                sb.AddPushButton(btnData);
            }

            //return created button and host it on the panel provided
            return sb;

        }
    }
}
