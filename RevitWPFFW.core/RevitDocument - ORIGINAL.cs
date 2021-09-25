using Autodesk.Revit.DB;

namespace RevitWPFFW.core
{
    /// <summary>
    /// Keeps a copy of the current Revit Document
    /// </summary>
    public class RevitDocument
    {
        private static Document _document;

        public RevitDocument(Document doc)
        {
            _document = doc;
        }

        /// <summary>
        /// Returns the current Revit document
        /// </summary>
        /// <returns></returns>
        public static Document GetCurrentDocument()
        {
            return _document;
        }
    }
}
