using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using PB.MVVMToolkit.DialogServices;
using PB.MVVMToolkit.ViewModel;

namespace PB.RevitWPFFW.core
{
    /// <summary>
    /// View Model for WPF Main Page
    /// See warnings below regarding creating additional instances of this viewmodel
    /// </summary>
    public class MainPageViewModel: BaseViewModel
    {
        #region Private Fields
        private static MainPageViewModel _currentViewModel = null;
        private static IList<MainPageViewModel> _viewModels;

        private PageType _currentPage = PageType.Page1;
        private int _documentHashCode;

        #endregion

        #region Public Properties

        /// <summary>
        /// CurrentViewModel of Main Page View Model
        /// If no instance exists, create a new one
        /// </summary>
        public static MainPageViewModel CurrentViewModel
        {
            get
            {
                if (_currentViewModel == null)
                    _currentViewModel = new MainPageViewModel();
                return _currentViewModel;
            }
        }

        /// <summary>
        /// Stores the document hash code for times when multiple
        /// instances are required.  See warnings regarding multiple instances.
        /// </summary>
        public int DocumentHashCode
        {
            get { return _documentHashCode; }
            set { _documentHashCode = value; OnPropertyChanged("DocumentHashCode"); }
        }

        /// <summary>
        /// Stores a list of instantiated viewmodels
        /// </summary>
        public static IList<MainPageViewModel> ViewModels => _viewModels;

        /// <summary>
        /// Access to the Current Page
        /// </summary>
        public PageType CurrentPage
        {
            get { return _currentPage; }
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

        private ICommand _openDialogCustomCommand = null;

        public ICommand OpenDialogCustomCommand
        {
            get { return _openDialogCustomCommand; }
            set { _openDialogCustomCommand = value; }
        }

        #endregion

        #region Constructors
        /// <summary>
        /// Default Constructor
        /// </summary>
        public MainPageViewModel()
        {
            _openDialogCustomCommand = new RelayCommand(OnOpenDialogCustom);

            //If list of viewmodels is null, create a new list
            if (_viewModels == null)
                _viewModels = new List<MainPageViewModel>();

            //Commands must be initialized at construction
            Page1Command = new RelayCommand(Page1CommandMethod);
            Page2Command = new RelayCommand(Page2CommandMethod);
            Page3Command = new RelayCommand(Page3CommandMethod);

            //Initialize Method
            Initialize();

            //Add viewmodel to list of viewmodels
            _viewModels.Add(this);

            //Set the current viewmodel
            SetCurrentViewModel();
        }

        #endregion

        #region Private Methods

        private void OnOpenDialogCustom(object parameter)
        {
            var vm = new CustomDialogViewModel();
            vm.OkClicked += OptionOk;
            vm.CancelClicked += OptionCancel;
            if(DialogService != null)
                DialogService.ShowDialog(vm);
        }

        private void OptionOk(object sender, EventArgs e)
        {

        }

        private void OptionCancel(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Initialize the current viewmodel and other viewmodels
        /// </summary>
        private void Initialize()
        {
            //Initialize any main page properties here

        }

        /// <summary>
        /// Set the current static viewmodel to this one
        /// </summary>
        private void SetCurrentViewModel()
        {
            _currentViewModel = this;
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
        /// Refresh the viewmodel's current page
        /// </summary>
        public static void Refresh()
        {
            var tempPage = CurrentViewModel.CurrentPage;
            CurrentViewModel.CurrentPage = tempPage;
        }

        /// <summary>
        /// Allows external call to switch to Page 1
        /// </summary>
        public static void SwitchToPage1()
        {
            CurrentViewModel.CurrentPage = PageType.Page1;
        }

        /// <summary>
        /// Allows external call to switch to Page 2
        /// </summary>
        public static void SwitchToPage2()
        {
            CurrentViewModel.CurrentPage = PageType.Page2;
        }

        /// <summary>
        /// Allows external call to switch to Page 3
        /// </summary>
        public static void SwitchToPage3()
        {
            CurrentViewModel.CurrentPage = PageType.Page3;
        }

        /// <summary>
        /// Allows external call to switch to Page 4
        /// Page 4 currently set up for monitor selection
        /// </summary>
        public static void SwitchToPage4()
        {
            CurrentViewModel.CurrentPage = PageType.Page4;
        }

        /// <summary>
        /// Selection Monitoring call to move away from Page 4
        /// When no selection is made
        /// </summary>
        public static void SwitchPageOffPage4()
        {
            if(CurrentViewModel.CurrentPage == PageType.Page4)
                SwitchToPage1();
        }

        /// <summary>
        /// Sets the viewmodel to the document hash code provided.
        /// WARNING!!!!!!!
        /// Changing the static instance of the main view model requires you to
        /// create a new instance of the Main Page WPF form.  This function is not built into
        /// this class, so a method will need to be called from outside of this namespace to the
        /// UI namespace to refresh the WPF form and thus update the new viewmodel to the form.
        /// </summary>
        /// <param name="hashCode"></param>
        public static void SetCurrentViewModel(int hashCode)
        {
            if (_viewModels == null)
                _ = new MainPageViewModel();

            var retrievedViewModel = _viewModels.FirstOrDefault(x => x.DocumentHashCode == hashCode);

            if (retrievedViewModel == null)
            {
                retrievedViewModel = new MainPageViewModel();
                retrievedViewModel.DocumentHashCode = hashCode;
            }

            retrievedViewModel.SetCurrentViewModel();

        }

        #endregion


    }
}
