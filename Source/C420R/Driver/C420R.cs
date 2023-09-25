﻿using Meadow.Foundation.ICs.IOExpanders;
using Meadow.Hardware;
using Meadow.Units;
using System;
using System.Threading.Tasks;

namespace Meadow.Foundation.mikroBUS.Sensors
{
    /// <summary>
    /// Represents a mikroBUS 4-20mA receiver Click board
    /// </summary>
    public class C420R
    {
        private IAnalogInputPort _adc;

        /// <summary>
        /// Reference voltage (2.048V)
        /// </summary>
        public Voltage ReferenceVoltage { get; protected set; } = new Voltage(2.048, Voltage.UnitType.Volts);

        private readonly Mcp3201 mcp3201;

        /// <summary>
        /// Creates a new C420R object using the SPI bus for readings
        /// </summary>
        /// <param name="spiBus">The SPI bus</param>
        /// <param name="chipSelectPin">Chip select pin</param>
        /// <param name="sampleCount">How many samples to take during a given reading (default is 5)</param>
        /// <param name="sampleInterval">The time between sample readings (default is 5 seconds)</param>
        public C420R(ISpiBus spiBus,
            IPin chipSelectPin,
            int sampleCount = 5,
            TimeSpan? sampleInterval = null)
        {
            mcp3201 = new Mcp3201(spiBus, chipSelectPin);
            InitializeMcp(sampleCount, sampleInterval);
        }

        /// <summary>
        /// Creates a new C420R object using the SPI bus for readings
        /// </summary>
        /// <param name="spiBus">The SPI bus</param>
        /// <param name="chipSelectPort">Chip select port</param>
        /// <param name="sampleCount">How many samples to take during a given reading (default is 5)</param>
        /// <param name="sampleInterval">The time between sample readings (default is 5 seconds)</param>
        public C420R(ISpiBus spiBus,
            IDigitalOutputPort chipSelectPort,
            int sampleCount = 5,
            TimeSpan? sampleInterval = null)
        {
            mcp3201 = new Mcp3201(spiBus, chipSelectPort);
            InitializeMcp(sampleCount, sampleInterval);
        }

        public async Task<Current> Read()
        {
            var volts = await _adc.Read();
            return new Current(volts.Volts / 200d);
        }

        private void InitializeMcp(int sampleCount = 5, TimeSpan? sampleInterval = null)
        {
            _adc = mcp3201.CreateAnalogInputPort(sampleCount, sampleInterval ?? TimeSpan.FromSeconds(5), ReferenceVoltage);
        }
    }
}