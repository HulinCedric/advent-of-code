using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2023.Day04;

public static class ScratchCards
{
    public static int CountTotalCards(List<ScratchCard> cards)
        => Enumerable
            .Empty<int>()
            .Concat(OriginalCardsCount(cards))
            .Concat(CopyCardsCount(cards))
            .Sum();

    private static int[] OriginalCardsCount(List<ScratchCard> cards)
        => cards.Select(_ => 1).ToArray();

    private static int[] CopyCardsCount(List<ScratchCard> cards)
    {
        var cardsCount = new int[cards.Count];
        for (var i = 0; i < cards.Count; i++)
        {
            var numberOfMatches = cards[i].Matches();
            for (var j = 1; j <= numberOfMatches && i + j < cards.Count; j++)
            {
                cardsCount[i + j] += cardsCount[i] + 1;
            }
        }

        return cardsCount;
    }
}