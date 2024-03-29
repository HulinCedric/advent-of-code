using FluentAssertions;
using Xunit;
using static AdventOfCode._2023.Day07.HandParserWithJAsJack;

namespace AdventOfCode._2023.Day07;

public class HandShould
{
    [Theory]
    [InlineData("23456", "A23A4")]
    public void HighCard_Should_Be_Weaker_Than_OnePair(string firstHand, string secondHand)
        => Parse(firstHand).Should().BeLessThan(Parse(secondHand));

    [Theory]
    [InlineData("A23A4", "23432")]
    public void OnePair_Should_Be_Weaker_Than_TwoPairs(string firstHand, string secondHand)
        => Parse(firstHand).Should().BeLessThan(Parse(secondHand));

    [Theory]
    [InlineData("23432", "TTT98")]
    public void TwoPairs_Should_Be_Weaker_Than_ThreeOfKinds(string firstHand, string secondHand)
        => Parse(firstHand).Should().BeLessThan(Parse(secondHand));

    [Theory]
    [InlineData("TTT98", "23332")]
    public void ThreeOfKinds_Should_Be_Weaker_Than_FullHouse(string firstHand, string secondHand)
        => Parse(firstHand).Should().BeLessThan(Parse(secondHand));

    [Theory]
    [InlineData("23332", "AA8AA")]
    public void FullHouse_Should_Be_Weaker_Than_FourOfKinds(string firstHand, string secondHand)
        => Parse(firstHand).Should().BeLessThan(Parse(secondHand));

    [Theory]
    [InlineData("AA8AA", "AAAAA")]
    public void FourOfKinds_Should_Be_Weaker_Than_FiveOfKinds(string firstHand, string secondHand)
        => Parse(firstHand).Should().BeLessThan(Parse(secondHand));

    [Theory]
    [InlineData("2AAAA", "33332")]
    [InlineData("77788", "77888")]
    public void Same_HandType_should_be_compared_by_Ordered_Card_Strength(
        string strongerHand,
        string weakerHand)
        => Parse(strongerHand).Should().BeLessThan(Parse(weakerHand));
}