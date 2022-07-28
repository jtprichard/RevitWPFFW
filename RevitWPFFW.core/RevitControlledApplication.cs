using System.Reflection;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using PB.MVVMToolkit.DialogServices;

namespace PB.RevitWPFFW.core
{
    /// <summary>
    /// Keeps a copy of the current Revit Application and Add-In Information
    /// </summary>
    public class RevitControlledApplication
    {
        private static UIControlledApplication _uiapp;
        private static AddInId _seatAddInId;
        private static string _revitVersion;
        private static string _revitBuildVersion;
        private static string _addinVersion;
        private static DialogService _dialogService;

        public RevitControlledApplication(UIControlledApplication uiapp)
        {
            _uiapp = uiapp;
            _seatAddInId = uiapp.ControlledApplication.ActiveAddInId;
            _revitVersion = uiapp.ControlledApplication.VersionNumber;
            _revitBuildVersion = uiapp.ControlledApplication.VersionBuild;
        }

        /// <summary>
        /// Returns the current Revit document
        /// </summary>
        /// <returns></returns>
        public static UIControlledApplication GetCurrentApplication()
        {
            return _uiapp;
        }

        /// <summary>
        /// Get Current AddIn Id
        /// </summary>
        /// <returns>This AddIn Id</returns>
        public static AddInId GetAddInId()
        {
            return _seatAddInId;
        }

        /// <summary>
        /// Get the Revit Version Number
        /// </summary>
        /// <returns>Revit Version Number as string</returns>
        public static string GetRevitVersion()
        {
            return _revitVersion;
        }

        /// <summary>
        /// Get the Revit Build Version Number
        /// </summary>
        /// <returns>Revit Build Version Number as string</returns>
        public static string GetRevitBuildVersion()
        {
            return _revitBuildVersion;
        }

        /// <summary>
        /// Return the Addin Version Number
        /// </summary>
        /// <returns>Addin Assembly Version Number as string</returns>
        public static string GetAddinVersion()
        {
            return _addinVersion;
        }

        /// <summary>
        /// Sets the addin version from the provided assembly
        /// </summary>
        /// <param name="assembly"></param>
        public static void SetAddinVersion(Assembly assembly)
        {
            _addinVersion = assembly.GetName().Version.ToString();
        }

        /// <summary>
        /// Sets the application's Dialog Service Object
        /// </summary>
        /// <param name="dialogService"></param>
        public static void SetDialogService(DialogService dialogService)
        {
            _dialogService = dialogService;
        }

        /// <summary>
        /// Gets the application's Dialog Service Object
        /// </summary>
        /// <returns></returns>
        public static DialogService GetDialogService()
        {
            return _dialogService;
        }

    }
}
