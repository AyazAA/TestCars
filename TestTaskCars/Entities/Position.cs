using System.Numerics;

namespace TestTaskCars
{
    public class Position
    {
        private readonly Vector2 _point;

        public Position(int x, int y)
        {
            _point.X = x;
            _point.Y = y;
        }

        public float GetDistance(Position secondPosition) =>
            Vector2.Distance(_point, secondPosition._point);
    }
}