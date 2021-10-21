using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using PB.MVVMToolkit.ViewModel;

namespace RevitWPFFW.core
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
        private ObservableCollection<Combo1Data> _combo1Items;
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

        /// <summary>
        /// Combobox 1 Data
        /// </summary>
        public ObservableCollection<Combo1Data> Combo1
        {
            get { return _combo1Items; }
            set { _combo1Items = value; OnPropertyChanged("Combo1"); }
        }

        /// <summary>
        /// Selected ComboBox Item
        /// </summary>
        public Combo1Data Combo1Selection
        {
            get { return _selectedCombo1; }
            set { _selectedCombo1 = value; OnPropertyChanged("Combo1Selection"); OnPropertyChanged("Combo1SelectionText"); }
        }

        /// <summary>
        /// Displays Combobox selection string
        /// </summary>
        public string Combo1SelectionText
        {
            get { return Combo1Selection != null ? Combo1Selection.Value : ""; }
            set { OnPropertyChanged("Combo1SelectionText"); }
        }

        #endregion


        #region Constructor
        /// <summary>
        /// Default Constructor
        /// </summary>
        private Page1ViewModel(int documentHashCode)
        {
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

            Combo1 = PopulateCombo1();
            Combo1Selection = Combo1[0];

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
        private ObservableCollection<Combo1Data> PopulateCombo1()
        {
            ObservableCollection<Combo1Data> items = new ObservableCollection<Combo1Data>();

            items.Add(new Combo1Data { ComboEnum = Combo1Enum.ComboEnum1, Value = "Value 1" });
            items.Add(new Combo1Data { ComboEnum = Combo1Enum.ComboEnum2, Value = "Value 2" });
            items.Add(new Combo1Data { ComboEnum = Combo1Enum.ComboEnum3, Value = "Value 3" });

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
