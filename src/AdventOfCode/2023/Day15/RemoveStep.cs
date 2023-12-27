namespace AdventOfCode._2023.Day15;

internal record RemoveStep(string Label) : Step(Label)
{
    internal const char Operation = '-';

    public override void Execute(Box box)
        => box.RemoveLensWithLabel(Label);

    public override string ToString()
        => $"{Label}{Operation}";
}