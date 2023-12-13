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
        var (instructions, network) = MapParser.Parse(mapDocument);

        // Assert
        instructions.Should().BeEquivalentTo(expectedInstructions);
        network.Should().BeEquivalentTo(expectedNetwork);
    }
}