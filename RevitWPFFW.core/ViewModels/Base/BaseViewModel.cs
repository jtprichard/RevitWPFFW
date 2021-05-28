using System.ComponentModel;

namespace RevitWPFFW.core
{
    /// <summary>
    /// Base View Model for Property Changed Events
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged

    {
        #region Events
        /// <summary>
        /// Occurs when a property value changes
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
        #endregion

        #region Public Methods

        /// <summary>
        /// Property Changed Method
        /// </summary>
        /// <param name="name"></param>
        public void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #endregion
    }


}
