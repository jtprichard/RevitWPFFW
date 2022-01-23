using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace PB.RevitWPFFW.core
{
    /// <summary>
    /// Availability Class to Monitor "Dummy" Button 
    /// Used to trigger changes on seletion
    /// </summary>
    public class MonitorSelectionEnabler : IExternalCommandAvailability
    {
        /// <summary>
        /// Availability Command Method
        /// Intent is to trigger an event rather than make it available
        /// </summary>
        /// <param name="uiApp"></param>
        /// <param name="selectedCategories"></param>
        /// <returns>Always returns false</returns>
        public bool IsCommandAvailable(UIApplication uiApp, CategorySet selectedCategories)
        {
            var uidoc = uiApp.ActiveUIDocument;

            //if No Document
            if (uidoc == null)
                return false;

            //Raise the SelectionChangeEvent
            List<ElementId> elementIds = uidoc.Selection.GetElementIds().OrderBy(elementId => elementId.IntegerValue).ToList();

            //Perform Tests on Selection Elements
            if (elementIds.Count() > 0)
            {
                MainPageViewModel.SwitchToPage4();
            }

            else
            {
                MainPageViewModel.SwitchPageOffPage4();
            }

            return false;
        }

        /// <summary>
        /// Provide constructed namespace path
        /// </summary>
        /// <returns></returns>
        public static string GetPath()
        {
            //return constructed namespace path
            return typeof(MonitorSelectionEnabler).FullName;
        }
    }
}
