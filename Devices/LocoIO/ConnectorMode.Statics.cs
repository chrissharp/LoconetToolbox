using System.Collections.Generic;

namespace LocoNetToolBox.Devices.LocoIO
{
    partial class ConnectorMode
    {
        public static readonly ConnectorMode None = new ConnectorModes.None();
        public static readonly ConnectorMode Mgv93 = new ConnectorModes.Mgv93();
        public static readonly ConnectorMode Mgv136 = new ConnectorModes.Mgv136();

        private static readonly ConnectorMode[] Modes = new[]
        {
            None, 
            Mgv93, 
            Mgv136, 
            new ConnectorModes.Mgv81V1(), 
        };

        /// <summary>
        /// Gets all connector modes
        /// </summary>
        public static IEnumerable<ConnectorMode> All
        {
            get { return Modes; }
        }
    }
}
