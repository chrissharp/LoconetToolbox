using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LocoNetToolBox
{
    internal static class EventHandlerExtensions
    {
        /// <summary>
        /// Fire the given handler.
        /// </summary>
        internal static void Fire(this EventHandler handler, object sender)
        {
            if (handler != null)
            {
                handler(sender, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Fire the given handler.
        /// </summary>
        internal static void Fire<T>(this EventHandler<T> handler, object sender, T args)
            where T : EventArgs
        {
            if (handler != null)
            {
                handler(sender, args);
            }
        }
    }
}
