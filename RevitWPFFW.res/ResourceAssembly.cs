using System.Reflection;

namespace PB.RevitWPFFW.res
{
    public static class ResourceAssembly
    {
        #region Public Methods

        /// <summary>
        /// Return current resource assembly
        /// </summary>
        /// <returns></returns>
        public static Assembly GetAssembly()
        {
            return Assembly.GetExecutingAssembly();
        }

        /// <summary>
        /// Return current namespace
        /// </summary>
        /// <returns></returns>
        public static string GetNameSpace()
        {
            return typeof(ResourceAssembly).Namespace + ".";
        }

        #endregion
    }
}
