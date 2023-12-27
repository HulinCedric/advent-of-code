using FluentAssertions;
using Xunit;

namespace AdventOfCode._2023.Day15;

public class LensLibraryShould
{
    [Theory]
    [InlineData("rn=1", 0)]
    [InlineData("cm-", 0)]
    [InlineData("qp=3", 1)]
    [InlineData("cm=2", 0)]
    [InlineData("qp-", 1)]
    [InlineData("pc=4", 3)]
    [InlineData("ot=9", 3)]
    public void Should_determine_box_number_for_initialization_step(string initializationStep, int result)
        => PuzzleShould.BoxNumber(InitializationStep.Parse(initializationStep)).Should().Be(result);
}