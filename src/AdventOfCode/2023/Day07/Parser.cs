using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2023.Day07;

public static class Parser
{
    public static IEnumerable<int> OrderBidsByHandStrength(string input, Func<string, Hand> parseHand)
        => from line in input.Split("\n")
           let part = line.Split(" ")
           let hand = parseHand(part[0])
           let bid = int.Parse(part[1])
           orderby hand
           select bid;

    internal static List<Card> ParseCards(string hand, IDictionary<char, int> labelStrengths)
        => hand.ToCharArray().Select(c => Card.Parse(c, labelStrengths)).ToList();
}

public static class HandParserWithJAsJack
{
    public static Hand Parse(string hand)
        => new(Parser.ParseCards(hand, Card.LabelsWithJasJack));
}

public static class HandParserWithJAsJoker
{
    public static Hand Parse(string hand)
    {
        var labelStrengths = Card.LabelsWithJasJoker;

        var originalCards = OriginalCards(hand, labelStrengths);

        var possibleJokerHandsCards = JokerPossibleHandsCards(hand, labelStrengths);

        return possibleJokerHandsCards
            .Select(jokerCards => new Hand(originalCards, jokerCards))
            .Max()!;
    }

    private static List<Card> OriginalCards(string hand, IDictionary<char, int> labelStrengths)
        => Parser.ParseCards(hand, labelStrengths);

    private static List<List<Card>> JokerPossibleHandsCards(
        string hand,
        IDictionary<char, int> labelStrengths)
        => labelStrengths.Keys
            .Select(ch => hand.Replace(Card.JokerLabel, ch))
            .Select(
                substitute => substitute.ToCharArray()
                    .Select(label => Card.Parse(label, labelStrengths))
                    .ToList())
            .ToList();
}