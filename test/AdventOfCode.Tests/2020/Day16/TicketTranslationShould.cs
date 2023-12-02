using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AdventOfCode._2020.Day16
{
    public class TicketTranslationShould
    {
        public static TheoryData<string, IEnumerable<IndexGroupedTicketField>> IndexGroupedValidTicketFieldsSet
            => new()
            {
                {
                    TicketsNotes.FirstExample,
                    new[]
                    {
                        new IndexGroupedTicketField(0, new ushort[] { 7, 7 }),
                        new IndexGroupedTicketField(1, new ushort[] { 1, 3 }),
                        new IndexGroupedTicketField(2, new ushort[] { 14, 47 })
                    }
                }
            };

        public static TheoryData<string, IEnumerable<TicketField>> TicketFieldsSet
            => new()
            {
                {
                    TicketsNotes.FirstExample,
                    new[]
                    {
                        new TicketField("row", 0),
                        new TicketField("class", 1),
                        new TicketField("seat", 2)
                    }
                },
                {
                    TicketsNotes.SecondExample,
                    new[]
                    {
                        new TicketField("row", 0),
                        new TicketField("class", 1),
                        new TicketField("seat", 2)
                    }
                }
            };

        [Theory]
        [InlineData(TicketsNotes.FirstExample, 71)]
        [InputFileData("2020/Day16/input.txt", 32842)]
        public void What_is_your_ticket_scanning_error_rate(
            string ticketsNotes,
            ushort expectedScanningErrorRate)
        {
            // Given
            var ticketTranslation = TicketTranslationParser.Parse(ticketsNotes);

            // When
            var actualScanningErrorRate = ticketTranslation.ScanningErrorRate;

            // Then
            Assert.Equal(expectedScanningErrorRate, actualScanningErrorRate);
        }

        [Theory]
        [MemberData(nameof(IndexGroupedValidTicketFieldsSet))]
        public void Group_ticket_fields_by_index(
            string ticketsNotes,
            IEnumerable<IndexGroupedTicketField> expectedIndexGroupedTicketFields)
        {
            // Given
            var ticketTranslation = TicketTranslationParser.Parse(ticketsNotes);

            // When
            var actualIndexGroupedTicketFields = ticketTranslation.GetIndexGroupedValidTicketFields();

            // Then
            Assert.Equal(expectedIndexGroupedTicketFields, actualIndexGroupedTicketFields);
        }

        [Theory]
        [MemberData(nameof(TicketFieldsSet))]
        public void Determine_ticket_fields(
            string ticketsNotes,
            IEnumerable<TicketField> expectedTicketFields)
        {
            // Given
            var ticketTranslation = TicketTranslationParser.Parse(ticketsNotes);

            // When
            var actualTicketFields = ticketTranslation.GetTicketFields();

            // Then
            Assert.Equal(expectedTicketFields, actualTicketFields);
        }

        [Theory]
        [InputFileData("2020/Day16/input.txt")]
        public void Multiply_departure_fields_values(
            string ticketsNotes)
        {
            // Given
            var ticketTranslation = TicketTranslationParser.Parse(ticketsNotes);

            // When
            var ticketFields = ticketTranslation.GetTicketFields();
            var departureTicketFields = ticketFields
                .Where(ticketField => ticketField.Name.StartsWith("departure"))
                .ToArray();

            var result = ticketTranslation.YourTicket.Numbers
                .Select((number, index) => (number, index))
                .Where(
                    numberIndex => departureTicketFields
                        .Select(ticketField => ticketField.Index)
                        .Contains(numberIndex.index))
                .Select(numberIndex => numberIndex.number)
                .Aggregate(1L, (acc, number) => acc * number);

            // Then
            Assert.Equal(2628667251989L, result);
        }
    }

    public record TicketTranslation(
        IEnumerable<TicketFieldRule> Rules,
        Ticket YourTicket,
        IEnumerable<Ticket> NearbyTickets)
    {
        public ushort ScanningErrorRate
            => NearbyTickets
                .SelectMany(ticket => ticket.GetInvalidNumbers(Rules))
                .Aggregate((ushort)0, (acc, invalidNumber) => (ushort)(acc + invalidNumber));

        public virtual bool Equals(TicketTranslation? other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return Rules.SequenceEqual(other.Rules) &&
                   YourTicket.Equals(other.YourTicket) &&
                   NearbyTickets.SequenceEqual(other.NearbyTickets);
        }

        public override int GetHashCode()
            => HashCode.Combine(Rules, YourTicket, NearbyTickets);

        public IEnumerable<IndexGroupedTicketField> GetIndexGroupedValidTicketFields()
            => Enumerable.Empty<Ticket>()
                .Concat(new[] { YourTicket })
                .Concat(NearbyTickets.Where(ticket => ticket.IsValid(Rules)))
                .SelectMany(ticket => ticket.Numbers.Select((number, index) => (number, index)))
                .GroupBy(numberAndIndex => numberAndIndex.index)
                .Select(
                    grouping => new IndexGroupedTicketField(
                        grouping.Key,
                        grouping.Select(t => t.number)));

        public IEnumerable<TicketField> GetTicketFields()
        {
            void DetermineFieldAndRemoveCorrespondingRuleAndTicket(
                ICollection<(int Index, Ticket ticket)> tickets,
                ICollection<TicketFieldRule> rules,
                ICollection<TicketField> ticketFields)
            {
                var ((indexAndTicket, rule), ticketField) =
                    tickets
                        .Select(
                            indexAndTicketsNumber =>
                                (indexAndTicketsNumber,
                                 indexAndTicketsNumber.ticket.GetValidRules(rules)))
                        .Where(tuple => tuple.Item2.Count() == 1)
                        .Select(
                            tuple => (tuple.indexAndTicketsNumber,
                                      tuple.Item2.First()))
                        .Select(
                            tuple => (tuple,
                                      new TicketField(
                                          tuple.Item2.FieldName,
                                          tuple.indexAndTicketsNumber.Index)))
                        .FirstOrDefault();

                ticketFields.Add(ticketField);
                tickets.Remove(indexAndTicket);
                rules.Remove(rule);
            }

            var indexAndTicketsNumbers = GetIndexGroupedValidTicketFields()
                .Select(
                    indexGroupedTicketField
                        => (indexGroupedTicketField.Index,
                            ticket: new Ticket(indexGroupedTicketField.Numbers)))
                .ToList();

            var notAssignedRules = Rules.ToList();
            var ticketFields = new List<TicketField>();
            while (notAssignedRules.Any())
                DetermineFieldAndRemoveCorrespondingRuleAndTicket(
                    indexAndTicketsNumbers,
                    notAssignedRules,
                    ticketFields);

            return ticketFields
                .OrderBy(t => t.Index)
                .ToArray();
        }
    }

    public record TicketField(string Name, int Index);

    public sealed record IndexGroupedTicketField(int Index, IEnumerable<ushort> Numbers)
    {
        public bool Equals(IndexGroupedTicketField? other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return Index == other.Index && Numbers.SequenceEqual(other.Numbers);
        }

        public override int GetHashCode()
        {
            HashCode hashcode = new();
            hashcode.Add(Index);
            foreach (var number in Numbers)
                hashcode.Add(number);
            return hashcode.ToHashCode();
        }
    }
}