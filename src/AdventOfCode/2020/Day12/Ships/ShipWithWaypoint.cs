namespace AdventOfCode._2020.Day12.Ships
{
    public class ShipWithWaypoint
        : Ship
    {
        private readonly Waypoint waypoint;

        public ShipWithWaypoint(Waypoint waypoint, int x, int y)
            : base(x, y)
            => this.waypoint = waypoint;

        protected override void Move(int unit)
            => Position = new Position(
                Position.X + waypoint.Position.X * unit,
                Position.Y + waypoint.Position.Y * unit);

        protected override void Move(Direction instructionDirection, int unit)
            => waypoint.Move(instructionDirection, unit);

        protected override void Turn(int degree)
            => waypoint.Turn(degree);
    }
}