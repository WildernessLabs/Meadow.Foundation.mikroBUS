# Meadow.Foundation.mikroBUS.Sensors.Buttons.CButton

**MikroElectronika PWM GPIO Led Button MikroBus click board**

The **CButton** library is designed for the [Wilderness Labs](www.wildernesslabs.co) Meadow .NET IoT platform and is part of [Meadow.Foundation](https://developer.wildernesslabs.co/Meadow/Meadow.Foundation/)

The **Meadow.Foundation** peripherals library is an open-source repository of drivers and libraries that streamline and simplify adding hardware to your C# .NET Meadow IoT application.

For more information on developing for Meadow, visit [developer.wildernesslabs.co](http://developer.wildernesslabs.co/), to view all of Wilderness Labs open-source projects, including samples, visit [github.com/wildernesslabs](https://github.com/wildernesslabs/)

## Usage

```
CButton ledButton;

public MeadowApp()
{
    Console.WriteLine("Initializing ...");

    ledButton = new CButton(Device.Pins.D03, Device.Pins.D04);

    ledButton.StartPulse(TimeSpan.FromSeconds(2), 0.75f, 0);
    ledButton.Clicked += (s, e) =>
    {
        Console.WriteLine("Button clicked");
        ledButton.IsOn = !ledButton.IsOn;
    };
}

        
```

