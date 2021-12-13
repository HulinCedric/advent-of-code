namespace AdventOfCode.Day02.Commands
{
    public record UpCommand(int Unit) : SubmarineCommand(Unit)
    {
        public override Position ExecuteFor(Position position)
            => position with { Depth = position.Depth - Unit };
    }
}