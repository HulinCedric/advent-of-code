using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2023.Day07;

public static class BidExtensions
{
    public static int TotalWinnings(IEnumerable<int> bids)
        => bids.Select((bid, rank) => bid * (rank + 1)).Sum();
}