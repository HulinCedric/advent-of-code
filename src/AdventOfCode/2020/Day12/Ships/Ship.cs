using System;
using AdventOfCode._2020.Day12.NavigationInstructions;

namespace AdventOfCode._2020.Day12.Ships
{
    public abstract class Ship
    {
        protected Ship(int x, int y)
            => Position = new Position(x, y);

        protected Position Position { get; set; }

        public void Navigate(NavigationInstruction navigationInstruction)
            => navigationInstruction.Execute(this);

        public int GetManhattanDistance()
            => Math.Abs(Position.X) + Math.Abs(Position.Y);

        public void MoveForward(int unit)
            => Move(unit);

        public void MoveWest(int value)
            => Move(Direction.West, value);

        public void MoveEst(int value)
            => Move(Direction.East, value);

        public void MoveNorth(int value)
            => Move(Direction.North, value);

        public void MoveSouth(int value)
            => Move(Direction.South, value);

        public void TurnRight(int degree)
            => Turn(degree);

        public void TurnLeft(int degree)
            => Turn(360 - degree);

        protected abstract void Move(int unit);
        protected abstract void Move(Direction instructionDirection, int unit);
        protected abstract void Turn(int degree);
    }
}