using GitDemoApp;
using System;
using System.Text.Json;

Drone[] drones = new Drone[3];
drones[0] = new Drone { BatteryLevel = 100, IsEngineon = false };
drones[1] = new Drone { BatteryLevel = 50, IsEngineon = false };
drones[2] = new Drone { BatteryLevel = 20, IsEngineon = false };

string fileName = "drones.json";

while (true)
{
    Console.WriteLine("\n===Система управления БПЛА (версия 3.0)===");
    Console.WriteLine("1. Показать информацию о всех дронах");
    Console.WriteLine("2. Взлет выбранного дрона");
    Console.WriteLine("3. Подзарядка выбранного дрона");
    Console.WriteLine("4. Расчет времени полета");
    Console.WriteLine("5. Сохранить состояние в файл");
    Console.WriteLine("6. Загрузить состояние из файла");
    Console.WriteLine("0. Выход");
    Console.WriteLine("выберите действие: ");

    string input = Console.ReadLine();
    if (!int.TryParse(input, out int choice))
    {
        Console.WriteLine("Ошибка: введите число.");
        continue;
    }
    if (choice == 0) break;

    switch (choice)
    {
        case 1:
            for (int i = 0; i < drones.Length; i++)
                Console.WriteLine($"Дрон #{i}: Заряд{drones[i].BatteryLevel}%, Высота{drones[i].Altitude}м");
            break;  
    
    case 2:
    case 3:
    case 4:
        Console.WriteLine("Введите индекс дрона (0, 1 или 2): ");
        if (!int.TryParse(Console.ReadLine(), out int index) || index < 0 || index >= drones.Length)
        {
            Console.WriteLine("ошибка: неверный индекс.");
            break;
        }
        if (choice == 2)
            drones[index].TakeOff();
        else if (choice == 3)
            drones[index].ChargBattery(30);
        else if (choice == 4)
            Console.WriteLine($"Время полета: {drones[index].CalculateFlightTime()}мин.");
        break;
    case 5:
        SaveDrones(drones, fileName);
        break;
    case 6:
        drones = LoadDrones(fileName);
        Console.WriteLine("Состояние загружено.");
        break;

    default:
        Console.WriteLine("Неизвестная команда.");
        break;
    }
}

//Вспомогательные методы
static void SaveDrones(Drone[] drones, string fileName)
{
    var options =new JsonSerializerOptions
    { WriteIndented = true };
    string jsonString = JsonSerializer.Serialize(drones, options);
    File.WriteAllText(fileName, jsonString);
    Console.WriteLine($"Состояние сохранено в файл {fileName}");
}

static Drone[] LoadDrones(string fileName)
{
    if (!File.Exists(fileName))
    {
        Console.WriteLine("Файл не найден. Будет создан новый массив.");
        return new Drone[3];
    }
    string jsonString = File.ReadAllText(fileName);
    Drone[]? loaderDrones = JsonSerializer.Deserialize<Drone[]>(jsonString);
    return loaderDrones ?? new Drone[3];
}