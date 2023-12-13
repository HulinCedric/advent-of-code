using System;
using System.Collections.Generic;

namespace AdventOfCode._2023.Day07;

public readonly record struct Card : IComparable<Card>
{
    internal const int StrongestValue = 14;
    internal const char JokerLabel = 'J';

    public static readonly IDictionary<char, int> LabelsWithJasJack = new Dictionary<char, int>
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

    public static readonly IDictionary<char, int> LabelsWithJasJoker = new Dictionary<char, int>
    {
        { 'J', 1 },
        { '2', 2 },
        { '3', 3 },
        { '4', 4 },
        { '5', 5 },
        { '6', 6 },
        { '7', 7 },
        { '8', 8 },
        { '9', 9 },
        { 'T', 10 },
        { 'Q', 11 },
        { 'K', 12 },
        { 'A', 13 }
    };
    
    private Card(char label, int strength)
    {
        Label = label;
        Strength = strength;
    }

    public char Label { get; }

    public int Strength { get; }

    public int CompareTo(Card other)
        => Strength.CompareTo(other.Strength);

    public static Card Parse(char label, IDictionary<char, int> labelStrengths)
        => new(label, labelStrengths[label]);

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