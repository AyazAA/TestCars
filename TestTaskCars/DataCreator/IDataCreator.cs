using System.Collections.Concurrent;

namespace TestTaskCars
{
    public interface IDataCreator
    {
        public ConcurrentQueue<Player> InitPlayers(int playersAmount);
        public void InitCars(int carsAmount, int maxXY, ref BlockingCollection<Car> cars);
    }
}