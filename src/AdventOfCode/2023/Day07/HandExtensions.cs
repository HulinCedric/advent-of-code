using System.Collections.Generic;
using System.Linq;
using AdventOfCode._2023.Day07.HandTypes;

namespace AdventOfCode._2023.Day07;

public static class HandExtensions
{
    public static IEnumerable<IGrouping<char, Card>> Pair(this IEnumerable<Card> cards)
        => cards.HaveSameCardTimes(2);

    public static IEnumerable<IGrouping<char, Card>> Triplet(this IEnumerable<Card> cards)
        => cards.HaveSameCardTimes(3);

    public static IEnumerable<IGrouping<char, Card>> Quadruplet(this IEnumerable<Card> cards)
        => cards.HaveSameCardTimes(4);

    public static IEnumerable<IGrouping<char, Card>> Quintuplet(this IEnumerable<Card> cards)
        => cards.HaveSameCardTimes(5);

    private static IEnumerable<IGrouping<char, Card>> HaveSameCardTimes(this IEnumerable<Card> cards, int numberOfCards)
        => cards
            .ThatHaveSameLabel()
            .AndNumberOfCardsIs(numberOfCards);

    private static IEnumerable<IGrouping<char, Card>> ThatHaveSameLabel(this IEnumerable<Card> cards)
        => cards.GroupBy(c => c.Label);

    private static IEnumerable<IGrouping<T, Card>> AndNumberOfCardsIs<T>(
        this IEnumerable<IGrouping<T, Card>> groupOfCards,
        int numberOfCards)
        => groupOfCards.Where(g => g.Count() == numberOfCards);

    public static int OrderingStrength(this IEnumerable<Card> cards)
        => cards.Aggregate(1, (total, card) => total * Card.StrongestValue + card.Value);

    public static int TypeStrength(this IEnumerable<Card> cards, IList<IHandType> handTypes)
        => (from handType in handTypes
            let handTypeStrength = handTypes.IndexOf(handType)
            where handType.IsMatch(cards)
            select handTypeStrength).Max();
}