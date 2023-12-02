using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2020.Day07
{
    public class BagContentsRules
        : IEnumerable<BagContentsRule>
    {
        private readonly List<BagContentsRule> bagContentRules;

        public BagContentsRules(IEnumerable<string> bagContentsRulesDescription)
            => bagContentRules = bagContentsRulesDescription
                .Select(BagContentsRuleParser.Parse)
                .ToList();

        public IEnumerator<BagContentsRule> GetEnumerator()
            => bagContentRules.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        public IEnumerable<Bag> GetBagsContaining(Bag targetBag)
        {
            foreach (var directBagHolder in bagContentRules
                .Where(
                    rule => rule.HoldBagCounts
                        .Any(holdBagCount => holdBagCount.Bag.Equals(targetBag)))
                .Select(rule => rule.Bag))
            {
                yield return directBagHolder;

                foreach (var indirectBagHolder in GetBagsContaining(directBagHolder))
                    yield return indirectBagHolder;
            }
        }

        public int SumRequiredBagsFor(Bag targetBag)
        {
            var requiredBadSum = 0;
            foreach (var (bagNumber, bag) in bagContentRules
                .Where(rule => rule.Bag == targetBag)
                .SelectMany(rule => rule.HoldBagCounts))
            {
                requiredBadSum += bagNumber;
                requiredBadSum += bagNumber * SumRequiredBagsFor(bag);
            }

            return requiredBadSum;
        }
    }
}