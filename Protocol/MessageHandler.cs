using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LocoNetToolBox.Protocol
{
    /// <summary>
    /// Loconet message handler.
    /// </summary>
    /// <param name="message">The received message</param>
    /// <returns>True if the message has been handled, false to pass the message to the next handler.</returns>
    internal delegate bool MessageHandler(byte[] message);
}
