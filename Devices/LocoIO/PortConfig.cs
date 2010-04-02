using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LocoNetToolBox.Devices.LocoIO
{
    /// <summary>
    /// SV settings for a single port of a LocoIO module.
    /// </summary>
    public class PortConfig
    {
        /// <summary>
        /// Directions for a single port.
        /// </summary>
        public enum Directions { Input, Output };

        /// <summary>
        /// Various input types
        /// </summary>
        public enum InputTypes { None, Sensor, Button };

        /// <summary>
        /// Input message types.
        /// Direct=SW_REQ (0xB0)
        /// Indirect=SW_REP (0xB2)
        /// </summary>
        public enum InputMessages { Direct, Indirect };


        // Functional settings
        private Directions direction;
        private int address;

        // Output
        private bool lowAtStartup;
        private bool hardwareReset;
        private bool pulseContact;
        private bool flash;
        private bool multi;
        private bool blockDetector;
        // Input
        private bool activeLow;
        private bool delay;
        private InputMessages message;
        private InputTypes inputType;

        // SV values
        private byte config;
        private byte value1;
        private byte value2;


        /// <summary>
        /// Direction of the port.
        /// Input or Output.
        /// </summary>
        public Directions Direction
        {
            get { return direction; }
            set { direction = value; UpdateValues(); }
        }

        /// <summary>
        /// Loconet address of this port.
        /// </summary>
        public int Address
        {
            get { return address; }
            set { address = value; UpdateValues(); }
        }

        // Output settings

        public bool LowAtStartup
        {
            get { return lowAtStartup; }
            set { lowAtStartup = value; UpdateValues(); }
        }

        public bool HardwareReset
        {
            get { return hardwareReset; }
            set { hardwareReset = value; UpdateValues(); }
        }

        public bool PulseContact
        {
            get { return pulseContact; }
            set { pulseContact = value; UpdateValues(); }
        }

        public bool Flash
        {
            get { return flash; }
            set { flash = value; UpdateValues(); }
        }

        public bool Multi
        {
            get { return multi; }
            set { multi = value; UpdateValues(); }
        }

        public bool BlockDetector
        {
            get { return blockDetector; }
            set { blockDetector = value; UpdateValues(); }
        }

        public bool SensorContact { get; set; }

        // Input settings

        /// <summary>
        /// Input source is active low
        /// </summary>
        public bool ActiveLow
        {
            get { return activeLow; }
            set { activeLow = value; UpdateValues(); }
        }

        /// <summary>
        /// Switch off delay enabled?
        /// </summary>
        public bool Delay
        {
            get { return delay; }
            set { delay = value; UpdateValues(); }
        }

        /// <summary>
        /// Type of message send. 
        /// Direct (SW_REQ) or Indirect (SW_REP)
        /// </summary>
        public InputMessages InputMessage
        {
            get { return message; }
            set { message = value; UpdateValues(); }
        }

        /// <summary>
        /// Type of input source
        /// </summary>
        public InputTypes InputType
        {
            get { return inputType; }
            set { inputType = value; UpdateValues(); }
        }

        public bool SensorTurnout { get; set; }

        // SV values

        public byte Config
        {
            get { return config; }
            set { config = value; UpdateFunctionalSettings(); }
        }

        public byte Value1
        {
            get { return value1; }
            set { value1 = value; UpdateFunctionalSettings(); }
        }

        public byte Value2
        {
            get { return value2; }
            set { value2 = value; UpdateFunctionalSettings(); }
        }

        /// <summary>
        /// Update functional settings fom SV values
        /// </summary>
        private void UpdateFunctionalSettings()
        {
            // direction
            this.direction = ((config & 0x80) != 0) ? Directions.Output : Directions.Input;

            // Output
            this.lowAtStartup = (config & 0x01) != 0;
            this.hardwareReset = (config & 0x04) != 0;
            this.pulseContact = (config & 0x08) != 0;
            this.flash = (config & 0x10) != 0;
            this.multi = (config & 0x20) != 0;
            this.blockDetector = (config & 0x40) != 0;

            // Input
            this.activeLow = (config & 0x40) == 0;
            this.delay = (config & 0x04) == 0;
            this.message = ((config & 0x08) != 0) ? InputMessages.Direct : InputMessages.Indirect;
            if ((config & 0x10) != 0) { inputType = InputTypes.Sensor; }
            else if ((config & 0x20) != 0) { inputType = InputTypes.Button; }
            else { inputType = InputTypes.None; }

            if (direction == Directions.Output)
            {
                address = value1 + 1 + ((value2 & 0x0F) << 7);
            }
            else
            {
                address = (value1 << 1) + 1 + ((value2 & 0x0F) >> 8) + ((value2 & 0x20) >> 5);
            }
            
            SensorTurnout = ((value2 & 0x40) != 0);
            SensorContact = ((value2 & 0x20) != 0);
        }

        /// <summary>
        /// Calculate config, value1 and value2 from functional settings.
        /// </summary>
        private void UpdateValues()
        {
            if (direction == Directions.Output)
            {
                // Calculate output config value
                config = 0x80;
                config |= (byte)(lowAtStartup ? 0x01 : 0x00);
                config |= (byte)(hardwareReset ? 0x04 : 0x00);
                config |= (byte)(pulseContact ? 0x08 : 0x00);
                config |= (byte)(flash ? 0x10 : 0x00);
                config |= (byte)(multi ? 0x20 : 0x00);
                config |= (byte)(blockDetector ? 0x40 : 0x00);

                // Calculate val1
                value1 = (byte)((address - 1) & 0x7F);

                // Calculate val2
                value2 = (byte)(((address - 1) & 0x780) >> 7);
                value2 |= (byte)(SensorContact ? 0x20 : 0x00);
            }
            else
            {
                // Calculate input config value
                config = 0x03;
                config |= (byte)(activeLow ? 0x00 : 0x40);
                config |= (byte)(delay ? 0x00 : 0x04);
                config |= (byte)((message == InputMessages.Direct) ? 0x08 : 0x00);
                config |= (byte)((inputType == InputTypes.Sensor) ? 0x10 : 0x00);
                config |= (byte)((inputType == InputTypes.Button) ? 0x20 : 0x00);

                // Calculate val1
                value1 = (byte)(((address - 1) & 0xFF) >> 1);

                // Calculate val2
                value2 = (byte)(((address - 1) & 0xF00) >> 8);
                value2 |= (byte)((((address - 1) & 0x01) != 0) ? 0x20 : 0x00);
                value2 |= (byte)(SensorTurnout ? 0x40 : 0x00);
            }
        }
    }
}
