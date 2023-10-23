using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktika04
{
    internal class Exemple4
    {
        class Vehicle
        {
            public string Name { get; set; }
            public bool IsInRepair { get; set; }

            public Vehicle(string name)
            {
                Name = name;
                IsInRepair = false;
            }


            public void SetInRepair(bool isInRepair)
            {
                IsInRepair = isInRepair;
            }

        }

        class Driver
        {
            public string Name { get; set; }

            public Driver(string name)
            {
                Name = name;
            }


            public void RequestRepair(Vehicle vehicle)
            {
                if (vehicle != null)
                {
                    vehicle.SetInRepair(true);
                    Console.WriteLine($"{Name} запросил ремонт для {vehicle.Name}");
                }
                else
                {
                    Console.WriteLine($"{Name} не может запросить ремонт, так как у него нет автомобиля.");
                }
            }

        }

        class Dispatcher
        {
            public void AssignDriverAndVehicle(Driver driver, Vehicle vehicle)
            {
                if (driver != null && vehicle != null)
                {
                    Console.WriteLine($"Назначение {driver.Name} на {vehicle.Name}");
                }
                else
                {
                    Console.WriteLine("Невозможно назначить водителя и автомобиль.");
                }
            }

            public void SuspendDriver(Driver driver)
            {
                if (driver != null)
                {
                    Console.WriteLine($"{driver.Name} был отстранен от работы.");
                }
                else
                {
                    Console.WriteLine("Невозможно отстранить водителя, так как он не указан.");
                }
            }

            public void RecordTripCompletion(Driver driver, Vehicle vehicle)
            {
                if (driver != null && vehicle != null)
                {
                    Console.WriteLine($"{driver.Name} выполнил рейс на {vehicle.Name}");
                }
                else
                {
                    Console.WriteLine("Невозможно записать выполнение рейса, так как водитель или автомобиль не указаны.");
                }
            }
        }

        class Program
        {
            static void Main()
            {
                Driver driver1 = new Driver("Водитель 1");
                Driver driver2 = new Driver("Водитель 2");
                Vehicle vehicle1 = new Vehicle("Автомобиль 1");
                Vehicle vehicle2 = new Vehicle("Автомобиль 2");

                Dispatcher dispatcher = new Dispatcher();

                dispatcher.AssignDriverAndVehicle(driver1, vehicle1);
                dispatcher.AssignDriverAndVehicle(driver2, vehicle2);

                driver2.RequestRepair(vehicle2);

                dispatcher.RecordTripCompletion(driver1, vehicle1);

                dispatcher.SuspendDriver(driver2);

                Console.WriteLine("Состояние водителей и автомобилей:");
                Console.WriteLine($"{driver1.Name} - Работает");
                Console.WriteLine($"{driver2.Name} - Отстранен");
                Console.WriteLine($"{vehicle1.Name} - {(vehicle1.IsInRepair ? "На ремонте" : "Готов")}");
                Console.WriteLine($"{vehicle2.Name} - {(vehicle2.IsInRepair ? "На ремонте" : "Готов")}");
            }
        }
    }
}