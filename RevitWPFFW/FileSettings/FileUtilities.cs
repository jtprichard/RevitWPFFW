using System.IO;
using Autodesk.Revit.ApplicationServices;

namespace PB.RevitWPFFW
{
    internal static class FileUtilities
    {
        internal static string GetFileLocationFromAddin(ControlledApplication app, string fileName)
        {
            var currentUserAddinLocation = app.CurrentUserAddinsLocation;
            var allUserAddinLocation = app.AllUsersAddinsLocation;
            var currentUserAddinDataFolder = app.CurrentUsersAddinsDataFolderPath;

            if (File.Exists(Path.Combine(currentUserAddinDataFolder, fileName)))
                return currentUserAddinDataFolder;
            if (File.Exists(Path.Combine(currentUserAddinLocation, fileName)))
                return currentUserAddinLocation;
            if (File.Exists(Path.Combine(allUserAddinLocation, fileName)))
                return allUserAddinLocation;

            return "";

        }
    }
}
