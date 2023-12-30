using FluentAssertions;
using Xunit;

namespace AdventOfCode._2023.Day18;

public class DigitInstructionParserShould
{
    [Theory]
    [InlineData("L 2 (#5713f0)")]
    public void Parse_from_digit(string digInstruction)
        => DigInstructionDigitParser.Parse(digInstruction)
            .Should()
            .Be(new DigInstruction(Direction.Left, 2));

    [Theory]
    [InlineData("L 2 (#5713f0)")]
    public void Parse_from_hexadecimal(string digInstruction)
        => DigInstructionHexadecimalParser.Parse(digInstruction)
            .Should()
            .Be(new DigInstruction(Direction.Right, 356671));
}