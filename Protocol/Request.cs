using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LocoNetToolBox.Protocol
{
    public abstract class Request : Message
    {
        /// <summary>
        /// Execute the message on the given buffer
        /// </summary>
        internal abstract void Execute(LocoBuffer lb);
    }
}
