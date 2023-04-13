using System;
using System.Collections.Concurrent;
using System.Threading;

namespace TestTaskCars
{
    public class DataCreator: IDataCreator
    {
        public ConcurrentQueue<Player> InitPlayers(int playersAmount)
        {
            ConcurrentQueue<Player> freePlayers = new ConcurrentQueue<Player>();
            for (int i = 0; i < playersAmount; i++)
            {
                Position position = new Position(0, 0);
                Player newPlayer = new Player($"matreshka{i}", position);
                freePlayers.Enqueue(newPlayer);
            }

            return freePlayers;
        }

        public void InitCars(int carsAmount, int maxXY, ref BlockingCollection<Car> cars)
        {
            for (int i = 0; i < carsAmount; i++)
            {
                int x = i / maxXY;
                int y = i % maxXY;

                Position position = new Position(x, y);
                Car newCar = new Car($"car {i}", position);
                cars.Add(newCar);
            }
            cars.CompleteAdding();
        }
    }
}