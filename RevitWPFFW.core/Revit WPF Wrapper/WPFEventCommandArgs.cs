using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RevitWPFFW.core
{
    public class WPFEventCommandArgs
    {
        public Type EventClass { get; }
        public MethodInfo Method { get; }

        public WPFEventCommandArgs(string args)
        {
            List<string> argList = args.Split(',').ToList<string>();
            EventClass = Type.GetType(argList[0]);
            Method = EventClass.GetMethod(argList[1]);

        }

    }
}
