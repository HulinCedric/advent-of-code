using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AdventOfCode._2020.Day16
{
    public class TicketFieldRuleShould
    {
        [Theory]
        [InlineData(1, 3, 5, 7, 0)]
        [InlineData(1, 3, 5, 7, 4)]
        [InlineData(1, 3, 5, 7, 8)]
        public void Be_invalid(
            ushort firstLowerRange,
            ushort firstUpperRange,
            ushort secondLowerRange,
            ushort secondUpperRange,
            ushort value)
        {
            // Given
            var ticketFieldRule = new TicketFieldRule(
                "field name",
                firstLowerRange,
                firstUpperRange,
                secondLowerRange,
                secondUpperRange);

            // When
            var expectedValidity = ticketFieldRule.IsInvalid(value);

            // Then
            Assert.True(expectedValidity);
        }

        [Theory]
        [InlineData(1, 3, 5, 7, 1)]
        [InlineData(1, 3, 5, 7, 2)]
        [InlineData(1, 3, 5, 7, 3)]
        [InlineData(1, 3, 5, 7, 5)]
        [InlineData(1, 3, 5, 7, 6)]
        [InlineData(1, 3, 5, 7, 7)]
        public void Be_valid_when_value_is_in_range(
            ushort firstLowerRange,
            ushort firstUpperRange,
            ushort secondLowerRange,
            ushort secondUpperRange,
            ushort value)
        {
            // Given
            var ticketFieldRule = new TicketFieldRule(
                "field name",
                firstLowerRange,
                firstUpperRange,
                secondLowerRange,
                secondUpperRange);

            // When
            var expectedValidity = ticketFieldRule.IsValid(value);

            // Then
            Assert.True(expectedValidity);
        }
    }

    public record TicketFieldRule(
        string FieldName,
        ushort FirstLowerRange,
        ushort FirstUpperRange,
        ushort SecondLowerRange,
        ushort SecondUpperRange)
    {
        internal bool IsInvalid(ushort value)
            => IsValid(value) == false;

        internal bool IsValid(ushort value)
            => FirstLowerRange <= value && value <= FirstUpperRange ||
               SecondLowerRange <= value && value <= SecondUpperRange;

        public bool IsValid(IEnumerable<ushort> numbers)
            => numbers.All(IsValid);
    }
}