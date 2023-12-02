using System.Linq;
using Xunit;

namespace AdventOfCode._2020.Day19
{
    public class RuleParserShould
    {
        [Theory]
        [InlineData("0: 4 1 5\n", 0, "4 1 5")]
        [InlineData("1: \"a\"\n", 1, "\"a\"")]
        [InlineData("2: 1 3 | 3 1\n", 2, "1 3 | 3 1")]
        public void Split_number_and_rule_separated_by_colon(
            string ruleDescription,
            int ruleNumber,
            string rule)
        {
            // Given
            var expected = (ruleNumber, rule);

            // When
            var actual = RuleParser.ParseSingle(ruleDescription);

            // Then
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Split_multiple_rules_separated_by_newline()
        {
            // Given
            var expected = new[]
            {
                (0, "1 2"),
                (1, "\"a\""),
                (2, "1 3 | 3 1"),
                (3, "\"b\"")
            };

            // When
            var actual = RuleParser.ParseRaw(MonsterMessagesDescription.SimpleRulesExample).ToArray();

            // Then
            Assert.Equal(expected, actual);
        }
    }
}