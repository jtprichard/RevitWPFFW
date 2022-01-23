using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace PB.RevitWPFFW.core
{
    /// <summary>
    /// Holds the Type and Method for arguments passed to
    /// the WPF Event Handler / Wrapper
    /// String format must match the GetMethod in BaseCommand Class
    /// or manual: [TYPE],[METHOD]
    /// Future development to include parsing properties from the argument string
    /// </summary>
    public class WPFEventCommandArgs
    {
        /// <summary>
        /// Command Class
        /// </summary>
        public Type EventClass { get; }
        /// <summary>
        /// Command Method
        /// </summary>
        public MethodInfo Method { get; }

        public WPFEventCommandArgs(string args)
        {
            List<string> argList = args.Split(',').ToList<string>();
            EventClass = Type.GetType(argList[0]);
            Method = EventClass.GetMethod(argList[1]);
        }
    }
}
