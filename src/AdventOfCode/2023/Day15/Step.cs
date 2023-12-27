using System;

namespace AdventOfCode._2023.Day15;

public abstract record Step(string Label)
{
    public static Step Parse(string initializationStep)
    {
        var parts = initializationStep.Split('=', '-');

        var label = parts[0];
        var operation = initializationStep[label.Length];

        return operation switch
        {
            AssignStep.Operation => new AssignStep(label, int.Parse(parts[1])),
            RemoveStep.Operation => new RemoveStep(label),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    public int Hash()
        => Hasher.Hash(ToString());

    public int BoxNumber()
        => Hasher.Hash(Label);

    public abstract void Execute(Box box);
}

internal record AssignStep(string Label, int FocalLength) : Step(Label)
{
    internal const char Operation = '=';

    public override void Execute(Box box)
        => box.Add(new Lens(Label, FocalLength));

    public override string ToString()
        => $"{Label}{Operation}{FocalLength}";
}

internal record RemoveStep(string Label) : Step(Label)
{
    internal const char Operation = '-';

    public override void Execute(Box box)
        => box.RemoveLensWithLabel(Label);

    public override string ToString()
        => $"{Label}{Operation}";
}