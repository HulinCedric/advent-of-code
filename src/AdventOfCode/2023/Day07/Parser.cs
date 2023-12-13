using System.Linq;

namespace AdventOfCode._2023.Day07;

public static class ParserWithJAsJack
{
    public static Hand Parse(string hand)
        => new(hand.ToCharArray().Select(c => Card.Parse(c, Card.LabelsWithJasJack[c])).ToList());
}

public static class ParserWithJAsJoker
{
    public static Hand Parse(string hand)
        => new(hand.ToCharArray().Select(c => Card.Parse(c, Card.LabelsWithJasJoker[c])).ToList());
}