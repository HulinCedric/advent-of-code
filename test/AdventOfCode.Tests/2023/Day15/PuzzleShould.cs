using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;
using static AdventOfCode._2023.Day15.InitializationSequence;

namespace AdventOfCode._2023.Day15;

public class PuzzleShould
{
    [Theory]
    [InputFileData("2023/Day15/sample.txt", 1_320)]
    [InputFileData("2023/Day15/input.txt", 520_500)]
    public void Sum_of_the_results(string initializationSequence, int result)
        => Parse(initializationSequence)
            .Select(step => step.Hash())
            .Sum()
            .Should()
            .Be(result);
}