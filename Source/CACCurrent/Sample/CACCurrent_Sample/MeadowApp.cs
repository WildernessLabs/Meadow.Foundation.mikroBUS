﻿using Meadow;
using Meadow.Devices;
using Meadow.Foundation.mikroBUS.Sensors;
using System;

namespace CACCurrent_Sample
{
    // Change F7FeatherV2 to F7FeatherV1 for V1.x boards
    public class MeadowApp : App<F7FeatherV2>
    {
        //<!=SNIP=>

        CACCurrent currenClick;

        public MeadowApp()
        {
            Console.WriteLine("Initializing ...");

        }

        //<!=SNOP=>
    }
}