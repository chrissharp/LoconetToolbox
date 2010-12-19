using System.Collections.Generic;

namespace LocoNetToolBox.Devices.LocoIO
{
    partial class ConnectorMode
    {
        private static readonly ConnectorMode[] Modes = new ConnectorMode[]
        {
            new ConnectorModes.None(), 
            new ConnectorModes.Mgv93(), 
            new ConnectorModes.Mgv136(), 
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
