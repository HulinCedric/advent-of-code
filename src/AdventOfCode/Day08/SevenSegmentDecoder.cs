using System.Linq;

namespace AdventOfCode.Day08;

public static class SevenSegmentDecoder
{
    public static int Decode(string input)
    {
        var parts = input.Split(" | ");
        var encodedOutput = parts[1].Split(' ');

        var digits = Digit.Parse(parts[0]);

        return int.Parse(
            string.Concat(
                encodedOutput
                    .Select(s => new SignalPattern(s))
                    .Select(signalPattern => digits.Single(d => d.SignalPattern == signalPattern).Value)));
    }
}