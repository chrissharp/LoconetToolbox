using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LocoNetToolBox.Protocol
{
    public class GlobalPowerOn : Request
    {
        internal override void Execute(LocoBuffer lb)
        {
            lb.Send(0x83, 0);
        }
    }
}
