using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace RevitWPFFW.core
{
    public class Page1ViewModel : BaseViewModel
    {
        #region Private Fields
        //private static Page1ViewModel _instance = null;
        //private static bool _docInitialized = false;

        private string _textbox1;

        private string _textbox2;

        private ObservableCollection<Combo1Data> _combo1Items;
        private Combo1Data _selectedCombo1;
        

        //FOR TESTING
        private string _documentData;

        #endregion

        #region Public Properties
        ///// <summary>
        ///// Instance of Page View Model
        ///// If no instance exists, create a new one
        ///// If the VM has not been initialized and the document is opened, initialize it
        ///// </summary>
        //public static Page1ViewModel Instance
        //{
        //    get
        //    {
        //        if (_instance == null)
        //            _instance = new Page1ViewModel();
        //        return _instance;
        //    }
        //}

        //FOR TESTING
        public string DocumentData
        {
            get { return _documentData; }
            set { _documentData = value; OnPropertyChanged("DocumentData"); }
        }

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
        public Page1ViewModel(string docData)
        {
            DocumentData = docData;
            InitializeViewModel();
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Initialize the View Model Properties
        /// </summary>
        private void InitializeViewModel()
        {
            PopulateTextBox1();
            PopulateTextBox2();

            this.Combo1 = PopulateCombo1();
            this.Combo1Selection = Combo1[0];

            //_docInitialized = true;
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
        ///// <summary>
        ///// Public Method to Initialize Page ViewModel
        ///// </summary>
        //internal void Initialize()
        //{
        //    //if (!_docInitialized && _instance != null)
        //    if(!_docInitialized)
        //    {
        //        //_instance.InitializeViewModel();
        //        InitializeViewModel();

        //        //Initialize Sub Views
        //        Page1BViewModel.Initialize();
        //    }
        //}

        public void Refresh()
        {
            OnPropertyChanged("");
            OnPropertyChanged("TextBox1");
        }

        #endregion

    }
}
