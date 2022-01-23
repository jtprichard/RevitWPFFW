using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.DB;

namespace PB.RevitWPFFW.core
{
    /// <summary>
    /// Keeps a copy of the current Revit Document for reference
    /// </summary>
    public class RevitDocument
    {
        #region Private Fields

        /// <summary>
        /// Current Document
        /// </summary>
        private static Document _currentDocument;

        /// <summary>
        /// List of all documents in current Revit session
        /// </summary>
        private static IList<RevitDocument> _documents;

        #endregion

        #region Properties

        /// <summary>
        /// The current Revit document
        /// </summary>
        private Document Document { get; set; }

        /// <summary>
        /// The Document Hashcode
        /// </summary>
        private int DocumentHashCode { get; }

        /// <summary>
        /// Static current document
        /// </summary>
        public static Document CurrentDocument
        {
            get { return GetCurrentDocument(); }
            set { _currentDocument = value; }
        }

        /// <summary>
        /// Static list of documents
        /// </summary>
        public static IList<RevitDocument> Documents => _documents;

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="doc"></param>
        private RevitDocument(Document doc)
        {
            //Assign document and new viewmodels
            Document = doc;
            
            //Store the hashcode for the document to retrieve it from the list later
            DocumentHashCode = doc.GetHashCode();

            //If the static list of documents is empty, create one
            if (_documents == null)
                _documents = new List<RevitDocument>();

            //Add the current document object to the static list
            _documents.Add(this);

            //Set the static document and viewmodel objects to the new RevitDocument object
            _currentDocument = doc;

            //Set the current viewmodels for the document
            SetCurrentViewModels();

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
            _currentDocument = this.Document;
        }

        /// <summary>
        /// Set the viewmodels associated with the document
        /// </summary>
        private void SetCurrentViewModels()
        {
            //Update all viewmodels here
            Page1ViewModel.SetCurrentViewModel(DocumentHashCode);
            Page1BViewModel.SetCurrentViewModel(DocumentHashCode);
            Page2ViewModel.SetCurrentViewModel(DocumentHashCode);

            //NOTE!!!!
            //Viewmodel will not update without a page refresh.
            MainPageViewModel.Refresh();
        }

        /// <summary>
        /// Returns the current Revit document
        /// </summary>
        /// <returns></returns>
        private static Document GetCurrentDocument()
        {
            if (_currentDocument == null)
                return null;

            return _currentDocument;
        }

        #endregion




    }
}
