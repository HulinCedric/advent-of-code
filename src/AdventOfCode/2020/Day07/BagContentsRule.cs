using System.Collections.Generic;

namespace AdventOfCode._2020.Day07
{
    public record BagContentsRule(Bag Bag, IEnumerable<BagCount> HoldBagCounts);
}