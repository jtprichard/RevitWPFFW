using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.DB;

namespace RevitWPFFW.core
{
    /// <summary>
    /// Keeps a copy of the current Revit Document and ViewModels for reference
    /// </summary>
    public class RevitDocument
    {
        #region Private Fields

        /// <summary>
        /// Current Document
        /// </summary>
        private static Document _document;
        /// <summary>
        /// Current set of viewmodels
        /// </summary>
        private static ViewModels _currentViewModels;
        /// <summary>
        /// List of all documents in current Revit session
        /// </summary>
        private static IList<RevitDocument> _documents;

        #endregion

        #region Properties

        /// <summary>
        /// The current Revit document
        /// </summary>
        private Document CurrentDocument { get; set; }
        /// <summary>
        /// The current ViewModel
        /// </summary>
        private ViewModels CurrentViewModels { get; set; }
        /// <summary>
        /// The Document Hashcode
        /// </summary>
        private int DocumentHashCode { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="doc"></param>
        private RevitDocument(Document doc)
        {
            //Assign document and new viewmodels
            CurrentDocument = doc;
            CurrentViewModels = new ViewModels();

            //Store the hashcode for the document to retrieve it from the list later
            DocumentHashCode = doc.GetHashCode();

            //If the static list of documents is empty, create one
            if (_documents == null)
                _documents = new List<RevitDocument>();

            //Add the current document object to the static list
            _documents.Add(this);

            //Set the static document and viewmodel objects to the new RevitDocument object
            _document = doc;
            _currentViewModels = CurrentViewModels;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Sets the static instances of the document and viewmodels based on the provided document
        /// </summary>
        /// <param name="doc">Revit Document</param>
        public static void SetCurrentDocument(Document doc)
        {
            var hashCode = doc.GetHashCode();
            if (_documents == null)
                _ = new RevitDocument(doc);

            var retrievedDoc = _documents.FirstOrDefault(x => x.DocumentHashCode == hashCode);

            if (retrievedDoc == null)
                retrievedDoc = new RevitDocument(doc);

            retrievedDoc.SetCurrentDocument();
            retrievedDoc.SetCurrentViewModels();

        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Set the static instance of the Document
        /// </summary>
        private void SetCurrentDocument()
        {
            _document = this.CurrentDocument;
        }

        /// <summary>
        /// Set the static instance of the Viewmodels
        /// </summary>
        private void SetCurrentViewModels()
        {
            _currentViewModels = this.CurrentViewModels;
        }

        /// <summary>
        /// Returns the current Revit document
        /// </summary>
        /// <returns></returns>
        public static Document GetCurrentDocument()
        {
            if (_document == null)
                return null;

            return _document;
        }

        /// <summary>
        /// Returns teh current ViewModels objects
        /// </summary>
        /// <returns></returns>
        public static ViewModels GetCurrentViewModels()
        {
            if (_currentViewModels == null)
                _currentViewModels = new ViewModels();
            
            return _currentViewModels;
        }

        #endregion




    }
}
