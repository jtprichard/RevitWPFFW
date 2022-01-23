using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using PB.MVVMToolkit.ViewModel;

namespace PB.RevitWPFFW.core
{
    /// <summary>
    /// View Model for WPF Page
    /// </summary>
    public class Page2ViewModel : BaseViewModel
    {
        #region Private Fields
        private static Page2ViewModel _currentViewModel = null;
        private static bool _docInitialized = false;
        private static IList<Page2ViewModel> _viewModels;

        private int _documentHashCode;

        //FOR TESTING
        private string _documentData;

        #endregion

        #region Public Properties
        /// <summary>
        /// CurrentViewModel of Page View Model
        /// If no instance exists, create a new one
        /// </summary>
        public static Page2ViewModel CurrentViewModel
        {
            get
            {
                if (_currentViewModel == null)
                    _currentViewModel = new Page2ViewModel(0);
                return _currentViewModel;
            }
        }

        //FOR TESTING
        public string DocumentData
        {
            get { return _documentData; }
            set { _documentData = value; OnPropertyChanged("DocumentData"); }
        }

        /// <summary>
        /// Document hash code for current viewmodel
        /// </summary>
        public int DocumentHashCode
        {
            get { return _documentHashCode; }
            set { _documentHashCode = value; OnPropertyChanged("DocumentHashCode"); }
        }

        /// <summary>
        /// Static list of viewmodels
        /// </summary>
        public static IList<Page2ViewModel> ViewModels => _viewModels;
        

        /// <summary>
        /// Command to trigger Revit Transaction Command
        /// </summary>
        public ICommand TransactionCommand { get; set; }

        #endregion

        #region Constructor
        /// <summary>
        /// Default Constructor
        /// </summary>
        private Page2ViewModel(int documentHashCode)
        {
            DocumentData = "Document Hashcode: " + documentHashCode.ToString();
            DocumentHashCode = documentHashCode;

            //Initialize viewmodel
            Initialize();

            //Commands must be initialized at construction
            TransactionCommand = new RelayCommand(TransactionCommandMethod);

            //If list of viewmodels is null, create a new list
            if (_viewModels == null)
                _viewModels = new List<Page2ViewModel>();

            //Add viewmodel to list of viewmodels
            _viewModels.Add(this);

        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Test and Initialize Page ViewModel
        /// </summary>
        private void Initialize()
        {
            //Test for document initialization here.
            //Required if viewmodel data is coming from the Revit document
            if (DocumentHashCode != 0)
                InitializeViewModel();
        }

        /// <summary>
        /// Initialize the View Model Properties
        /// </summary>
        private void InitializeViewModel()
        {
            //Inititalize and Populate Properties Here

            _docInitialized = true;
        }

        /// <summary>
        /// Sets the current static viewmodel to this viewmodel
        /// </summary>
        private void SetCurrentViewModel()
        {
            _currentViewModel = this;
        }

        /// <summary>
        /// Calls a transaction command method
        /// </summary>
        /// <param name="parameter"></param>
        private void TransactionCommandMethod(object parameter)
        {
            //Sample call to a Transaction Command Method
            //Commands must be raised through the Project Event Wrapper
            //The GetMethod method for each command ensures the string matches the method name
            ProjectEventWrapper.Command.Raise(new TransactionCommand().GetMethod());

        }

        #endregion

        #region Public Methods
        /// <summary>
        /// Sets the current static viewmodel to the viewmodel associated with the document hashcode provided
        /// </summary>
        /// <param name="hashCode">Document hashcode as integer</param>
        public static void SetCurrentViewModel(int hashCode)
        {
            if (_viewModels == null)
                _ = new Page2ViewModel(-1);

            var retrievedViewModel = _viewModels.FirstOrDefault(x => x.DocumentHashCode == hashCode);

            if (retrievedViewModel == null)
                retrievedViewModel = new Page2ViewModel(hashCode);

            retrievedViewModel.SetCurrentViewModel();
        }

        #endregion

    }
}
