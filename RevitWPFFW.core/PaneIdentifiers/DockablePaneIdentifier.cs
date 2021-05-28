using System;

namespace RevitWPFFW.core
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
        private static Guid _mainPaneGuid;

        #endregion

        #region Default Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public DockablePaneIdentifier() { }
        #endregion

        #region Public Methods
        /// <summary>
        /// Returns the Main Pane Guid
        /// </summary>
        /// <returns></returns>
        public static Guid GetMainPaneIdentifier()
        {
            if (null == _mainPaneGuid)
            {
                DockablePaneIdentifier dp = new DockablePaneIdentifier();
                _mainPaneGuid = Guid.NewGuid();
            }

            return _mainPaneGuid;
        }
        #endregion

    }
}
