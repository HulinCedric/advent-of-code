using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode._2023.Day06;

public static partial class RacesParser
{
    public static Race[] RacesParse(string racesInformation)
    {
        var part = racesInformation.Split('\n');

        var times = ParseNumbers(part[0]);
        var distances = ParseNumbers(part[1]);

        return times.Zip(distances, (time, distance) => new Race((int)time, distance)).ToArray();
    }

    public static string FixKerning(this string racesInformation)
        => racesInformation.Replace(" ", "");

    private static IEnumerable<long> ParseNumbers(string input)
        => Numbers().Matches(input).Select(m => long.Parse(m.Value));

    [GeneratedRegex(@"\d+")]
    private static partial Regex Numbers();
}