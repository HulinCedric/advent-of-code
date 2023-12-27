using FluentAssertions;
using Xunit;
using static AdventOfCode._2023.Day15.Step;

namespace AdventOfCode._2023.Day15;

public class StepShould
{
    [Theory]
    [InlineData("rn=1", 30)]
    [InlineData("cm-", 253)]
    [InlineData("qp=3", 97)]
    public void Compute_hash(string step, int hashValue)
        => Parse(step)
            .Hash()
            .Should()
            .Be(hashValue);

    [Theory]
    [InlineData("rn=1", 0)]
    [InlineData("cm-", 0)]
    [InlineData("qp=3", 1)]
    [InlineData("cm=2", 0)]
    [InlineData("qp-", 1)]
    [InlineData("pc=4", 3)]
    [InlineData("ot=9", 3)]
    public void Compute_the_box_number(string step, int boxNumber)
        => Parse(step)
            .BoxNumber()
            .Should()
            .Be(boxNumber);
}