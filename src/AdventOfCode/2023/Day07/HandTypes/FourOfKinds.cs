using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2023.Day07.HandTypes;

public class FourOfKinds : IHandType
{
    public bool IsMatch(IEnumerable<Card> cards)
        => cards.Quadruplet().Count() == 1;
}