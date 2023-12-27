using System.Linq;
using FluentAssertions;
using Xunit;

namespace AdventOfCode._2023.Day15;

public class InitializationSequenceShould
{
    [Theory]
    [InlineData("rn=1,cm-,qp=3,cm=2,qp-,pc=4,ot=9,ab=5,pc-,pc=6,ot=7", 1_320)]
    public void Should_sum_whole_initialization_sequence_hash_steps(string initializationSequence, int result)
        => initializationSequence.Split(',').Select(Hasher.Hash).Sum().Should().Be(result);
}