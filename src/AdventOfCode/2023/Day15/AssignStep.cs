namespace AdventOfCode._2023.Day15;

internal record AssignStep(string Label, int FocalLength) : Step(Label)
{
    internal const char Operation = '=';

    public override void Execute(Box box)
        => box.Add(new Lens(Label, FocalLength));

    public override string ToString()
        => $"{Label}{Operation}{FocalLength}";
}