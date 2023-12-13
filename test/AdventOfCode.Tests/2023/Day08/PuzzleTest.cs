using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace AdventOfCode._2023.Day08;

public class HauntedWastelandShould
{
    // new[] { 'R', 'L' }, instructions
    // new Dictionary<string, (string, string)> network
    // {
    //     { "AAA", ("BBB", "CCC") },
    //     { "BBB", ("DDD", "EEE") },
    //     { "CCC", ("ZZZ", "GGG") },
    //     { "DDD", ("DDD", "DDD") },
    //     { "EEE", ("EEE", "EEE") },
    //     { "GGG", ("GGG", "GGG") },
    //     { "ZZZ", ("ZZZ", "ZZZ") }
    // }, 

    [Theory]
    [InputFileData("2023/Day08/sample1.txt", 2)]
    //[InputFileData("2023/Day08/sample2.txt", 6)]
    public void ReachZZZInExpectedSteps(string mapDocument, int expectedSteps)
    {
        // Arrange
        var instructions = new[] { 'R', 'L' };
        var network = new Dictionary<string, (string, string)>
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
        var location = "AAA";
        var steps = 0;
        while (location != "ZZZ")
        {
            var (left, right) = network[location];
            location = instructions[steps % instructions.Length] == 'R' ? right : left;
            steps++;
        }
       
        // Assert
        steps.Should().Be(expectedSteps);
    }
}