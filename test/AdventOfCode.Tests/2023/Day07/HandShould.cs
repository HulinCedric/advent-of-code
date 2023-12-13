using FluentAssertions;
using Xunit;

namespace AdventOfCode._2023.Day07;

public class HandShould
{
    [Theory]
    [InlineData("32T3K", "KTJJT")]
    [InlineData("KTJJT", "KK677")]
    [InlineData("KK677", "T55J5")]
    [InlineData("T55J5", "QQQJA")]
    [InlineData("QQQJA", "22222")]
    [InlineData("AA23A", "AAAKK")]
    [InlineData("AAAKK", "22223")]
    [InlineData("AAAAK", "22222")]
    public void Weakest(
        string firstHand,
        string secondHand)
        => Hand.Parse(firstHand).Should().BeLessThan(Hand.Parse(secondHand));

    [Theory]
    [InlineData("33332", "2AAAA")]
    [InlineData("77888", "77788")]
    public void Strongest(
        string firstHand,
        string secondHand)
        => Hand.Parse(firstHand).Should().BeGreaterThan(Hand.Parse(secondHand));
}