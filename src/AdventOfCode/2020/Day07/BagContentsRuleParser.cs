using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2020.Day07
{
    public static class BagContentsRuleParser
    {
        public static BagContentsRule Parse(string bagContentRuleDescription)
        {
            var bagColor = ExtractBagColor(bagContentRuleDescription);
            var holdBagCounts = ExtractHoldBagCounts(bagContentRuleDescription);

            return new BagContentsRule(new Bag(bagColor), holdBagCounts);
        }

        private static string ExtractBagColor(string bagContentRuleDescription)
        {
            var bagIndex = bagContentRuleDescription.IndexOf(" bags", StringComparison.InvariantCulture);
            return bagContentRuleDescription[..bagIndex];
        }

        private static IEnumerable<BagCount> ExtractHoldBagCounts(string bagContentRuleDescription)
        {
            if (bagContentRuleDescription.Contains("no other bags"))
            {
                return Enumerable.Empty<BagCount>();
            }

            var contentDelimiterIndex = bagContentRuleDescription.IndexOf("contain ", StringComparison.InvariantCulture) + "contain ".Length;
            var contentDescription = bagContentRuleDescription[contentDelimiterIndex..];

            return contentDescription
                .Split(",", StringSplitOptions.TrimEntries)
                .Select(ExtractHoldBagCount);
        }

        private static BagCount ExtractHoldBagCount(string contentDescription)
        {
            var holdBagNumber = ExtractHoldBagNumber(contentDescription);
            var holdBagColor = ExtractHoldBagColor(contentDescription);
            return new BagCount(holdBagNumber, new Bag(holdBagColor));
        }

        private static int ExtractHoldBagNumber(string contentDescription)
        {
            var holdBagIndex = contentDescription.IndexOf(" ", StringComparison.InvariantCulture);
            return int.Parse(contentDescription[..holdBagIndex]);
        }

        private static string ExtractHoldBagColor(string contentDescription)
        {
            var holdBagIndex = contentDescription.IndexOf(" bag", StringComparison.InvariantCulture);
            var skipNumberOfBag = contentDescription.IndexOf(" ", StringComparison.InvariantCulture) + " ".Length;
            return contentDescription[skipNumberOfBag..holdBagIndex];
        }
    }
}