namespace TestTaskCars
{
    public class Player
    {
        private string _nickname;
        private Position _position;

        public string Nickname => _nickname;

        public Player(string name, Position position)
        {
            _nickname = name;
            _position = position;
        }

        public void SetPosition(Position position) =>
            _position = position;
    }
}