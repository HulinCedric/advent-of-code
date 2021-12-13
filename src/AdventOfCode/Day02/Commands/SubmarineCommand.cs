namespace AdventOfCode.Day02.Commands
{
    public abstract record SubmarineCommand(int Unit)
    {
        public abstract Position ExecuteFor(Position position);
    }
}