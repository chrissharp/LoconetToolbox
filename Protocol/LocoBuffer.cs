/*
Loconet toolbox
Copyright (C) 2010 Modelspoorgroep Venlo, Ewout Prangsma

This program is free software; you can redistribute it and/or
modify it under the terms of the GNU General Public License
as published by the Free Software Foundation; either version 2
of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program; if not, write to the Free Software
Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Threading;

namespace LocoNetToolBox.Protocol
{
    /// <summary>
    /// LocoBuffer communication.
    /// </summary>
    internal sealed partial class LocoBuffer : IDisposable
    {
        private const int CTS_ATTEMPTS = 20;

        internal event MessageHandler SendMessage;
        internal event MessageHandler PreviewMessage;
        internal event EventHandler Opened;
        internal event EventHandler Closed;

        private readonly object portLock = new object();
        private SerialPort port;
        private ReceiveProcessor receiveProcessor;
        private readonly object handlersLock = new object();
        private readonly List<MessageHandler> handlers = new List<MessageHandler>();

        /// <summary>
        /// Default ctor
        /// </summary>
        internal LocoBuffer()
        {
            this.PortName = "COM1";
            this.BaudRate = BaudRate.Rate57K;
        }

        /// <summary>
        /// Name of the serial port (e.g. COM1)
        /// </summary>
        public string PortName { get; set; }

        /// <summary>
        /// Baud rate of the port
        /// </summary>
        public BaudRate BaudRate { get; set; }

        /// <summary>
        /// Open the connection (if needed)
        /// </summary>
        private SerialPort Open()
        {
            lock (portLock)
            {
                if (port == null)
                {
                    try
                    {
                        port = new SerialPort(PortName);
                        port.BaudRate = (int)BaudRate;
                        port.DtrEnable = false;
                        port.RtsEnable = true;
                        //port.Handshake = Handshake.RequestToSend;
                        port.DataBits = 8;
                        port.StopBits = StopBits.One;
                        port.Parity = Parity.None;
                        port.Open();
                        port.DiscardInBuffer();
                        port.DiscardOutBuffer();
                        receiveProcessor = new ReceiveProcessor(this);
                        if (Opened != null) { Opened(this, EventArgs.Empty); }
                    }
                    catch
                    {
                        port = null;
                        throw;
                    }
                }
                return port;
            }
        }

        /// <summary>
        /// Close the connection (if any)
        /// </summary>
        internal void Close()
        {
            lock (portLock)
            {
                if (port != null)
                {
                    port.Close();
                    port = null;
                    receiveProcessor = null;
                    if (Closed != null) { Closed(this, EventArgs.Empty); }
                }
            }
        }

        /// <summary>
        /// Send the given message
        /// </summary>
        internal void Send(params byte[] msg)
        {
            Message.UpdateChecksum(msg, msg.Length);
            if (SendMessage != null) { SendMessage(msg); }
            var port = Open();
            var length = Message.GetMessageLength(msg);
            try
            {
                for (int i = 0; i < length; i++)
                {
                    WaitForCTS(port);
                    port.Write(msg, i, 1);
                }
            }
            catch (InvalidOperationException)
            {
                Close();
                throw;
            }
        }

        /// <summary>
        /// Wait for CTS to be enabled.
        /// </summary>
        private static void WaitForCTS(SerialPort port)
        {
            int attempts = 0;
            while (!port.CtsHolding)
            {
                Thread.Sleep(10);
                attempts++;
                if (attempts > CTS_ATTEMPTS)
                {
                    throw new InvalidOperationException("CTS timeout");
                }
            }
        }

        /// <summary>
        /// Read a single message
        /// </summary>
        private byte[] ReadMessage()
        {
            // Check for an open connection
            var port = this.port;
            if (port == null) { return null; }

            // Try to read the message
            var data = new byte[16];
            while (true)
            {
                // Read a potential opcode
                Read(port, data, 0, 1);
                if (Message.IsOpcode(data[0]))
                {
                    break;
                }
            }

            // Now read further data
            Read(port, data, 1, 1); // Read at least the second byte

            var length = Message.GetMessageLength(data);
            if (length > 2)
            {
                // Read remaining data
                Read(port, data, 2, length - 2);
            }

            return data;
        }

        private static void Read(SerialPort port, byte[] data, int offset, int count)
        {
            while (count > 0)
            {
                var read = port.Read(data, offset, count);
                if (read > 0)
                {
                    count -= read;
                    offset += read;
                } 
            }
        }

        /// <summary>
        /// Add a new handler to the handler queue.
        /// </summary>
        /// <returns>A registration. Dispose to unregister.</returns>
        internal IDisposable AddHandler(MessageHandler handler)
        {
            lock (handlersLock)
            {
                handlers.Add(handler);
                return new HandlerRegistration(this, handler);
            }
        }

        /// <summary>
        /// Remove a new handler from the handler queue.
        /// </summary>
        private void RemoveHandler(MessageHandler handler)
        {
            lock (handlersLock)
            {
                handlers.Remove(handler);
            }
        }

        /// <summary>
        /// Call all appriopriate handlers for the given message.
        /// </summary>
        private void HandleMessage(byte[] msg)
        {
            lock (handlersLock)
            {
                var preview = this.PreviewMessage;
                if (preview != null) { preview(msg); }

                for (int i = handlers.Count-1; i >= 0; i--)
                {
                    var handler = handlers[i];
                    var done = handler(msg);
                    if (done) { break; }
                }
            }
        }

        /// <summary>
        /// Cleanup
        /// </summary>
        void IDisposable.Dispose()
        {
            Close();
        }

        private class HandlerRegistration : IDisposable
        {
            private readonly MessageHandler handler;
            private readonly LocoBuffer lb;

            /// <summary>
            /// Default ctor
            /// </summary>
            internal HandlerRegistration(LocoBuffer lb, MessageHandler handler)
            {
                this.lb = lb;
                this.handler = handler;
            }

            void IDisposable.Dispose()
            {
                lb.RemoveHandler(handler);
            }

        }
    }
}
