using System.Windows.Input;

namespace RevitWPFFW.core
{
    /// <summary>
    /// View Model for WPF Main Page
    /// </summary>
    public class MainPageViewModel:BaseViewModel
    {
        #region Private Fields
        private static MainPageViewModel _currentVM;
        private PageType _currentPage = PageType.Page1;

        #endregion

        #region Public Properties
        public static MainPageViewModel CurrentVM
        {
            get { return _currentVM; }
        }
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
            Page1Command = new RelayCommand(Page1CommandMethod);
            Page2Command = new RelayCommand(Page2CommandMethod);
            Page3Command = new RelayCommand(Page3CommandMethod);
            _currentVM = this;
        }
        #endregion

        #region Private Methods
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
        /// Allows external call to switch to Page 1
        /// </summary>
        public static void SwitchToPage1()
        {
            _currentVM.CurrentPage = PageType.Page1;
        }

        /// <summary>
        /// Allows external call to switch to Page 2
        /// </summary>
        public static void SwitchToPage2()
        {
            _currentVM.CurrentPage = PageType.Page2;
        }

        /// <summary>
        /// Allows external call to switch to Page 3
        /// </summary>
        public static void SwitchToPage3()
        {
            _currentVM.CurrentPage = PageType.Page3;
        }

        /// <summary>
        /// Allows external call to switch to Page 4
        /// Page 4 currently set up for monitor selection
        /// </summary>
        public static void SwitchToPage4()
        {
            _currentVM.CurrentPage = PageType.Page4;
        }

        /// <summary>
        /// Selection Monitoring call to move away from Page 4
        /// When no selection is made
        /// </summary>
        public static void SwitchPageOffPage4()
        {
            if (_currentVM.CurrentPage == PageType.Page4)
                SwitchToPage1();
        }

        #endregion


    }
}
