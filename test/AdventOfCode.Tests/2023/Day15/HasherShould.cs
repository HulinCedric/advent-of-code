using FluentAssertions;
using Xunit;

namespace AdventOfCode._2023.Day15;

public class HasherShould
{
    [Theory]
    [InlineData("H", 200)]
    [InlineData("HASH", 52)]
    public void Hash(string toHash, int result)
        => Hasher.Hash(toHash).Should().Be(result);
}