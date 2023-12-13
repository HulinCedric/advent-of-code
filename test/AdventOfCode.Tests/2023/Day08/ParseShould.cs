using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace AdventOfCode._2023.Day08;

public class ParseShould
{
    [Theory]
    [InputFileData("2023/Day08/sample1.txt")]
    public void ParseTest(string mapDocument)
    {
        // Arrange
        char[] expectedInstructions = { 'R', 'L' };
        var expectedNetwork = new Dictionary<string, (string, string)>
        {
            { "AAA", ("BBB", "CCC") },
            { "BBB", ("DDD", "EEE") },
            { "CCC", ("ZZZ", "GGG") },
            { "DDD", ("DDD", "DDD") },
            { "EEE", ("EEE", "EEE") },
            { "GGG", ("GGG", "GGG") },
            { "ZZZ", ("ZZZ", "ZZZ") }
        };

        // Act
        var (instructions, network) = Parse(mapDocument);

        // Assert
        instructions.Should().BeEquivalentTo(expectedInstructions);
        network.Should().BeEquivalentTo(expectedNetwork);
    }

    private (char[] instructions, Dictionary<string, (string, string)> network) Parse(string mapDocument)
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