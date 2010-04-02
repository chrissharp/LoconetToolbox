using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LocoNetToolBox.Protocol
{
    /// <summary>
    /// Master is busy
    /// </summary>
    public class Busy : Request
    {
        internal override void Execute(LocoBuffer lb)
        {
            lb.Send(0x81, 0);
        }
    }
}
