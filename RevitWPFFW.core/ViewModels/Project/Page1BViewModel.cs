using System;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace RevitWPFFW.core
{
    public class Page1BViewModel : BaseViewModel
    {
        #region Private Fields
        private static Page1BViewModel _instance = null;
        private static bool _docInitialized = false;

        private ObservableCollection<CheckBoxData> _checkBoxItems;

        private string _checkBoxSelectedItems;
        
        #endregion

        #region Public Properties
        /// <summary>
        /// Instance of Page View Model
        /// If no instance exists, create a new one
        /// If the VM has not been initialized and the document is opened, initialize it
        /// </summary>
        public static Page1BViewModel Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Page1BViewModel();
                else if (!_docInitialized && RevitDocument.GetCurrentDocument() != null)
                    _instance.InitializeViewModel();
                return _instance;
            }
        }
        /// <summary>
        /// Checkbox Items
        /// </summary>
        public ObservableCollection<CheckBoxData> CheckBoxItems
        {
            get { return _checkBoxItems; }
            set { _checkBoxItems = value; OnPropertyChanged("CheckBoxItems"); }
        }

        /// <summary>
        /// String of the selected checkbox items
        /// </summary>
        public string CheckBoxSelectedItems
        {
            get { return _checkBoxSelectedItems; }
            set { _checkBoxSelectedItems = value; OnPropertyChanged("CheckBoxSelectedItems"); }
        }

        #endregion

        #region Constructor
        /// <summary>
        /// Default Constructor
        /// </summary>
        private Page1BViewModel() {}
        #endregion

        #region Private Methods
        /// <summary>
        /// Initialize the View Model Properties
        /// </summary>
        private void InitializeViewModel()
        {

            this.CheckBoxItems = PopulateCheckBoxes();
            UpdateTextBoxString();

            _docInitialized = true;

        }

        /// <summary>
        /// Private Method to populate Checkboxes
        /// </summary>
        /// <returns></returns>
        private ObservableCollection<CheckBoxData> PopulateCheckBoxes()
        {
            ObservableCollection<CheckBoxData> items = new ObservableCollection<CheckBoxData>();

            //Pupulate Checkbox Data - Sample Population Here

            items.Add(new CheckBoxData { CheckEnum = CheckBoxEnum.Checkbox1, Value = "Checkbox 1", IsSelected = false});
            items.Add(new CheckBoxData { CheckEnum = CheckBoxEnum.Checkbox2, Value = "Checkbox 2", IsSelected = false });
            items.Add(new CheckBoxData { CheckEnum = CheckBoxEnum.Checkbox3, Value = "Checkbox 3", IsSelected = false });
            items.Add(new CheckBoxData { CheckEnum = CheckBoxEnum.Checkbox4, Value = "Checkbox 4", IsSelected = true });

            return items;
        }

        /// <summary>
        /// Creates a string of the selected checkbox items
        /// </summary>
        /// <returns></returns>
        private string GetCheckBoxItemsString()
        {
            ObservableCollection<CheckBoxData> checkBoxItems = CheckBoxItems;

            if (null != checkBoxItems)
            {

                StringBuilder sb = new StringBuilder();

                foreach (CheckBoxData checkBoxItem in checkBoxItems)
                {
                    if (checkBoxItem.IsSelected)
                        sb.Append(checkBoxItem.Value + ", ");
                }

                //Removes last comma and space
                if (sb.Length > 2)
                    sb.Remove(sb.Length - 2, 2);

                return sb.ToString();
            }
            else
                return null;
        }

        #endregion

        #region Public Methods
        /// <summary>
        /// Public Method to Initialize Page ViewModelB
        /// </summary>
        internal static void Initialize()
        {
            if (!_docInitialized && _instance != null)
                _instance.InitializeViewModel();
        }

        /// <summary>
        /// Update checkbox string from property change in Data
        /// </summary>
        internal static void UpdateTextBoxString()
        {
            if(_instance != null)
                _instance.CheckBoxSelectedItems = _instance.GetCheckBoxItemsString();
        }

        #endregion

    }
}
