using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace AdventOfCode._2023.Day07;

public class CardShould
{
    [Theory]
    [InlineData("2", "3")]
    [InlineData("3", "4")]
    [InlineData("4", "5")]
    [InlineData("5", "6")]
    [InlineData("6", "7")]
    [InlineData("7", "8")]
    [InlineData("8", "9")]
    [InlineData("9", "T")]
    [InlineData("T", "J")]
    [InlineData("J", "Q")]
    [InlineData("Q", "K")]
    [InlineData("K", "A")]
    public void Be_weakest_than(
        string firstCardLabel,
        string secondCardLabel)
        => Card.Parse(firstCardLabel).Should().BeLessThan(Card.Parse(secondCardLabel));
}

public readonly record struct Card : IComparable<Card>
{
    private static readonly IDictionary<char, int> LabelStrength = new Dictionary<char, int>
    {
        { '2', 2 },
        { '3', 3 },
        { '4', 4 },
        { '5', 5 },
        { '6', 6 },
        { '7', 7 },
        { '8', 8 },
        { '9', 9 },
        { 'T', 10 },
        { 'J', 11 },
        { 'Q', 12 },
        { 'K', 13 },
        { 'A', 14 }
    };


    private Card(char label)
    {
        Label = label;
        Value = LabelStrength[label];
    }

    public char Label { get; }

    public int Value { get; }

    public int CompareTo(Card other)
        => Value.CompareTo(other.Value);

    public static Card Parse(string label)
        => new(label[0]);

    public override string ToString()
        => $"{Label}";

    public static bool operator <(Card left, Card right)
        => left.CompareTo(right) < 0;

    public static bool operator >(Card left, Card right)
        => left.CompareTo(right) > 0;

    public static bool operator <=(Card left, Card right)
        => left.CompareTo(right) <= 0;

    public static bool operator >=(Card left, Card right)
        => left.CompareTo(right) >= 0;
}