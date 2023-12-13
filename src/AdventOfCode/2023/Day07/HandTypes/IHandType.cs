using System.Collections.Generic;

namespace AdventOfCode._2023.Day07.HandTypes;

public interface IHandType
{
    bool IsMatch(IEnumerable<Card> cards);
}