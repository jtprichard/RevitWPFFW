using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace RevitWPFFW.core
{
    public class Page2ViewModel : BaseViewModel
    {
        #region Private Fields
        private static Page2ViewModel _currentViewModel = null;
        private static bool _docInitialized = false;

        //FOR TESTING
        private string _documentData;
        private int _documentHashCode;
        private static IList<Page2ViewModel> _viewModels;


        #endregion

        #region Public Properties
        /// <summary>
        /// CurrentViewModel of Page View Model
        /// If no instance exists, create a new one
        /// If the VM has not been initialized and the document is opened, initialize it
        /// </summary>
        public static Page2ViewModel CurrentViewModel
        {
            get
            {
                if (_currentViewModel == null)
                    _currentViewModel = new Page2ViewModel(-2);
                return _currentViewModel;
            }
        }

        //FOR TESTING
        public string DocumentData
        {
            get { return _documentData; }
            set { _documentData = value; OnPropertyChanged("DocumentData"); }
        }

        public int DocumentHashCode
        {
            get { return _documentHashCode; }
            set { _documentHashCode = value; OnPropertyChanged("DocumentHashCode"); }
        }

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
        public Page2ViewModel(int documentHashCode)
        {
            DocumentData = documentHashCode.ToString();
            DocumentHashCode = documentHashCode;

            //Commands must be initialized at construction
            TransactionCommand = new RelayCommand(TransactionCommandMethod);

            if (_viewModels == null)
                _viewModels = new List<Page2ViewModel>();

            _viewModels.Add(this);

        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Initialize the View Model Properties
        /// </summary>
        private void InitializeViewModel()
        {
            //Inititalize and Populate Properties Here

            _docInitialized = true;
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

        private void SetCurrentViewModel()
        {
            _currentViewModel = this;
        }


        #endregion

        #region Public Methods
        /// <summary>
        /// Public Method to Initialize Page ViewModel
        /// </summary>
        internal static void Initialize()
        {
            if (!_docInitialized && _currentViewModel != null)
            {
                _currentViewModel.InitializeViewModel();
                _currentViewModel.OnPropertyChanged("");

            }
        }

        public static void SetCurrentViewModel(int hashCode)
        {
            if (_viewModels == null)
                _ = new Page2ViewModel(-1);

            var retrievedViewModel = _viewModels.FirstOrDefault(x => x.DocumentHashCode == hashCode);

            if (retrievedViewModel == null)
                retrievedViewModel = new Page2ViewModel(hashCode);

            retrievedViewModel.SetCurrentViewModel();


        }

        public static void Refresh()
        {
            //_currentViewModel.OnPropertyChanged("DocumentData");
            _currentViewModel.DocumentData = "Refreshed";
        }

        #endregion

    }
}
