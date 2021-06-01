using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace RevitWPFFW.core
{
    public class Page2ViewModel : BaseViewModel
    {
        #region Private Fields
        private static Page2ViewModel _instance = null;
        private static bool _docInitialized = false;
        

        #endregion

        #region Public Properties
        /// <summary>
        /// Instance of Page View Model
        /// If no instance exists, create a new one
        /// If the VM has not been initialized and the document is opened, initialize it
        /// </summary>
        public static Page2ViewModel Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Page2ViewModel();
                else if (!_docInitialized && RevitDocument.GetCurrentDocument() != null)
                    _instance.InitializeViewModel();
                return _instance;
            }
        }

        /// <summary>
        /// Command to trigger Revit Transaction Command
        /// </summary>
        public ICommand TransactionCommand { get; set; }


        #endregion

        #region Constructor
        /// <summary>
        /// Default Constructor
        /// </summary>
        private Page2ViewModel()
        {
            //Commands must be initialized at construction
            TransactionCommand = new RelayCommand(TransactionCommandMethod);

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


        #endregion

        #region Public Methods
        /// <summary>
        /// Public Method to Initialize Page ViewModel
        /// </summary>
        internal static void Initialize()
        {
            if (!_docInitialized && _instance != null)
            {
                _instance.InitializeViewModel();

            }
        }

        #endregion

    }
}
