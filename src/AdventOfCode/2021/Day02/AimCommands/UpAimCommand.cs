namespace AdventOfCode._2021.Day02.AimCommands
{
    public record UpAimCommand(int Unit) : SubmarineAimCommand(Unit)
    {
        public override (Position, Aim) ExecuteFor(Submarine submarine)
            => (submarine.Position,
                submarine.Aim with { Value = submarine.Aim.Value - Unit });
    }
}