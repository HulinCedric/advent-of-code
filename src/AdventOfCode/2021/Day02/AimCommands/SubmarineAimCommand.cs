namespace AdventOfCode._2021.Day02.AimCommands
{
    public abstract record SubmarineAimCommand(int Unit)
    {
        public abstract (Position, Aim) ExecuteFor(Submarine submarine);
    }
}