namespace AdventOfCode._2023.Day15;

public record InitializationStep(string Label, char Operation, int? FocalLength)
{
    public static InitializationStep Parse(string initializationStep)
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

        return new InitializationStep(
            label,
            operation,
            focalLength);
    }
}