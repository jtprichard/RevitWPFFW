using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;

namespace PB.RevitWPFFW.ui
{
    /// <summary>
    /// Stores data required for contextual help
    /// </summary>
    public class RevitContextualHelpData
    {
        #region Private Fields



        #endregion

        #region Public Properties
        /// <summary>
        /// The file path of the contextual help file as string
        /// </summary>
        public string FilePathName { get; private set; }
        /// <summary>
        /// The URL for the help topic
        /// </summary>
        public string HelpTopic { get; set; }
        /// <summary>
        /// The contextual help type as Revit ContextualHelpType enumeration
        /// </summary>
        public ContextualHelpType HelpType { get; private set; }
        /// <summary>
        /// The contextual help object
        /// </summary>
        public ContextualHelp ContextualHelp => GetContextualHelp();

        #endregion

        #region Constructors
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="filePath">The path for the help file</param>
        /// <param name="helpType">The Revit ContextualHelp Type of Help File</param>
        public RevitContextualHelpData(string filePath, ContextualHelpType helpType)
        {
            FilePathName = filePath;
            HelpType = helpType;
        }

        public RevitContextualHelpData(RevitContextualHelpData data, string topic)
        {
            FilePathName = data.FilePathName;
            HelpType = data.HelpType;
            HelpTopic = topic;
        }


        #endregion

        #region Public Methods



        #endregion

        #region Private Methods

        private ContextualHelp GetContextualHelp()
        {
            if (FilePathName != "")
            {
                var ch = new ContextualHelp(HelpType, FilePathName);
                ch.HelpTopicUrl = HelpTopic;
                return ch;
            }

            return null;

        }
        

        #endregion
    }
}
