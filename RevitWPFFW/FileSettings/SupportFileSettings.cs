using System.IO;
using Autodesk.Revit.ApplicationServices;

namespace PB.RevitWPFFW
{
    internal static class SupportFileSettings
    {
        private const string _helpFileName = "Help Template.chm";

        /// <summary>
        /// Help File Name
        /// </summary>
        internal static string HelpFileName => _helpFileName;
        /// <summary>
        /// Help File Path - to be set at startup
        /// </summary>
        internal static string HelpFilePath { get; set; }
        /// <summary>
        /// Returns the full file path
        /// </summary>
        internal static string HelpFullFileName => ReturnFullFilePath(HelpFilePath, HelpFileName);


        internal static string GetHelpFilePath(ControlledApplication app)
        {
            HelpFilePath = FileUtilities.GetFileLocationFromAddin(app, SupportFileSettings.HelpFileName);
            if(HelpFilePath != "")
                return HelpFullFileName;
            return "";
        }

        /// <summary>
        /// Returns a full file path based on path name and file name
        /// </summary>
        /// <param name="path">Path as string</param>
        /// <param name="fileName">File name as string</param>
        /// <returns></returns>
        private static string ReturnFullFilePath(string path, string fileName)
        {
            return Path.Combine(path, fileName);
        }



    }
}
