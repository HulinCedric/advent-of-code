using System;
using System.Collections.Generic;

namespace AdventOfCode._2023.Day07;

public readonly record struct Card : IComparable<Card>
{
    internal const int StrongestValue = 14;

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

    public static Card Parse(char label)
        => new(label);

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