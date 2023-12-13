using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2023.Day07.HandTypes;

public class FullHouse : IHandType
{
    public bool IsMatch(IEnumerable<Card> cards)
        => cards.Pair().Count() == 1 &&
           cards.Triplet().Count() == 1;
}