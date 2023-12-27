using System.Linq;
using FluentAssertions;
using Xunit;

namespace AdventOfCode._2023.Day15;

public class PuzzleShould
{
    [Theory]
    [InputFileData("2023/Day15/sample.txt", 1_320)]
    [InputFileData("2023/Day15/input.txt", 520_500)]
    public void Sum_of_the_results(string initializationSequence, int result)
        => initializationSequence.Split(',').Select(Hasher.Hash).Sum().Should().Be(result);


    public static int BoxNumber(InitializationStep initializationStep)
        => Hasher.Hash(initializationStep.Label);
}