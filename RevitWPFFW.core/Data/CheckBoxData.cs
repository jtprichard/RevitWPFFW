namespace PB.RevitWPFFW.core
{
    public class CheckBoxData
    {
        private bool _isSelected;

        /// <summary>
        /// Enumeration for Item
        /// </summary>
        public CheckBoxEnum CheckEnum { get; set; }
        /// <summary>
        /// Value for Item
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// Is Checkbox Selected
        /// </summary>
        public bool IsSelected
        {
            get { return _isSelected; }
            set { _isSelected = value; Page1BViewModel.UpdateTextBoxString(); }
        }
        /// <summary>
        /// Default Constructor
        /// </summary>
        public CheckBoxData() { }
    }
}
