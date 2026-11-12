using System;
using System.Collections.Generic;
using System.Text;

namespace GitDemoApp
{
    internal class Drone
    {
        public int BatteryLevel { get; set; } = 100;
        public bool IsEngineon { get; set; } = true;
        public double Altitude { get; set; } = 0;
        private const int BatteryConsumptionPerMinute = 2;

        public int CalculateFlightTime()
        {
            if (!IsEngineon)
            {
                Console.WriteLine("Двигатель выключен. Время полета не может быть рассчиано.");
                return 0;
            }
            return BatteryLevel / BatteryConsumptionPerMinute;
        }

        public void TakeOff()
        {
            Console.WriteLine("Дрон взлетает...");
            Altitude = 50;
        }

        public Drone() { }

        public void ChargBattery(int amount)
        {
            BatteryLevel += amount;
            if (BatteryLevel > 100)  BatteryLevel = 100;
            Console.WriteLine($"Дрон заряжен. текущий заряд: {BatteryLevel} %");
        }

    }
}
