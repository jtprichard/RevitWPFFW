using System.Collections.ObjectModel;
using System.ComponentModel;


namespace PB.RevitWPFFW.core
{
    public class ListItem : INotifyPropertyChanged
    {
        private string _description;
        private static int count = 100;

        public int Item { get; private set; }

        public string Description
        {
            get => _description;
            set { _description = value; OnPropertyChanged(nameof(Description)); }
        }

        public ListItem() { }

        public ListItem(string value)
        {
            Description = value;
            Item = count;
            count++;
        }

        public static ObservableCollection<ListItem> Populate()
        {
            ObservableCollection<ListItem> items = new ObservableCollection<ListItem>
            {
                new ListItem {Item = 0, Description = "List Item 1"},
                new ListItem {Item = 1, Description = "List Item 2"},

            };
            return items;
        }


        /// <summary>
        /// Occurs when a property value changes
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        /// <summary>
        /// Property Changed Method
        /// </summary>
        /// <param name="name"></param>
        public void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
