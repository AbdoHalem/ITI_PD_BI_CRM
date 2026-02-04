using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    internal class Task7
    {
        public class TemperatureSensor
        {
            // Declare Delegate
            public delegate void TemperatureHandler(string msg, double temp);
            // Declare Events (make event nullable to fix CS8618)
            public event TemperatureHandler? TemperatureHigh;
            public void SetTemperature(double temp)
            {
                if (temp > 30)
                {
                    if (TemperatureHigh != null)
                        TemperatureHigh("Warning!", temp);
                }
            }
        }
        public class TemperatureMonitor
        {
            public static void OnHighTemperature(string msg, double temp)
            {
                Console.WriteLine($"Alert: {temp}°C - {msg}");
            }
        }
        // ==================================================
        public static void task7()
        {
            
            TemperatureSensor sensor = new TemperatureSensor();
            // 1. Listener subscribes:
            sensor.TemperatureHigh += TemperatureMonitor.OnHighTemperature;
            // 2. Something happens:
            sensor.SetTemperature(35);
        }
    }
}
