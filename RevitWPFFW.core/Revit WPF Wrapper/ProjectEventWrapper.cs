using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitWPFFW.core
{
    public static class ProjectEventWrapper
    {
        public static RevitWPFEventHandler Command { get; private set; }

        public static void SetEventHandler(RevitWPFEventHandler eh)
        {
            Command = eh;
        }
    }
}
