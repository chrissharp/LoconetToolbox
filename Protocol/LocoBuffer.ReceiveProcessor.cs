using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace LocoNetToolBox.Protocol
{
    partial class LocoBuffer
    {
        private class ReceiveProcessor
        {
            private readonly LocoBuffer lb;
            private readonly Thread thread;

            /// <summary>
            /// Create and start a new processor
            /// </summary>
            public ReceiveProcessor(LocoBuffer lb)
            {
                this.lb = lb;
                this.thread = new Thread(OnRun);
                this.thread.Start();
            }

            /// <summary>
            /// Run the processor.
            /// </summary>
            private void OnRun()
            {
                while (true)
                {
                    try
                    {
                        var msg = lb.ReadMessage();
                        if (msg == null) { break; }
                        lb.HandleMessage(msg);
                    }
                    catch (TimeoutException)
                    {
                        // Ignore timeouts
                    }
                    catch
                    {
                        // Ignore other exceptions
                    }
                }
            }
        }
    }
}
