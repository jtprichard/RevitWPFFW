using System.Windows.Input;

namespace RevitWPFFW.core
{
    /// <summary>
    /// View Model for WPF Main Page
    /// </summary>
    public class MainPageViewModel:BaseViewModel
    {
        #region Private Fields
        private static MainPageViewModel _instance = null;
        private static bool _docInitialized = false;

        private PageType _currentPage = PageType.Page1;

        #endregion

        #region Public Properties
        /// <summary>
        /// Instance of Main Page View Model
        /// If no instance exists, create a new one
        /// If the VM has not been initialized and the document is opened, initialize it
        /// </summary>
        public static MainPageViewModel Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new MainPageViewModel();
                else if (!_docInitialized && RevitDocument.GetCurrentDocument() != null)
                    _instance.InitializeViewModel();
                return _instance;
            }
        }

        /// <summary>
        /// Access to the Current Page
        /// </summary>
        public PageType CurrentPage
        {
            get
            {
                return _currentPage;
            }
            set
            {
                _currentPage = value;
                OnPropertyChanged("CurrentPage");
            }
        }
        public ICommand Page1Command { get; set; }
        public ICommand Page2Command { get; set; }
        public ICommand Page3Command { get; set; }
        public ICommand Page4Command { get; set; }

        #endregion

        #region Constructors
        /// <summary>
        /// Default Constructor
        /// </summary>
        public MainPageViewModel()
        {
            //Commands must be initialized at construction
            Page1Command = new RelayCommand(Page1CommandMethod);
            Page2Command = new RelayCommand(Page2CommandMethod);
            Page3Command = new RelayCommand(Page3CommandMethod);
        }
        #endregion

        #region Private Methods

        private void InitializeViewModel()
        {
            //Initialize any main page properties here

            _docInitialized = true;
        }

        /// <summary>
        /// Changes Current Page to Page 1
        /// </summary>
        /// <param name="parameter"></param>
        private void Page1CommandMethod(object parameter)
        {
            CurrentPage = PageType.Page1;

            //Do additional changes here
        }

        /// <summary>
        /// Changes Current Page to Page 2
        /// </summary>
        /// <param name="parameter"></param>
        private void Page2CommandMethod(object parameter)
        {
            CurrentPage = PageType.Page2;

            //Do additional changes here

        }

        /// <summary>
        /// Changes Current Page to Page 3
        /// </summary>
        /// <param name="parameter"></param>
        private void Page3CommandMethod(object parameter)
        {
            CurrentPage = PageType.Page3;

            //Do additional changes here

        }

        #endregion

        #region Public Methods
        /// <summary>
        /// Initialize Properties in View Models to Default Values
        /// </summary>
        public static void Initialize()
        {
            if (!_docInitialized && _instance != null)
            {
                //Initialize This View Model
                _instance.InitializeViewModel();

                //Initialize Other View Models
                Page1ViewModel.Initialize();
            }

        }

        /// <summary>
        /// Allows external call to switch to Page 1
        /// </summary>
        public static void SwitchToPage1()
        {
            _instance.CurrentPage = PageType.Page1;
        }

        /// <summary>
        /// Allows external call to switch to Page 2
        /// </summary>
        public static void SwitchToPage2()
        {
            _instance.CurrentPage = PageType.Page2;
        }

        /// <summary>
        /// Allows external call to switch to Page 3
        /// </summary>
        public static void SwitchToPage3()
        {
            _instance.CurrentPage = PageType.Page3;
        }

        /// <summary>
        /// Allows external call to switch to Page 4
        /// Page 4 currently set up for monitor selection
        /// </summary>
        public static void SwitchToPage4()
        {
            _instance.CurrentPage = PageType.Page4;
        }

        /// <summary>
        /// Selection Monitoring call to move away from Page 4
        /// When no selection is made
        /// </summary>
        public static void SwitchPageOffPage4()
        {
            if (_instance.CurrentPage == PageType.Page4)
                SwitchToPage1();
        }

        #endregion


    }
}
