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
            //Create Button Data Object

            var btnData = data.Create();

            //return created button and host it on the panel provided
            return data.Panel.AddItem(btnData) as PushButton;

        }
    }
}
