namespace AdventOfCode.Day02.Commands
{
    public record DownCommand(int Unit) : SubmarineCommand(Unit)
    {
        public override Position ExecuteFor(Position position)
            => position with { Depth = position.Depth + Unit };
    }
}