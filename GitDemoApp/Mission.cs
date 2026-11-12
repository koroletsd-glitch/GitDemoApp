using System;
using System.Collections.Generic;
using System.Text;

namespace GitDemoApp
{
    internal class Mission
    {
        public string Name { get; set; }
        public Drone  AssignedDrone { get; set; }
        public double TargetaAtitude { get; set; }

        public Mission(string name, Drone assignedDrone, double targetaAtitude)
        {
            Name = name;
            AssignedDrone = assignedDrone;
            TargetaAtitude = targetaAtitude;
        }

        public void Start()
        {
            Console.WriteLine($"\nМиссия \"{Name}\" начата. Целевая высота: {TargetaAtitude} м.");
            AssignedDrone.TakeOff();

            if (AssignedDrone.Altitude < TargetaAtitude)
            {
                Console.WriteLine("Дрон не достиг целевой высоты.");
            }
            else
            {
                Console.WriteLine("Целевая высота достигнута.");
            }
        }
    }
}
