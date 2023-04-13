using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace TestTaskCars
{
    public class Program
    {
        private static void Main(string[] args)
        {
            #region Data

            IDataCreator dataCreator = new DataCreator();
            ConcurrentQueue<Player> freePlayers = new ConcurrentQueue<Player>();
            BlockingCollection<Car> freeCars = new BlockingCollection<Car>();
            ConcurrentBag<Car> filledCars = new ConcurrentBag<Car>();
            const int playersAmount = 1000;
            const int carsAmount = 200;
            int maxXY = 100;
            float radius = 15;
            int amountRandomCars = 5;

            #endregion


            Task FillCarsTask = new Task(FillCars);
            FillCarsTask.Start();
            
            freePlayers = dataCreator.InitPlayers(playersAmount);
            dataCreator.InitCars(carsAmount, maxXY, ref freeCars);

            try
            {
                FillCarsTask.Wait();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                FillCarsTask.Dispose();
            }


            Tools.WriteRandomCars(filledCars, amountRandomCars);

            Tools.WritePlayersInRange(filledCars, radius);


            void FillCars()
            {
                Car car;
                while (!freeCars.IsCompleted)
                {
                    if (freeCars.TryTake(out car))
                    {
                        if (freePlayers.Count == 0)
                        {
                            Console.WriteLine("Not all cars with players\n");
                            break;
                        }

                        if (freePlayers.TryDequeue(out Player driver))
                        {
                            car.SetDriver(driver);
                        }
                        Player[] passengers = new Player[car.Passengers.Length];
                        for (int i = 0; i < passengers.Length; i++)
                        {
                            if (freePlayers.Count == 0)
                                break;
                        
                            if (freePlayers.TryDequeue(out Player passenger))
                            {
                                passengers[i] = passenger;
                            }
                        }

                        car.SetPassengers(passengers);
                        filledCars.Add(car);
                    }
                }
            }

            Console.WriteLine("End!");
        }
    }
}