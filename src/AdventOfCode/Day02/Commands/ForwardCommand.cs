namespace AdventOfCode.Day02.Commands
{
    public record ForwardCommand(int Unit) : SubmarineCommand(Unit)
    {
        public override Position ExecuteFor(Position position)
            => position with { Horizontal = position.Horizontal + Unit };
    }
}