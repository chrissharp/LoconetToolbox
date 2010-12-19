namespace LocoNetToolBox.Devices.LocoIO.ConnectorModes
{
    /// <summary>
    /// Connector mode for an MGV81 v1.
    /// </summary>
    public sealed class Mgv136 : ConnectorMode
    {
        /// <summary>
        /// Default ctor
        /// </summary>
        public Mgv136()
            : base("MGV136, MGV84, MGV81 v1.2",
                4,
                PinMode.SteadyStatePairedOff,
                PinMode.SteadyStatePairedOff,
                PinMode.SteadyStatePairedOff,
                PinMode.SteadyStatePairedOff,
                PinMode.TurnoutFeedbackDual2,
                PinMode.TurnoutFeedbackDual2,
                PinMode.TurnoutFeedbackDual2,
                PinMode.TurnoutFeedbackDual2)
        {
        }

        /// <summary>
        /// Use this mode to configure the given target.
        /// </summary>
        protected override void Configure(ConnectorConfig target, AddressList addresses)
        {
            for (int i = 0; i < 4; i++)
            {
                var pin = target.Pins[i];
                pin.Mode = GetPin(i);
                pin.Address = addresses[i];

                pin = target.Pins[4 + i];
                pin.Mode = GetPin(4 + i);
                pin.Address = addresses[i];
            }
        }
    }
}
