using System;

// Абстрактный класс - Устройство
public abstract class Device
{
    // Абстрактные свойства
    public abstract string DeviceType { get; }
    public abstract bool IsPortable { get; }

    // Абстрактные методы
    public abstract void TurnOn();
    public abstract void TurnOff();
    public abstract string GetStatus();

    // Обычные свойства
    public string Brand { get; set; } = "";
    public string Model { get; set; } = "";
    public double Price { get; set; }

    // Обычный метод
    public void DisplayInfo()
    {
        Console.WriteLine($"Устройство: {Brand} {Model}");
        Console.WriteLine($"Тип: {DeviceType}, Портативное: {IsPortable}");
        Console.WriteLine($"Цена: {Price} руб.");
    }
}

// Производный класс - Смартфон
public class Smartphone : Device
{
    public override string DeviceType => "Смартфон";
    public override bool IsPortable => true;

    public int BatteryCapacity { get; set; } // mAh
    public bool Has5G { get; set; }

    public override void TurnOn()
    {
        Console.WriteLine($"{Brand} {Model}: Загрузка системы...");
    }

    public override void TurnOff()
    {
        Console.WriteLine($"{Brand} {Model}: Выключение...");
    }

    public override string GetStatus()
    {
        return $"Смартфон {Brand} {Model}, Батарея: {BatteryCapacity}mAh, 5G: {Has5G}";
    }

    public void MakeCall(string number)
    {
        Console.WriteLine($"Звонок на номер {number}...");
    }
}

// Производный класс - Ноутбук
public class Laptop : Device
{
    public override string DeviceType => "Ноутбук";
    public override bool IsPortable => true;

    public string Processor { get; set; } = "";
    public int RAM { get; set; } // GB

    public override void TurnOn()
    {
        Console.WriteLine($"{Brand} {Model}: Загрузка Windows...");
    }

    public override void TurnOff()
    {
        Console.WriteLine($"{Brand} {Model}: Сохранение данных и выключение...");
    }

    public override string GetStatus()
    {
        return $"Ноутбук {Brand} {Model}, Процессор: {Processor}, ОЗУ: {RAM}GB";
    }

    public void RunProgram(string programName)
    {
        Console.WriteLine($"Запуск программы: {programName}");
    }
}

// Производный класс - Холодильник
public class Refrigerator : Device
{
    public override string DeviceType => "Холодильник";
    public override bool IsPortable => false;

    public double Volume { get; set; } // литры
    public bool HasFreezer { get; set; }

    public override void TurnOn()
    {
        Console.WriteLine($"{Brand} {Model}: Включение компрессора...");
    }

    public override void TurnOff()
    {
        Console.WriteLine($"{Brand} {Model}: Отключение от сети...");
    }

    public override string GetStatus()
    {
        return $"Холодильник {Brand} {Model}, Объем: {Volume}л, Морозилка: {HasFreezer}";
    }

    public void SetTemperature(int temperature)
    {
        Console.WriteLine($"Установлена температура: {temperature}°C");
    }
}

class Program
{
    // Функция с аргументом типа абстрактного класса
    static void TestDevice(Device device)
    {
        Console.WriteLine("\n=== Тестирование устройства ===");
        device.DisplayInfo();

        // Вызов абстрактных методов
        device.TurnOn();
        Console.WriteLine($"Статус: {device.GetStatus()}");
        device.TurnOff();

        // Проверка типа и вызов специфичных методов
        if (device is Smartphone phone)
        {
            phone.MakeCall("+79001234567");
        }
        else if (device is Laptop laptop)
        {
            laptop.RunProgram("Visual Studio");
        }
        else if (device is Refrigerator fridge)
        {
            fridge.SetTemperature(-5);
        }

        Console.WriteLine("=== Тестирование завершено ===\n");
    }

    static void Main()
    {
        Console.WriteLine("ЛАБОРАТОРНАЯ РАБОТА №8 - АБСТРАКТНЫЕ КЛАССЫ\n");

        // Создание экземпляров производных классов
        var smartphone = new Smartphone
        {
            Brand = "Apple",
            Model = "iPhone 15",
            Price = 89990,
            BatteryCapacity = 3500,
            Has5G = true
        };

        var laptop = new Laptop
        {
            Brand = "Dell",
            Model = "XPS 15",
            Price = 129990,
            Processor = "Intel i7",
            RAM = 16
        };

        var refrigerator = new Refrigerator
        {
            Brand = "Bosch",
            Model = "KGN39",
            Price = 54990,
            Volume = 350,
            HasFreezer = true
        };

        // Вызов функции с разными экземплярами
        TestDevice(smartphone);
        TestDevice(laptop);
        TestDevice(refrigerator);

        // Дополнительный тест через массив
        Console.WriteLine("\nТестирование через массив устройств:");
        Device[] devices = { smartphone, laptop, refrigerator };

        foreach (var device in devices)
        {
            Console.WriteLine($"- {device.GetStatus()}");
        }

        Console.WriteLine($"\nВсего устройств: {devices.Length}");
    }
}