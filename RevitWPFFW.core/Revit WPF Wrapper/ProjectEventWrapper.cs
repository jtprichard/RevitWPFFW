
namespace PB.RevitWPFFW.core
{
    /// <summary>
    /// Stores a static copy of the Event Handler
    /// For use in multiple commands
    /// </summary>
    public static class ProjectEventWrapper
    {
        /// <summary>
        /// Command to Raise
        /// </summary>
        public static RevitWPFEventHandler Command;

        public static void SetEventHandler(RevitWPFEventHandler eh)
        {
            Command = eh;
        }
    }
}
