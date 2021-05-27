using Autodesk.Revit.UI;
using RevitWPFFW.res;
using RevitWPFFW.core;

namespace RevitWPFFW.ui
{
    /// <summary>
    /// Revit push button Creation Method
    /// </summary>
    public static class RevitPushButton
    {
        public static PushButton Create(RevitPushButtonData data)
        {
            //The button name based on unique identifier
            //string btnDataName;

            var btnData = data.Create();

            //if (null == data.Name)
            //    return null;
            //else
            //    btnDataName = data.Name;

            ////Create The button
            //var btnData = new PushButtonData(btnDataName, data.Label, ApplicationAssembly.GetAssemblyLocation(), data.CommandNamespacePath);

            ////Add Tooltips, Image Data, and Availability Class Info
            //if (null != data.Tooltip)
            //    btnData.ToolTip = data.Tooltip;

            //if (null != data.LongDescription)
            //    btnData.LongDescription = data.LongDescription;

            //if (null != ResourceImage.GetIcon(data.IconImageName))
            //    btnData.LargeImage = ResourceImage.GetIcon(data.IconImageName);

            //if (null != ResourceImage.GetIcon(data.TooltipImageName))
            //    btnData.ToolTipImage = ResourceImage.GetIcon(data.TooltipImageName);

            //if (null != data.SmallIconImageName)
            //    btnData.Image = ResourceImage.GetIcon(data.IconImageName);

            //if (null != data.AvailabilityClassName)
            //    btnData.AvailabilityClassName = data.AvailabilityClassName;

            //return created button and host it on the panel provided
            return data.Panel.AddItem(btnData) as PushButton;

        }
    }
}
