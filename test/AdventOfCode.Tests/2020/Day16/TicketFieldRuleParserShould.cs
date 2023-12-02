using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AdventOfCode._2020.Day16
{
    public class TicketFieldRuleParserShould
    {
        [Theory]
        [ClassData(typeof(TicketFieldRuleParserData))]
        public void Build_ticket_field_rules(
            string ticketFieldRuleDescription,
            string[] expectedTicketFieldNames,
            ushort[][] expectedTicketFieldRuleValues)
        {
            // Given
            var expectedTicketFieldRules = expectedTicketFieldRuleValues
                .Select(
                    (v, i) => new TicketFieldRule(
                        expectedTicketFieldNames[i],
                        v[0],
                        v[1],
                        v[2],
                        v[3]));

            // When
            var actualTicketFieldRules = TicketFieldRuleParser.Parse(ticketFieldRuleDescription);

            // Then
            Assert.Equal(expectedTicketFieldRules, actualTicketFieldRules);
        }
    }

    public static class TicketFieldRuleParser
    {
        public static IEnumerable<TicketFieldRule> Parse(string ticketFieldRulesDescription)
            => ticketFieldRulesDescription
                .Split("\n", StringSplitOptions.RemoveEmptyEntries)
                .Select(ParseOne);

        private static (ushort, ushort) ExtractRange(string rangeDescription)
        {
            var rangeValues = rangeDescription.Split("-").Select(ushort.Parse).ToArray();
            var lowerRangeValue = rangeValues.First();
            var upperRangeValue = rangeValues.Last();
            return (lowerRangeValue, upperRangeValue);
        }

        private static TicketFieldRule ParseOne(string ticketFieldRuleDescription)
        {
            const string nameRangesSeparator = ":";
            var nameValues = ticketFieldRuleDescription.Split(nameRangesSeparator);
            var fieldName = nameValues.First();
            var valuePart = nameValues.Last();

            const string rangeValuesSeparator = "or";
            var rangeParts = valuePart.Split(rangeValuesSeparator, StringSplitOptions.TrimEntries).ToArray();

            var (firstLowerRange, firstUpperRange) = ExtractRange(rangeParts.First());
            var (secondLowerRange, secondUpperRange) = ExtractRange(rangeParts.Last());

            return new TicketFieldRule(
                fieldName,
                firstLowerRange,
                firstUpperRange,
                secondLowerRange,
                secondUpperRange);
        }
    }
}