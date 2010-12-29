﻿using System.Collections;
using System.Collections.Generic;
using LocoNetToolBox.Devices.LocoIO;
using LocoNetToolBox.Protocol;

namespace LocoNetToolBox.Configuration
{
    /// <summary>
    /// List of loco IO configurations.
    /// </summary>
    public class LocoIOConfigMap : IEnumerable<LocoIOConfig>
    {
        private readonly Dictionary<LocoNetAddress, LocoIOConfig> locoIOs = new Dictionary<LocoNetAddress, LocoIOConfig>();

        /// <summary>
        /// Gets/sets a config by address.
        /// Returns null if not found.
        /// </summary>
        public LocoIOConfig this[LocoNetAddress index]
        {
            get
            {
                LocoIOConfig result;
                if (locoIOs.TryGetValue(index, out result))
                    return result;
                return null;
            }
            set
            {
                if (value == null)
                {
                    locoIOs.Remove(index);
                }
                else
                {
                    locoIOs[index] = value;
                }
            }
        }

        /// <summary>
        /// Does this list contain a config for the given address?
        /// </summary>
        public bool Contains(LocoNetAddress index)
        {
            return locoIOs.ContainsKey(index);
        }

        /// <summary>
        /// Remove a configuration by it's address.
        /// </summary>
        public bool Remove(LocoNetAddress index)
        {
            return locoIOs.Remove(index);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        public IEnumerator<LocoIOConfig> GetEnumerator()
        {
            return locoIOs.Values.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
