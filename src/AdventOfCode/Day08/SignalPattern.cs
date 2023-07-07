namespace AdventOfCode.Day08;

public record SignalPattern
{
    public SignalPattern(string value)
        => Value = value.Sort();

    public string Value { get; }
}