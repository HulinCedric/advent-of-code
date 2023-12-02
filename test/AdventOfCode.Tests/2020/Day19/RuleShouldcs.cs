using Xunit;

namespace AdventOfCode._2020.Day19
{
    public class RulesShould
    {
        [Theory]
        [InlineData(MonsterMessagesDescription.SimpleRulesExample, 0, "aab | aba")]
        [InlineData(
            MonsterMessagesDescription.Part1RulesExample,
            0,
            "aaaabb | aaabab | abbabb | abbbab | aabaab | aabbbb | abaaab | ababbb")]
        public void Compile_rule_zero(
            string ruleDescription,
            int ruleNumber,
            string rule) // Then

        {
            // Given
            var rules = RuleParser.Parse(ruleDescription);

            // When
            var actual = rules[0].ToString();

            Assert.Equal(rule, rule);
        }
    }
}