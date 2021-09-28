using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.DB;

namespace RevitWPFFW.core
{
    /// <summary>
    /// Keeps a copy of the current Revit Document and DocumentViewModels for reference
    /// </summary>
    public class RevitDocument
    {
        #region Private Fields

        /// <summary>
        /// Current Document
        /// </summary>
        private static Document _currentDocument;
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
        private Document Document { get; set; }
        /// <summary>
        /// The current ViewModel
        /// </summary>
        private ViewModels DocumentViewModels { get; set; }
        /// <summary>
        /// The Document Hashcode
        /// </summary>
        private int DocumentHashCode { get; }

        public static Document CurrentDocument
        {
            get { return GetCurrentDocument(); }
            set { _currentDocument = value; }
        }
        public static ViewModels CurrentViewModels
        {
            get { return GetCurrentViewModels(); }
            set { _currentViewModels = value; }
        }

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

            DocumentViewModels = new ViewModels("RevitDocument Constructor", DocumentHashCode.ToString());
            //DocumentViewModels.SetMainPageViewModel(new MainPageViewModel("From Document Creation"));

            //If the static list of documents is empty, create one
            if (_documents == null)
                _documents = new List<RevitDocument>();

            //Add the current document object to the static list
            _documents.Add(this);

            //Set the static document and viewmodel objects to the new RevitDocument object
            _currentDocument = doc;
            CurrentViewModels = DocumentViewModels;
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
        /// Set the static instance of the Viewmodels
        /// </summary>
        private void SetCurrentViewModels()
        {
            CurrentViewModels = this.DocumentViewModels;
            DocumentViewModels.SetCurrentViewModels(CurrentViewModels);


            //NOTE!!!!
            //Viewmodel will not update without a page refresh.

            //Testing for option 2
            Page2ViewModel.SetCurrentViewModel(DocumentHashCode);

            

            //DocumentViewModels.MainPageViewModel.Refresh();
            //ViewModels.MainPageViewModel.SwitchToPage4();
            //ViewModels.MainPageViewModel.SwitchToPage1();
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

        /// <summary>
        /// Returns the current DocumentViewModels objects
        /// </summary>
        /// <returns></returns>
        private static ViewModels GetCurrentViewModels()
        {
            if (_currentViewModels == null)
                _currentViewModels = new ViewModels("RevitDocument GetCurrentViewModels", "None");
            
            return _currentViewModels;
        }

        #endregion




    }
}
