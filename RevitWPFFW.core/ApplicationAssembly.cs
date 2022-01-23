using System.Reflection;

namespace PB.RevitWPFFW.core
{
    /// <summary>
    /// The main application asssembly helper methods
    /// </summary>
    public static class ApplicationAssembly
    {
        #region Public Methods
        /// <summary>
        /// Gets the main application assembly location
        /// </summary>
        /// <returns></returns>
        public static string GetAssemblyLocation()
        {
            return Assembly.GetExecutingAssembly().Location;
        }

        #endregion
    }
}
