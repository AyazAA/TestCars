using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace TestTaskCars
{
    public static class Tools
    {
        private static readonly Random _random = new Random();
        
        public static void WritePlayersInRange(ConcurrentBag<Car> cars, float radius)
        {
            if (cars.Count == 0)
            {
                Console.WriteLine("Amount filled cars must be bigger 0 for write players in range\n");
                return;
            }
            
            int randomIndex = _random.Next(0, cars.Count);
            Car randomCar = cars.ElementAt(randomIndex);
            Console.WriteLine($"\nPlayers in radius({radius}) of {randomCar.Name} :\n");
            List<Car> carsInRange = cars.Where(x => x.Position.GetDistance(randomCar.Position) <= radius)
                .Where(x => x.Driver != null).ToList();
            if(carsInRange.Count == 0)
                Console.WriteLine("No players in range");
            foreach (Car car in carsInRange)
            {
                float distance = car.Position.GetDistance(randomCar.Position);
                Console.WriteLine($"{car.Driver.Nickname}:{distance}");
                foreach (Player passenger in car.Passengers)
                {
                    if (passenger == null)
                        break;
                    Console.WriteLine($"{passenger.Nickname}:{distance}");
                }
            }
        }

        public static void WriteRandomCars(ConcurrentBag<Car> cars, int amountRandomCars)
        {
            if (amountRandomCars > cars.Count)
            {
                Console.WriteLine("Amount filled cars must be bigger for random\n");
                return;
            }
            
            List<int> selectedCars = new List<int>();
            while (selectedCars.Count != amountRandomCars)
            {
                int index = _random.Next(0, cars.Count);
                if (!selectedCars.Exists(x => x == index)) 
                    selectedCars.Add(index);
            }

            Console.WriteLine($"{amountRandomCars} random cars: ");
            foreach (var index in selectedCars) 
                Console.WriteLine(cars.ElementAt(index).Name);
        }
    }
}