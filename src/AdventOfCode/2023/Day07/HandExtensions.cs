using System.Collections.Generic;
using System.Linq;
using AdventOfCode._2023.Day07.HandTypes;

namespace AdventOfCode._2023.Day07;

public static class HandExtensions
{
    public static int OrderingStrength(this IEnumerable<Card> cards)
        => cards.Aggregate(1, (total, card) => total * Card.StrongestValue + card.Value);

    public static int TypeStrength(this IEnumerable<Card> cards, IList<IHandType> handTypes)
        => (from handType in handTypes
            let handTypeStrength = handTypes.IndexOf(handType)
            where handType.IsMatch(cards)
            select handTypeStrength).Max();
}