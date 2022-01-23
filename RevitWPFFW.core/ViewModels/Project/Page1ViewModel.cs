using System;
using System.Windows;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using PB.MVVMToolkit.ViewModel;
using System.Windows.Input;
using PB.MVVMToolkit.DialogServices;

namespace PB.RevitWPFFW.core
{
    public class Page1ViewModel : BaseViewModel
    {
        #region Private Fields
        private static Page1ViewModel _currentViewModel = null;
        private static bool _docInitialized = false;
        private static IList<Page1ViewModel> _viewModels;

        private int _documentHashCode;

        //Sample control fields
        private string _textbox1;
        private string _textbox2;
        private Combo1Data _selectedCombo1;
        
        //FOR TESTING
        private string _documentData;

        #endregion

        #region Public Properties
        /// <summary>
        /// CurrentViewModel of Page View Model
        /// If no instance exists, create a new one
        /// </summary>
        public static Page1ViewModel CurrentViewModel
        {
            get
            {
                if (_currentViewModel == null)
                    _currentViewModel = new Page1ViewModel(0);
                return _currentViewModel;
            }
        }


        private ICommand _openDialogCustomCommand = null;

        public ICommand OpenDialogCustomCommand
        {
            get { return _openDialogCustomCommand; }
            set { _openDialogCustomCommand = value; }
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
        public static IList<Page1ViewModel> ViewModels => _viewModels;

        /// <summary>
        /// Property for Page 1 TextBox1
        /// Updates TextBox3 when changed
        /// </summary>
        public String TextBox1
        {
            get { return _textbox1; }
            set
            {
                _textbox1 = value;
                OnPropertyChanged("TextBox1");
                OnPropertyChanged("TextBox3");
            }
        }

        /// <summary>
        /// Property for Page 2 TextBox1
        /// Updates TextBox3 when changed
        /// </summary>
        public String TextBox2
        {
            get { return _textbox2; }
            set
            {
                _textbox2 = value;
                OnPropertyChanged("TextBox2");
                OnPropertyChanged("TextBox3");
            }
        }

        /// <summary>
        /// Property for Page 1 TextBox3
        /// Updates based on TextBox1 & TextBox2
        /// </summary>
        public string TextBox3
        {
            get { return _textbox1 + " " + _textbox2; }
            set { OnPropertyChanged("TextBox3"); }
        }

        private ObservableCollection<ListItem> _comboItems;
        /// <summary>
        /// Combobox 1 Data
        /// </summary>
        public ObservableCollection<ListItem> ComboItems
        {
            get { return _comboItems; }
            set { _comboItems = value; OnPropertyChanged(nameof(ComboItems)); }
        }

        private ListItem _selectedComboItem;
        /// <summary>
        /// Selected ComboBox Item
        /// </summary>
        public ListItem SelectedComboItem
        {
            get { return _selectedComboItem; }
            set { _selectedComboItem = value; OnPropertyChanged(nameof(SelectedComboItem)); OnPropertyChanged(nameof(ComboSelectionText)); }
        }

        /// <summary>
        /// Displays Combobox selection string
        /// </summary>
        public string ComboSelectionText
        {
            get { return SelectedComboItem != null ? SelectedComboItem.Description : ""; }
            set { OnPropertyChanged(nameof(ComboSelectionText)); }
        }

        #endregion


        #region Constructor
        /// <summary>
        /// Default Constructor
        /// </summary>
        private Page1ViewModel(int documentHashCode)
        {
            _openDialogCustomCommand = new RelayCommand(OnOpenDialogCustom);

            DocumentData = "Document Hashcode: " + documentHashCode.ToString();
            DocumentHashCode = documentHashCode;

            //Initialize viewmodel
            Initialize();

            //If list of viewmodels is null, create a new list
            if (_viewModels == null)
                _viewModels = new List<Page1ViewModel>();

            //Add viewmodel to list of viewmodels
            _viewModels.Add(this);
        }
        #endregion

        #region Private Methods
        private void OnOpenDialogCustom(object parameter)
        {
            var vm = new CustomDialogViewModel();
            vm.OkClicked += OptionOk;
            vm.CancelClicked += OptionCancel;
            vm.Owner = parameter as Window;
            if (DialogService != null)
                DialogService.ShowDialog(vm);
        }

        private void OptionOk(object sender, EventArgs e)
        {
            ComboItems = (sender as CustomDialogViewModel).ListItems;
            SelectedComboItem = ComboItems.Last();


        }

        private void OptionCancel(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Test and Initialize Page Viewmodel
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
            PopulateTextBox1();
            PopulateTextBox2();

            ComboItems = PopulateCombo1();
            SelectedComboItem = ComboItems[0];

            //Initialize sub viewmodels
            //Note if you do this here, be sure it is updated in the RevitDocument or below in the SetCurrentViewmodel method
            //Page1BViewModel.SetCurrentViewModel(DocumentHashCode);

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
        /// Default values for TextBox1
        /// </summary>
        private void PopulateTextBox1()
        {
            //_instance.TextBox1 = "Text 1 :";
            TextBox1 = "Text 1 :";
        }

        /// <summary>
        /// Default values for TextBox2
        /// </summary>
        private void PopulateTextBox2()
        {
            //_instance.TextBox2 = "Text 2";
            TextBox2 = "Text 2";
        }

        /// <summary>
        /// Private Method to populate ComboBox 1
        /// </summary>
        /// <returns></returns>
        private ObservableCollection<ListItem> PopulateCombo1()
        {
            var items = ListItem.Populate();
            return items;
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
                _ = new Page1ViewModel(-1);

            var retrievedViewModel = _viewModels.FirstOrDefault(x => x.DocumentHashCode == hashCode);

            if (retrievedViewModel == null)
                retrievedViewModel = new Page1ViewModel(hashCode);

            retrievedViewModel.SetCurrentViewModel();
        }

        #endregion

    }
}
