using System.Linq;
using Xunit;

namespace AdventOfCode._2020.Day19
{
    public class MonsterMessagesShould
    {
        [Theory]
        [InlineData(MonsterMessagesDescription.Part1Example, 2)]
        [InputFileData("2020/Day19/input.txt", 279)]
        public void How_many_messages_completely_match_rule_0(
            string monsterMessagesDescription,
            long expectedValidMessageCount)
        {
            // Given
            var (rules, messages) = MonsterMessagesParser.Parse(monsterMessagesDescription);

            // When
            var actualValidMessageCount = messages.Count(m => rules[0].Matches(m).Any(x => x.IsFullMatch));

            // Then
            Assert.Equal(expectedValidMessageCount, actualValidMessageCount);
        }

        [Theory]
        [InlineData(MonsterMessagesDescription.Part2Example, 12)]
        [InputFileData("2020/Day19/input.txt", 384)]
        public void After_updating_rules_8_and_11_how_many_messages_completely_match_rule_0(
            string monsterMessagesDescription,
            long expectedValidMessageCount)
        {
            // Given
            monsterMessagesDescription = monsterMessagesDescription
                .Replace("8: 42", "8: 42 | 42 8")
                .Replace("11: 42 31", "11: 42 31 | 42 11 31");
            
            var (rules, messages) = MonsterMessagesParser.Parse(monsterMessagesDescription);

            // When
            var actualValidMessageCount = messages.Count(m => rules[0].Matches(m).Any(x => x.IsFullMatch));

            // Then
            Assert.Equal(expectedValidMessageCount, actualValidMessageCount);
        }
    }
}