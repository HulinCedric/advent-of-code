using System.Linq;

namespace AdventOfCode._2023.Day14;

public static class MapParser
{
    public static Map Parse(string mapInformation)
        => new(
            mapInformation
                .Split('\n')
                .Select(row => row.ToCharArray())
                .ToArray());
}