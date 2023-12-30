using FluentAssertions;
using Xunit;
using static AdventOfCode._2023.Day18.DigPlanParser;

namespace AdventOfCode._2023.Day18;

public class PuzzleShould
{
    [Theory]
    [InputFileData("2023/Day18/sample.txt", 62)]
    [InputFileData("2023/Day18/input.txt", 52_035)]
    public void Provide_lagoon_cubic_meters_dig_with_digit_dig_plan(string digPlan, long result)
        => Parse(digPlan, DigInstructionDigitParser.Parse)
            .Dig()
            .Area()
            .Should()
            .Be(result);

    [Theory]
    [InputFileData("2023/Day18/sample.txt", 95_24_081_441_15)]
    [InputFileData("2023/Day18/input.txt", 60_612_092_439_765)]
    public void Provide_lagoon_cubic_meters_dig_with_hexadecimal_dig_plan(string digPlan, long result)
        => Parse(digPlan, DigInstructionHexadecimalParser.Parse)
            .Dig()
            .Area()
            .Should()
            .Be(result);
}