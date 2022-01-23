using System;

namespace PB.RevitWPFFW.core
{
    /// <summary>
    /// Creates and Stores the Dockable Pane Guid
    /// </summary>
    public class DockablePaneIdentifier
    {
        #region Private Fields
        /// <summary>
        /// Stores the Main Pane Guid
        /// </summary>
        private Guid _mainPaneGuid;

        private static DockablePaneIdentifier _instance = null;

        /// <summary>
        /// CurrentViewModel of Dockable Pane Indentifier
        /// Creates instance if none exists
        /// </summary>
        private static DockablePaneIdentifier Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DockablePaneIdentifier();
                return _instance;
            }
        }
        #endregion

        #region Default Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        private DockablePaneIdentifier()
        {
            _mainPaneGuid = Guid.NewGuid();
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Returns the Main Pane Guid
        /// </summary>
        /// <returns></returns>
        public static Guid GetMainPaneIdentifier()
        {
            return Instance._mainPaneGuid;
        }
        #endregion

    }
}
