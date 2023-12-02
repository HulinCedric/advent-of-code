using System.Linq;
using Xunit;

namespace AdventOfCode._2020.Day07
{
    public class BagContentsRulesParserShould
    {
        [Theory]
        [InlineData("bright white bags contain 1 shiny gold bag.\nmuted yellow bags contain 2 shiny gold bags", 2)]
        public void Parse_bag_contents_rules_separated_by_new_line(
            string bagContentsRulesDescription,
            int expectedBagContentsRulesCount)
        {
            //When
            var bagContentsRulesCount = BagContentsRulesParser
                .Parse(bagContentsRulesDescription)
                .Count();

            //Then
            Assert.Equal(expectedBagContentsRulesCount, bagContentsRulesCount);
        }
    }
}