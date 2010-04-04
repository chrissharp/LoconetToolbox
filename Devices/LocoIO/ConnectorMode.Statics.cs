using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LocoNetToolBox.Devices.LocoIO
{
    partial class ConnectorMode
    {
        private static readonly ConnectorMode[] modes = new ConnectorMode[]
        {
            new ConnectorMode("MGV93",
                PinMode.BlockActiveLowDelay,
                PinMode.BlockActiveLowDelay,
                PinMode.BlockActiveLowDelay,
                PinMode.BlockActiveLowDelay,
                PinMode.BlockActiveLowDelay,
                PinMode.BlockActiveLowDelay,
                PinMode.BlockActiveLowDelay,
                PinMode.BlockActiveLowDelay),

            new ConnectorMode("MGV81 v1.0",
                PinMode.SteadyStatePairedOff,
                PinMode.SteadyStatePairedOff,
                PinMode.SteadyStatePairedOff,
                PinMode.SteadyStatePairedOff),

            new ConnectorMode("MGV136, MGV84, MGV81 v1.2",
                PinMode.SteadyStatePairedOff,
                PinMode.SteadyStatePairedOff,
                PinMode.SteadyStatePairedOff,
                PinMode.SteadyStatePairedOff,
                PinMode.TurnoutFeedbackDual2,
                PinMode.TurnoutFeedbackDual2,
                PinMode.TurnoutFeedbackDual2,
                PinMode.TurnoutFeedbackDual2),
        };

        /// <summary>
        /// Gets all connector modes
        /// </summary>
        public static IEnumerable<ConnectorMode> All
        {
            get { return modes; }
        }
    }
}
