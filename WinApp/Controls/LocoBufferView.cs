using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using LocoNetToolBox.Protocol;
using Message = LocoNetToolBox.Protocol.Message;

namespace LocoNetToolBox.WinApp.Controls
{
    public partial class LocoBufferView : UserControl
    {
        private LocoBuffer locoBuffer;

        /// <summary>
        /// View on the locobuffer.
        /// </summary>
        public LocoBufferView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Connect to the locobuffer.
        /// </summary>
        internal LocoBuffer LocoBuffer
        {
            set
            {
                if (locoBuffer != null)
                {
                    locoBuffer.SendMessage -= new MessageHandler(locoBuffer_SendMessage);
                    locoBuffer.PreviewMessage -= new MessageHandler(locoBuffer_PreviewMessage);
                }
                locoBuffer = value;
                locoBufferSettings.LocoBuffer = value;
                if (locoBuffer != null)
                {
                    locoBuffer.SendMessage += new MessageHandler(locoBuffer_SendMessage);
                    locoBuffer.PreviewMessage += new MessageHandler(locoBuffer_PreviewMessage);
                }
            }
        }

        /// <summary>
        /// Add message to log.
        /// </summary>
        bool locoBuffer_PreviewMessage(byte[] message)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MessageHandler(locoBuffer_PreviewMessage), message);
            }
            else
            {
                var response = Response.Decode(message);
                Log("<- " + response + " { " + Message.ToString(message) + " }");
                lbInputs.ProcessResponse(response);
            }
            return false;
        }

        /// <summary>
        /// Add send message to log.
        /// </summary>
        bool locoBuffer_SendMessage(byte[] message)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MessageHandler(locoBuffer_SendMessage), message);
            }
            else
            {
                Log("-> " + Message.ToString(message));
            }
            return false;
        }

        private void Log(string msg)
        {
            lbLog.Items.Add(msg);
            lbLog.SelectedIndex = lbLog.Items.Count - 1;
        }
    }
}
