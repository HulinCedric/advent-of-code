using System.Linq;
using FluentAssertions;
using Xunit;
using _ = AdventOfCode._2023.Day09.StepPredictionExtensions;

namespace AdventOfCode._2023.Day09;

public class PuzzleTest
{
    [Theory]
    [InputFileData("2023/Day09/sample.txt", 114)]
    [InputFileData("2023/Day09/input.txt", 1992273652)]
    public void Sum_of_extrapolated_values(string report, int sum)
        => report
            .ParseReport()
            .Select(_.ExtrapolateNextStep)
            .Sum()
            .Should()
            .Be(sum);

    [Theory]
    [InputFileData("2023/Day09/sample.txt")]
    public void Parse_report(string report)
        => report.ParseReport()
            .Should()
            .BeEquivalentTo(
                new[]
                {
                    new[] { 0, 3, 6, 9, 12, 15 },
                    new[] { 1, 3, 6, 10, 15, 21 },
                    new[] { 10, 13, 16, 21, 30, 45 }
                });

    [Theory]
    [InlineData(new[] { 1, 3, 6, 10, 15, 21 }, new[] { 2, 3, 4, 5, 6 })]
    [InlineData(new[] { 2, 3, 4, 5, 6 }, new[] { 1, 1, 1, 1 })]
    [InlineData(new[] { 1, 1, 1, 1 }, new[] { 0, 0, 0 })]
    [InlineData(new[] { 0, 0, 0 }, new[] { 0, 0 })]
    [InlineData(new[] { 0, 0 }, new[] { 0 })]
    [InlineData(new[] { 0 }, new int[] { })]
    [InlineData(new int[] { }, new int[] { })]
    public void Get_differences_between_steps(int[] steps, int[] differences)
        => steps.Differences().Should().BeEquivalentTo(differences);

    [Theory]
    [InlineData(new[] { 0, 0, 0 }, 0)]
    [InlineData(new[] { 1, 1, 1, 1 }, 1)]
    [InlineData(new[] { 2, 3, 4, 5, 6 }, 7)]
    [InlineData(new[] { 0, 3, 6, 9, 12, 15 }, 18)]
    [InlineData(new[] { 1, 3, 6, 10, 15, 21 }, 28)]
    [InlineData(new[] { 10, 13, 16, 21, 30, 45 }, 68)]
    public void Extrapolate_next_step(int[] steps, int nextStep)
        => steps.ExtrapolateNextStep().Should().Be(nextStep);

    [Theory]
    [InlineData(new[] { 0, 0, 0 }, 0)]
    [InlineData(new[] { 1, 1, 1, 1 }, 1)]
    [InlineData(new[] { 6, 5, 4, 3, 2 }, 1)]
    [InlineData(new[] { 15, 12, 9, 6, 3, 0 }, -3)]
    [InlineData(new[] { 21, 15, 10, 6, 3, 1 }, 0)]
    [InlineData(new[] { 45, 30, 21, 16, 13, 10 }, 5)]
    public void Extrapolate_previous_step_is_extrapolate_next_step_with_reverse_value(int[] steps, int nextStep)
        => steps.ExtrapolateNextStep().Should().Be(nextStep);
    
    
    [Theory]
    [InlineData(new[] { 0, 0, 0 }, 0)]
    [InlineData(new[] { 1, 1, 1, 1 }, 1)]
    [InlineData(new[] { 2, 3, 4, 5, 6 }, 1)]
    [InlineData(new[] { 0, 3, 6, 9, 12, 15 }, -3)]
    [InlineData(new[] { 1, 3, 6, 10, 15, 21 }, 0)]
    [InlineData(new[] { 10, 13, 16, 21, 30, 45 }, 5)]
    public void Extrapolate_previous_step(int[] steps, int nextStep)
        => steps.ExtrapolatePreviousStep().Should().Be(nextStep);
}