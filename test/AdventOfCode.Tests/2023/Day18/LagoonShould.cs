using FluentAssertions;
using Xunit;
using static AdventOfCode._2023.Day18.DigPlanParser;

namespace AdventOfCode._2023.Day18;

public class LagoonShould
{
    [Theory]
    [InputFileData("2023/Day18/sample.txt", 38)]
    public void BoundaryPoints(string digPlan, long result)
        => Parse(digPlan, DigInstructionDigitParser.Parse)
            .Dig()
            .BoundaryPoints()
            .Should()
            .Be(result);

    [Theory]
    [InputFileData("2023/Day18/sample.txt", 24)]
    public void InteriorPoints(string digPlan, long result)
        => Parse(digPlan, DigInstructionDigitParser.Parse)
            .Dig()
            .InteriorPoints()
            .Should()
            .Be(result);

    [Theory]
    [InputFileData("2023/Day18/sample.txt", 62)]
    public void Area(string digPlan, long result)
        => Parse(digPlan, DigInstructionDigitParser.Parse)
            .Dig()
            .Area()
            .Should()
            .Be(result);
}