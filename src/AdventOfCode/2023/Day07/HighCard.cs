using System.Collections.Generic;
using System.Linq;
using AdventOfCode._2023.Day07.HandTypes;

namespace AdventOfCode._2023.Day07;

public class HighCard : IHandType
{
    public bool IsMatch(IEnumerable<Card> cards)
        => cards.Count() == cards.Select(card => card.Label).Distinct().Count();
}