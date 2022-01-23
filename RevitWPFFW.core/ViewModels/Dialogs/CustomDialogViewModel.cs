using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using PB.MVVMToolkit.DialogServices;
using PB.MVVMToolkit.ViewModel;
using PB.MVVMToolkit.Dialogs;

namespace PB.RevitWPFFW.core
{
    public class CustomDialogViewModel : BaseDialogViewModel
    {
        #region Event Handlers

        public event EventHandler OkClicked = delegate { };
        public event EventHandler CancelClicked = delegate { };

        #endregion

        #region Commands

        private ICommand okCommand = null;
        /// <summary>
        /// Command for Ok Button
        /// </summary>
        public ICommand OkCommand
        {
            get { return okCommand; }
            set { okCommand = value; }
        }

        private ICommand cancelCommand = null;
        /// <summary>
        /// Command for Cancel Button
        /// </summary>
        public ICommand CancelCommand
        {
            get { return cancelCommand; }
            set { cancelCommand = value; }
        }

        private ICommand _openDialogAddCommand = null;
        /// <summary>
        /// Command to Add an Item
        /// </summary>
        public ICommand OpenDialogAddCommand
        {
            get { return _openDialogAddCommand; }
            set { _openDialogAddCommand = value; }
        }

        private ICommand _openDialogEditCommand = null;
        /// <summary>
        /// Command to Edit an Item
        /// </summary>
        public ICommand OpenDialogEditCommand
        {
            get { return _openDialogEditCommand; }
            set { _openDialogEditCommand = value; }
        }

        private ICommand _openDialogDeleteCommand = null;
        /// <summary>
        /// Command to Delete an Item
        /// </summary>
        public ICommand OpenDialogDeleteCommand
        {
            get { return _openDialogDeleteCommand; }
            set { _openDialogDeleteCommand = value; }
        }

        #endregion

        #region Private Fields

        private readonly ObservableCollection<ListItem> _originalItemList = null;

        #endregion

        #region Properties
        private ObservableCollection<ListItem> _listItems;
        /// <summary>
        /// List items as Observable Collection
        /// </summary>
        public ObservableCollection<ListItem> ListItems
        {
            get { return _listItems; }
            set { _listItems = value; OnPropertyChanged(nameof(ListItems)); }
        }

        private ListItem _selectedListItem;
        /// <summary>
        /// The selected list item
        /// </summary>
        public ListItem SelectedListItem
        {
            get { return _selectedListItem; }
            set
            {
                _selectedListItem = value;
                OnPropertyChanged(nameof(SelectedListItem));
            }
        }

        #endregion

        #region Constructors
        /// <summary>
        /// Default Constructor
        /// </summary>
        public CustomDialogViewModel()
        {
            // Initiate commands
            _openDialogAddCommand = new RelayCommand(OnOpenDialogAdd);
            _openDialogEditCommand = new RelayCommand(OnOpenDialogEdit);
            _openDialogDeleteCommand = new RelayCommand(OnOpenDialogDelete);
            
            this.okCommand = new RelayCommand(OnOkClicked);
            this.cancelCommand = new RelayCommand(OnCancelClicked);

            //Populate the list and select the first item as default
            PopulateListItems(Page1ViewModel.CurrentViewModel.ComboItems);
            SelectedListItem = ListItems[0];

            //Store the original item list to confirm at the end
            _originalItemList = Page1ViewModel.CurrentViewModel.ComboItems;
        }

        #endregion

        #region Private Methods
        /// <summary>
        /// Open the dialog window to add an item
        /// </summary>
        /// <param name="parameter"></param>
        private void OnOpenDialogAdd(object parameter)
        {
            string message = "What item do you want to add?";
            var dialog = new DialogInputOkCancel(message, "Add Item");
            dialog.Image = DialogImage.Question;
            dialog.Answer = "Default Item";
            var result = dialog.Show();
            string answer = dialog.Answer;

            if (result == DialogResult.Cancel)
            {
                DialogOk.Show("No information was added", "Cancel", DialogImage.Info);
            }
            else
            {
                AddItemToList(answer);
            }


        }
        /// <summary>
        /// Open the dialog to edit an item
        /// </summary>
        /// <param name="parameter"></param>
        private void OnOpenDialogEdit(object parameter)
        {
            string message = "Edit the current item.";

            var dialog = new DialogInputOkCancel(message, "Edit Item");
            dialog.Image = DialogImage.Question;
            dialog.Answer = SelectedListItem.Description;
            var result = dialog.Show();
            string answer = dialog.Answer;

            if (result == DialogResult.Ok)
            {
                SelectedListItem.Description = answer;
                OnPropertyChanged(nameof(ListItems));
                OnPropertyChanged(nameof(SelectedListItem));
            }

        }
        /// <summary>
        /// Open the dialog to delete an item
        /// </summary>
        /// <param name="parameter"></param>
        private void OnOpenDialogDelete(object parameter)
        {
            //Confirm there are at least 2 items on the list
            if (ListItems.Count <= 1)
            {
                string dialogMessage = "You must always have one item in your list";
                var deleteErrorResult = DialogOk.Show(dialogMessage, "Error", DialogImage.Error);
                return;
            }
            
            
            string message = "Are you sure you want to delete the item " + SelectedListItem.Description;
            DialogResult result = DialogYesNo.Show(message, "Delete Item", DialogImage.Warning);

            if (result == DialogResult.Yes)
            {
                //Look for the selected item in the list and remove ite
                ListItems.Remove(GetSelectedListItem(SelectedListItem));
                //Adjust the default selecteditem
                if (ListItems.Count > 0)
                    SelectedListItem = ListItems.FirstOrDefault();
                else
                    SelectedListItem = null;

                //Initiate property changed for view
                OnPropertyChanged(nameof(ListItems));
                OnPropertyChanged(nameof(SelectedListItem));
            }
        }

        /// <summary>
        /// Adds an item to the list
        /// </summary>
        /// <param name="item"></param>
        private void AddItemToList(string item)
        {
            ListItems.Add(new ListItem(item));
        }

        /// <summary>
        /// Locates the item in the itemlist
        /// </summary>
        /// <param name="item">Item as ListItem</param>
        /// <returns></returns>
        private ListItem GetSelectedListItem(ListItem item)
        {
            return ListItems.FirstOrDefault(x => x.Description == item.Description);

        }

        /// <summary>
        /// Populate the list at startup
        /// </summary>
        /// <param name="listItems"></param>
        private void PopulateListItems(ObservableCollection<ListItem> comboItems)
        {
            var items = new ObservableCollection<ListItem>();
            foreach (var item in comboItems)
                items.Add(new ListItem(item.Description));

            ListItems = items;
        }

        /// <summary>
        /// Command for clicking Ok on dialog
        /// </summary>
        /// <param name="parameter"></param>
        private void OnOkClicked(object parameter)
        {
            this.OkClicked(this, EventArgs.Empty);
            CloseDialog(parameter as Window);
        }

        /// <summary>
        /// Command for clicking cancel on dialog
        /// </summary>
        /// <param name="parameter"></param>
        private void OnCancelClicked(object parameter)
        {
            if (VerifyItemsChanged())
            {
                var result = DialogYesNo.Show("List items have changed.  Are you sure you want to cancel?", "List Items", DialogImage.Warning);
                if (result != DialogResult.Yes)
                    return;
            }

            this.CancelClicked(this, EventArgs.Empty);
            CloseDialog(parameter as Window);
        }

        private bool VerifyItemsChanged()
        {
            if (_originalItemList.Count == 0 || ListItems.Count == 0)
                return true;
            if (_originalItemList.Count != ListItems.Count)
                return true;
            for(int i = 0; i< ListItems.Count; i++)
            {
                if (ListItems[i].Description != _originalItemList[i].Description)
                    return true;
            }

            return false;
        }

        #endregion

    }
}
