namespace AdventOfCode._2020.Day12.Ships
{
    public class Waypoint
    {
        public Waypoint(int x, int y)
            => Position = new Position(x, y);

        public Position Position { get; private set; }

        internal void Move(Direction instructionDirection, int unit)
            => Position = instructionDirection switch
            {
                Direction.North => Position with
                {
                    Y = Position.Y + unit
                },
                Direction.East => Position with
                {
                    X = Position.X + unit
                },
                Direction.South => Position with
                {
                    Y = Position.Y - unit
                },
                Direction.West => Position with
                {
                    X = Position.X - unit
                },
                _ => Position
            };

        internal void Turn(int degree)
            => Position = degree switch
            {
                90 => Position with
                {
                    X = Position.Y,
                    Y = -Position.X
                },
                180 => Position with
                {
                    X = -Position.X,
                    Y = -Position.Y
                },
                270 => Position with
                {
                    X = -Position.Y,
                    Y = Position.X
                },

                _ => Position
            };
    }
}