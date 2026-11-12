using GitDemoApp;
using System;

Console.WriteLine("Версия 2.0: Привет, Git!");
Console.WriteLine("*****************************************************");
Console.WriteLine("Версия 1.0: Привет, Git!");
Console.WriteLine("*****************************************************");
Console.WriteLine("Это демонстрационная программа для практической работы.");
Console.WriteLine("\n--- Тестирование миссии ---");

Drone myDrone = new Drone();
myDrone.BatteryLevel = 80;

Mission myMission = new Mission("патрулирование границы", myDrone, 100);
myMission.Start();