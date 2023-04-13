namespace TestTaskCars
{
    public class Car
    {
        private string _name;
        private Position _position;
        private Player _driver;
        private Player[] _passengers;
        private const byte MaxPassengersAmount = 3;

        public string Name => _name;
        public Position Position => _position;
        public Player Driver => _driver;
        public Player[] Passengers => _passengers;

        public Car(string name, Position position)
        {
            _name = name;
            _position = position;
            _passengers = new Player[MaxPassengersAmount];
        }


        public void SetDriver(Player driver)
        {
            _driver = driver;
            _driver.SetPosition(Position);
        }

        public void SetPassengers(Player[] passengers)
        {
            _passengers = passengers;
            foreach (Player passenger in _passengers)
                if (passenger != null)
                    passenger.SetPosition(Position);
        }
    }
}