namespace AdventOfCode._2023.Day15;

public record Step(string Label, char Operation, int? FocalLength)
{
    public static Step Parse(string initializationStep)
    {
        var parts = initializationStep.Split('=', '-');

        var label = parts[0];

        var isDash = parts[1] == "";
        char operation;
        int? focalLength;
        if (isDash)
        {
            operation = '-';
            focalLength = null;
        }
        else
        {
            operation = '=';
            focalLength = int.Parse(parts[1]);
        }

        return new Step(
            label,
            operation,
            focalLength);
    }

    public int Hash()
        => Hasher.Hash(ToString());
    
    public int BoxNumber()
        => Hasher.Hash(Label);

    public override string ToString()
        => $"{Label}{Operation}{FocalLength}";
}