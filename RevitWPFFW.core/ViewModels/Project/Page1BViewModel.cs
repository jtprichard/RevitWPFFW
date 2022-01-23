using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using PB.MVVMToolkit.ViewModel;

namespace PB.RevitWPFFW.core
{
    /// <summary>
    /// View Model for WPF Page
    /// </summary>
    public class Page1BViewModel : BaseViewModel
    {
        #region Private Fields
        private static Page1BViewModel _currentViewModel = null;
        private static bool _docInitialized = false;
        private static IList<Page1BViewModel> _viewModels;

        private int _documentHashCode;

        //Sample control fields
        private ObservableCollection<CheckBoxData> _checkBoxItems;
        private string _checkBoxSelectedItems;

        //FOR TESTING
        private string _documentData;

        #endregion

        #region Public Properties
        /// <summary>
        /// CurrentViewModel of Page View Model
        /// If no instance exists, create a new one
        /// </summary>
        public static Page1BViewModel CurrentViewModel
        {
            get
            {
                if (_currentViewModel == null)
                    _currentViewModel = new Page1BViewModel(0);
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
        public static IList<Page1BViewModel> ViewModels => _viewModels;

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
        private Page1BViewModel(int documentHashCode)
        {
            DocumentData = "Document Hashcode: " + documentHashCode.ToString();
            DocumentHashCode = documentHashCode;

            //Initialize the viewmodel
            Initialize();

            //If list of viewmodels is null, create a new list
            if (_viewModels == null)
                _viewModels = new List<Page1BViewModel>();

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
            this.CheckBoxItems = PopulateCheckBoxes();
            UpdateTextBoxString();

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
        /// Update checkbox string from property change in Data
        /// </summary>
        internal static void UpdateTextBoxString()
        {
            if(_currentViewModel != null)
                _currentViewModel.CheckBoxSelectedItems = _currentViewModel.GetCheckBoxItemsString();
        }

        /// <summary>
        /// Sets the current static viewmodel to the viewmodel associated with the document hashcode provided
        /// </summary>
        /// <param name="hashCode">Document hashcode as integer</param>
        public static void SetCurrentViewModel(int hashCode)
        {
            if (_viewModels == null)
                _ = new Page1BViewModel(-1);

            var retrievedViewModel = _viewModels.FirstOrDefault(x => x.DocumentHashCode == hashCode);

            if (retrievedViewModel == null)
                retrievedViewModel = new Page1BViewModel(hashCode);

            retrievedViewModel.SetCurrentViewModel();
        }

        #endregion

    }
}
