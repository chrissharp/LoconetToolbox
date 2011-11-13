namespace LocoNetToolBox.Devices.LocoIO.ConnectorModes
{
    /// <summary>
    /// Connector mode for an MGV133 with sensors connected to pin 1-4.
    /// </summary>
    public sealed class Mgv133LowPins : ConnectorMode
    {
        /// <summary>
        /// Default ctor
        /// </summary>
        public Mgv133LowPins()
            : base("MGV133 (pin 1-4)",
                4,
                new[] {
                    "Sensor 1",
                    "Sensor 2",
                    "Sensor 3",
                    "Sensor 4",
                },
                PinMode.BlockActiveLowDelay,
                PinMode.BlockActiveLowDelay,
                PinMode.BlockActiveLowDelay,
                PinMode.BlockActiveLowDelay)
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
            }
        }
    }
}
