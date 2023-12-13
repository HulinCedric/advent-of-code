using System.Collections.Generic;

namespace AdventOfCode._2023.Day08;

public static class MapParser
{
    public static (char[] instructions, Dictionary<string, (string, string)> network) Parse(string mapDocument)
    {
        var lines = mapDocument.Split('\n');
        var instructions = lines[0].ToCharArray();

        var network = new Dictionary<string, (string, string)>();
        foreach (var line in lines[2..])
        {
            var node = line[..3];
            var left = line[7..10];
            var right = line[12..15];
            network.Add(node, (left, right));
        }

        return (instructions, network);
    }
}