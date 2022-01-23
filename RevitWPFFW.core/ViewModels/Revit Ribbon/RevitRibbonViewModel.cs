using Autodesk.Revit.UI;
using PB.RevitWPFFW.res;
using System.Windows.Media.Imaging;

namespace PB.RevitWPFFW.core
{
    /// <summary>
    /// Class holds properties assocaited with text, comboboxes
    /// and other user feedback on the custom Ribbon Toolbar
    /// </summary>
    public sealed class RevitRibbonViewModel
    {
        #region Private Fields
        private static RevitRibbonViewModel _instance = null;

        private static BitmapImage _showPageImageOn = ResourceImage.GetIcon("blank_button.png");

        private static BitmapImage _showPageImageOff = ResourceImage.GetIcon("blank_button_no.png");

        #endregion

        #region Public CurrentViewModel Property
        /// <summary>
        /// CurrentViewModel of Ribbon
        /// Creates instance if none exists
        /// </summary>
        public static RevitRibbonViewModel Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new RevitRibbonViewModel();
                return _instance;
            }
        }
        #endregion

        #region Ribbon Properties

        public string RibbonTextBox { get; set; }
        public string RibbonComboBox { get; set; }
        public RibbonButton ShowPagePushButton { get; set; }

        #endregion

        #region Constructor
        /// <summary>
        /// Default Constructor
        /// </summary>
        private RevitRibbonViewModel() { }

        #endregion

        public static void TurnPageButtonImageOn()
        {
            Instance.ShowPagePushButton.LargeImage = _showPageImageOff;
            Instance.ShowPagePushButton.ItemText = "Hide\nPane";
        }

        public static void TurnPageButtonImageOff()
        {
            Instance.ShowPagePushButton.LargeImage = _showPageImageOn;
            Instance.ShowPagePushButton.ItemText = "Show\nPane";
        }
    }
}
