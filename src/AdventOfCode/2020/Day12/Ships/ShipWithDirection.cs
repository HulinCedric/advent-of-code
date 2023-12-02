using System;

namespace AdventOfCode._2020.Day12.Ships
{
    public class ShipWithDirection
        : Ship
    {
        private Direction direction;

        public ShipWithDirection(Direction direction, int x, int y)
            : base(x, y)
            => this.direction = direction;

        protected override void Move(int unit)
            => Move(direction, unit);

        protected override void Move(Direction instructionDirection, int unit)
            => Position = GetNewPosition(Position, instructionDirection, unit);

        protected override void Turn(int degree)
            => direction = GetNewDirection(direction, degree);

        private static Position GetNewPosition(
            Position initialPosition,
            Direction instructionDirection,
            int unit)
            => instructionDirection switch
            {
                Direction.North => initialPosition with
                {
                    X = initialPosition.X + unit
                },
                Direction.East => initialPosition with
                {
                    Y = initialPosition.Y + unit
                },
                Direction.South => initialPosition with
                {
                    X = initialPosition.X - unit
                },
                Direction.West => initialPosition with
                {
                    Y = initialPosition.Y - unit
                },
                _ => throw new ArgumentOutOfRangeException(nameof(instructionDirection))
            };

        private static Direction GetNewDirection(Direction initialDirection, int degree)
            => (degree, initialDirection) switch
            {
                (90, Direction.East) => Direction.South,
                (180, Direction.East) => Direction.West,
                (270, Direction.East) => Direction.North,

                (90, Direction.South) => Direction.West,
                (180, Direction.South) => Direction.North,
                (270, Direction.South) => Direction.East,

                (90, Direction.West) => Direction.North,
                (180, Direction.West) => Direction.East,
                (270, Direction.West) => Direction.South,

                (90, Direction.North) => Direction.East,
                (180, Direction.North) => Direction.South,
                (270, Direction.North) => Direction.West,

                _ => initialDirection
            };
    }
}