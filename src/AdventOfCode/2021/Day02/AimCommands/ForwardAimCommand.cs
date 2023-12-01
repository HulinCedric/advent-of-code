namespace AdventOfCode._2021.Day02.AimCommands
{
    public record ForwardAimCommand(int Unit) : SubmarineAimCommand(Unit)
    {
        public override (Position, Aim) ExecuteFor(Submarine submarine)
            => (submarine.Position with
                {
                    Horizontal = submarine.Position.Horizontal + Unit,
                    Depth = submarine.Position.Depth + submarine.Aim.Value * Unit
                },
                submarine.Aim);
    }
}