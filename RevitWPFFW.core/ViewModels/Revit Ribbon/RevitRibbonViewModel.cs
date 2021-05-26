using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitWPFFW.core
{
    public sealed class RevitRibbonViewModel
    {
        #region Fields
        private static RevitRibbonViewModel _instance = null;
        #endregion

        #region Properties
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

        public string RibbonTextBox { get; set; }
        public string RibbonComboBox { get; set; }

        #endregion

        #region Constructor
        /// <summary>
        /// Default Constructor
        /// </summary>
        private RevitRibbonViewModel() { }

        #endregion
    }
}
