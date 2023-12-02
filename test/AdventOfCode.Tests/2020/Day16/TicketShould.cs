using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AdventOfCode._2020.Day16
{
    public class TicketShould
    {
        public static TheoryData<Ticket, IEnumerable<TicketFieldRule>, bool> TicketValiditySet
            => new()
            {
                {
                    new Ticket(new ushort[] { 7, 3, 47 }),
                    TicketFieldRuleParser.Parse(TicketFieldsRulesInformation.FirstExample),
                    true
                },
                {
                    new Ticket(new ushort[] { 40, 4, 50 }),
                    TicketFieldRuleParser.Parse(TicketFieldsRulesInformation.FirstExample),
                    false
                },
                {
                    new Ticket(new ushort[] { 55, 2, 20 }),
                    TicketFieldRuleParser.Parse(TicketFieldsRulesInformation.FirstExample),
                    false
                },
                {
                    new Ticket(new ushort[] { 38, 6, 12 }),
                    TicketFieldRuleParser.Parse(TicketFieldsRulesInformation.FirstExample),
                    false
                }
            };

        public static TheoryData<Ticket, IEnumerable<TicketFieldRule>, ushort[]> TicketInvalidNumbersSet
            => new()
            {
                {
                    new Ticket(new ushort[] { 40, 4, 50 }),
                    TicketFieldRuleParser.Parse(TicketFieldsRulesInformation.FirstExample),
                    new ushort[] { 4 }
                },
                {
                    new Ticket(new ushort[] { 55, 2, 20 }),
                    TicketFieldRuleParser.Parse(TicketFieldsRulesInformation.FirstExample),
                    new ushort[] { 55 }
                },
                {
                    new Ticket(new ushort[] { 38, 6, 12 }),
                    TicketFieldRuleParser.Parse(TicketFieldsRulesInformation.FirstExample),
                    new ushort[] { 12 }
                }
            };

        [Theory]
        [MemberData(nameof(TicketValiditySet))]
        public void Be_valid_when_all_fields_are_respect_at_least_one_rule(
            Ticket ticket,
            IEnumerable<TicketFieldRule> rules,
            bool expectedValidity)
        {
            // Given

            // When
            var actualValidity = ticket.IsValid(rules);

            // Then
            Assert.Equal(expectedValidity, actualValidity);
        }

        [Theory]
        [MemberData(nameof(TicketInvalidNumbersSet))]
        public void Get_invalid_numbers_for_invalid_ticket(
            Ticket ticket,
            IEnumerable<TicketFieldRule> rules,
            ushort[] expectedInvalidNumbers)
        {
            // Given

            // When
            var actualInvalidNumbers = ticket.GetInvalidNumbers(rules);

            // Then
            Assert.Equal(expectedInvalidNumbers.ToArray(), actualInvalidNumbers.ToArray());
        }
    }

    public sealed record Ticket(IEnumerable<ushort> Numbers)
    {
        public bool Equals(Ticket? other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return Numbers.SequenceEqual(other.Numbers);
        }

        public override int GetHashCode()
        {
            HashCode hashcode = new();
            foreach (var number in Numbers)
                hashcode.Add(number);
            return hashcode.ToHashCode();
        }

        public bool IsValid(IEnumerable<TicketFieldRule> rules)
            => !GetInvalidNumbers(rules).Any();

        public IEnumerable<ushort> GetInvalidNumbers(IEnumerable<TicketFieldRule> rules)
            => Numbers.Where(number => !rules.Any(rule => rule.IsValid(number)));

        public IEnumerable<TicketFieldRule> GetValidRules(IEnumerable<TicketFieldRule> rules)
            => rules.Where(rule => rule.IsValid(Numbers));
    }
}