namespace LocoNetToolBox.Devices.LocoIO.ConnectorModes
{
    /// <summary>
    /// Connector mode for an MGV93.
    /// </summary>
    public sealed class Mgv93 : ConnectorMode
    {
        /// <summary>
        /// Default ctor
        /// </summary>
        public Mgv93()
            : base("MGV93",
                8,
                PinMode.BlockActiveLowDelay,
                PinMode.BlockActiveLowDelay,
                PinMode.BlockActiveLowDelay,
                PinMode.BlockActiveLowDelay,
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
            for (int i = 0; i < 8; i++)
            {
                var pin = target.Pins[i];
                pin.Mode = GetPin(i);
                pin.Address = addresses[i];
            }
        }
    }
}
