using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace RevitWPFFW.core
{
    /// <summary>
    /// Keeps a copy of the current Revit Document
    /// </summary>
    public class RevitControlledApplication
    {
        private static UIControlledApplication _uiapp;

        public RevitControlledApplication(UIControlledApplication uiapp)
        {
            _uiapp = uiapp;
        }

        /// <summary>
        /// Returns the current Revit document
        /// </summary>
        /// <returns></returns>
        public static UIControlledApplication GetCurrentApplication()
        {
            return _uiapp;
        }
    }
}
