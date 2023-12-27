namespace AdventOfCode._2023.Day15;

public record Step
{
    public Step(string Label, char Operation)
    {
        this.Label = Label;
        this.Operation = Operation;
    }


    public string Label { get; init; }
    public char Operation { get; init; }

    public static Step Parse(string initializationStep)
    {
        var parts = initializationStep.Split('=', '-');

        var label = parts[0];
        var operation = parts[1] == "" ? '-' : '=';


        if (operation == '=')
        {
            return new AssignStep(label, operation, int.Parse(parts[1]));
        }

        return new RemoveStep(label, operation);
    }

    public int Hash()
        => Hasher.Hash(ToString());

    public int BoxNumber()
        => Hasher.Hash(Label);

    public override string ToString()
        => $"{Label}{Operation}";
}

internal record AssignStep : Step
{
    public AssignStep(string Label, char Operation, int FocalLength) : base(Label, Operation)
        => this.FocalLength = FocalLength;

    public int FocalLength { get; }

    public override string ToString()
        => $"{Label}{Operation}{FocalLength}";
}

internal record RemoveStep : Step
{
    public RemoveStep(string Label, char Operation) : base(Label, Operation)
    {
    }

    public override string ToString()
        => base.ToString();
}