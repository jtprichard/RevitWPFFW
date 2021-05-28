using Autodesk.Revit.UI;
using RevitWPFFW.res;
using System.Windows.Media;

namespace RevitWPFFW.core
{
    /// <summary>
    /// Class holds properties assocaited with text, comboboxes
    /// and other user feedback on the custom Ribbon Toolbar
    /// </summary>
    public sealed class RevitRibbonViewModel
    {
        #region Private Fields
        private static RevitRibbonViewModel _instance = null;

        private static ImageSource _showPageImageOn = ResourceImage.GetIcon("blank_button");

        private static ImageSource _showPageImageOff = ResourceImage.GetIcon("blank_button_no");

        #endregion

        #region Public Instance Property
        /// <summary>
        /// Instance of Ribbon
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
        public PushButton ShowPagePushButton { get; set; }
        

        public ImageSource ShowPageButtonImage { get; set; }

        #endregion

        #region Constructor
        /// <summary>
        /// Default Constructor
        /// </summary>
        private RevitRibbonViewModel() { }

        #endregion

        public void ShowPageButtonImageToggle()
        {
            if (ShowPageButtonImage == _showPageImageOn)
                ShowPageButtonImage = _showPageImageOff;
            else
                ShowPageButtonImage = _showPageImageOn;

            ShowPagePushButton.Image = ShowPageButtonImage;
        }
    }
}
