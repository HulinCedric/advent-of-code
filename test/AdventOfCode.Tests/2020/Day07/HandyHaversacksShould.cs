using System.Linq;
using Xunit;

namespace AdventOfCode._2020.Day07
{
    public class HandyHaversacksShould
    {
        [Theory]
        [InlineData(BagContentsRulesDescription.ExampleDescription, 4)]
        [InputFileData("2020/Day07/input.txt", 144)]
        public void Count_bag_colors_who_contain_at_least_one_shiny_gold_bag(
            string bagContentsRulesDescription,
            int expectedBagColorsCount)
        {
            //Given
            var bagContentsRules = BagContentsRulesParser.Parse(bagContentsRulesDescription);
            var shinyGoldBag = new Bag("shiny gold");

            //When
            var bagColorsCount = bagContentsRules
                .GetBagsContaining(shinyGoldBag)
                .Select(bag => bag.Color)
                .Distinct()
                .Count();

            //Then
            Assert.Equal(expectedBagColorsCount, bagColorsCount);
        }

        [Theory]
        [InlineData(BagContentsRulesDescription.ExampleDescription, 32)]
        [InlineData(BagContentsRulesDescription.AdditionalExampleDescription, 126)]
        [InputFileData("2020/Day07/input.txt", 5956)]
        public void Sum_individual_bags_required_inside_a_single_shiny_gold_bag(
            string bagContentsRulesDescription,
            int expectedBagColorsCount)
        {
            //Given
            var bagContentsRules = BagContentsRulesParser.Parse(bagContentsRulesDescription);
            var shinyGoldBag = new Bag("shiny gold");

            //When
            var requiredBagsCount = bagContentsRules
                .SumRequiredBagsFor(shinyGoldBag);

            //Then
            Assert.Equal(expectedBagColorsCount, requiredBagsCount);
        }
    }
}