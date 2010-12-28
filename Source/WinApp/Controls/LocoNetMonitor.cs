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
using System.Windows.Forms;

using LocoNetToolBox.Protocol;
using LocoNetToolBox.WinApp.Communications;
using Message = LocoNetToolBox.Protocol.Message;

namespace LocoNetToolBox.WinApp.Controls
{
    public partial class LocoNetMonitor : UserControl
    {
        private AsyncLocoBuffer locoBuffer;

        /// <summary>
        /// View on the locobuffer.
        /// </summary>
        public LocoNetMonitor()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Connect to the locobuffer.
        /// </summary>
        internal AsyncLocoBuffer LocoBuffer
        {
            set
            {
                if (locoBuffer != null)
                {
                    locoBuffer.SendMessage -= LocoBufferSendMessage;
                    locoBuffer.PreviewMessage -= LocoBufferPreviewMessage;
                }
                locoBuffer = value;
                if (locoBuffer != null)
                {
                    locoBuffer.SendMessage += LocoBufferSendMessage;
                    locoBuffer.PreviewMessage += LocoBufferPreviewMessage;
                }
            }
        }

        /// <summary>
        /// Add message to log.
        /// </summary>
        bool LocoBufferPreviewMessage(byte[] message, Message decoded)
        {
            var response = Response.Decode(message);
            Log("<- " + response + " { " + Message.ToString(message) + " }");
            lbInputs.ProcessResponse(response);
            return false;
        }

        /// <summary>
        /// Add send message to log.
        /// </summary>
        bool LocoBufferSendMessage(byte[] message, Message decoded)
        {
            Log("-> " + Message.ToString(message));
            return false;
        }

        private void Log(string msg)
        {
            lbLog.Items.Add(msg);
            lbLog.SelectedIndex = lbLog.Items.Count - 1;
        }
    }
}
