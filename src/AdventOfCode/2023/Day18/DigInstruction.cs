namespace AdventOfCode._2023.Day18;

public readonly record struct DigInstruction(Direction Direction, long Distance)
{
    public DigStep Execute()
    {
        var digStep = Direction * Distance;
        return new DigStep(digStep.X, digStep.Y);
    }
}