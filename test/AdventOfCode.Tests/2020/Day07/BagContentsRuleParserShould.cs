using Xunit;

namespace AdventOfCode._2020.Day07
{
    public class BagContentsRuleParserShould
    {
        [Theory]
        [InlineData(
            "bright white bags contain 1 shiny gold bag.",
            "bright white", 1, "shiny gold")]
        public void Parse_bag_content_rule_hold_one_bag_type(
            string bagContentsRuleDescription,
            string expectedBagColor,
            int expectedHoldBagNumber,
            string expectedHoldBagColor)
        {
            // When
            var (bag, holdBagCounts) = BagContentsRuleParser
                .Parse(bagContentsRuleDescription);

            //Then
            Assert.Equal(expectedBagColor, bag.Color);
            Assert.Collection(holdBagCounts,
                holdBagCount => Assert.Equal(
                    new BagCount(expectedHoldBagNumber, new Bag(expectedHoldBagColor)),
                    holdBagCount));
        }

        [Theory]
        [InlineData(
            "vibrant indigo bags contain 2 striped purple bags, 4 vibrant green bags, 3 dotted purple bags, 1 vibrant turquoise bag.",
            "vibrant indigo",
            2, "striped purple",
            4, "vibrant green",
            3, "dotted purple",
            1, "vibrant turquoise")]
        public void Parse_bag_content_rule_hold_four_bag_types(
            string bagContentsRuleDescription,
            string expectedBagColor,
            int firstExpectedHoldBagNumber,
            string firstExpectedHoldBagColor,
            int secondExpectedHoldBagNumber,
            string secondExpectedHoldBagColor,
            int thirdExpectedHoldBagNumber,
            string thirdExpectedHoldBagColor,
            int fourthExpectedHoldBagNumber,
            string fourthExpectedHoldBagColor)
        {
            // When
            var (bag, holdBagCounts) = BagContentsRuleParser
                .Parse(bagContentsRuleDescription);

            //Then
            Assert.Equal(bag.Color, expectedBagColor);
            Assert.Collection(holdBagCounts,
                holdBagCount => Assert.Equal(
                    new BagCount(firstExpectedHoldBagNumber, new Bag(firstExpectedHoldBagColor)),
                    holdBagCount),
                holdBagCount => Assert.Equal(
                    new BagCount(secondExpectedHoldBagNumber, new Bag(secondExpectedHoldBagColor)),
                    holdBagCount),
                holdBagCount => Assert.Equal(
                    new BagCount(thirdExpectedHoldBagNumber, new Bag(thirdExpectedHoldBagColor)),
                    holdBagCount),
                holdBagCount => Assert.Equal(
                    new BagCount(fourthExpectedHoldBagNumber, new Bag(fourthExpectedHoldBagColor)),
                    holdBagCount));
        }

        [Theory]
        [InlineData("faded blue bags contain no other bags.", "faded blue")]
        [InlineData("dotted black bags contain no other bags.", "dotted black")]
        public void Parse_bag_content_rule_hold_zero_bag_type(
            string bagContentsRuleDescription,
            string expectedBagColor)
        {
            // When
            var (bag, holdBagCounts) = BagContentsRuleParser
                .Parse(bagContentsRuleDescription);

            //Then
            Assert.Equal(expectedBagColor, bag.Color);
            Assert.Empty(holdBagCounts);
        }
    }
}