using FluentAssertions;
using Xunit;

namespace AdventOfCode._2023.Day18;

public class DigInstructionShould
{
    [Theory]
    [InlineData("R 6 (#70c710)", 6, 0)]
    [InlineData("D 5 (#0dc571)", 0, 5)]
    [InlineData("L 2 (#5713f0)", -2, 0)]
    [InlineData("R 2 (#59c680)", 2, 0)]
    public void Provide_dig_step_in_plan_when_instruction_executed(string instruction, long x, long y)
        => DigInstructionDigitParser.Parse(instruction)
            .Execute()
            .Should()
            .Be(new DigStep(y, x));
}