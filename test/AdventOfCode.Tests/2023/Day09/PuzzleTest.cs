using FluentAssertions;
using Xunit;

namespace AdventOfCode._2023.Day09;

public class PuzzleTest
{
    [Theory]
    [InputFileData("2023/Day09/sample.txt")]
    public void Parse_report(string report)
        => report.ParseReport()
            .Should()
            .BeEquivalentTo(
                new[]
                {
                    new long[] { 0, 3, 6, 9, 12, 15 },
                    new long[] { 1, 3, 6, 10, 15, 21 },
                    new long[] { 10, 13, 16, 21, 30, 45 }
                });

    [Theory]
    [InlineData(new long[] { 1, 3, 6, 10, 15, 21 }, new long[] { 2, 3, 4, 5, 6 })]
    [InlineData(new long[] { 2, 3, 4, 5, 6 }, new long[] { 1, 1, 1, 1 })]
    [InlineData(new long[] { 1, 1, 1, 1 }, new long[] { 0, 0, 0 })]
    [InlineData(new long[] { 0, 0, 0 }, new long[] { 0, 0 })]
    [InlineData(new long[] { 0, 0 }, new long[] { 0 })]
    [InlineData(new long[] { 0 }, new long[] { })]
    [InlineData(new long[] { }, new long[] { })]
    public void Get_differences_between_steps(long[] steps, long[] differences)
        => steps.Differences().Should().BeEquivalentTo(differences);

    [Theory]
    [InlineData(new long[] { 0, 0, 0 }, 0)]
    [InlineData(new long[] { 1, 1, 1, 1 }, 1)]
    [InlineData(new long[] { 2, 3, 4, 5, 6 }, 7)]
    [InlineData(new long[] { 1, 3, 6, 10, 15, 21 }, 28)]
    public void Extrapolate_next_steps(long[] steps, long nextStep)
        => steps.ExtrapolateNextStep().Should().Be(nextStep);
}