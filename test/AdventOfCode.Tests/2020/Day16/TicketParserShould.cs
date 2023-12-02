using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AdventOfCode._2020.Day16
{
    public class TicketParserShould
    {
        public static TheoryData<string, IEnumerable<Ticket>> TicketsParserSet
            => new()
            {
                {
                    YourTicketNumbers.FirstExample,
                    new[]
                    {
                        new Ticket(new ushort[] { 7, 1, 14 })
                    }
                },
                {
                    NearbyTicketsNumbers.FirstExample,
                    new[]
                    {
                        new Ticket(new ushort[] { 7, 3, 47 }),
                        new Ticket(new ushort[] { 40, 4, 50 }),
                        new Ticket(new ushort[] { 55, 2, 20 }),
                        new Ticket(new ushort[] { 38, 6, 12 })
                    }
                }
            };

        [Theory]
        [MemberData(nameof(TicketsParserSet))]
        public void Build_tickets(
            string ticketsDescription,
            IEnumerable<Ticket> expectedTickets)
        {
            // Given

            // When
            var actualTickets = TicketParser.Parse(ticketsDescription);

            // Then
            Assert.Equal(expectedTickets, actualTickets);
        }
    }

    public static class TicketParser
    {
        public static IEnumerable<Ticket> Parse(string ticketsDescription)
            => ticketsDescription
                .Split("\n", StringSplitOptions.RemoveEmptyEntries)
                .Skip(1)
                .Select(ExtractTicketNumber)
                .Select(ticketNumbers => new Ticket(ticketNumbers))
                .ToArray();

        private static IEnumerable<ushort> ExtractTicketNumber(string ticketNumbersDescription)
            => ticketNumbersDescription
                .Split(",")
                .Select(ushort.Parse)
                .ToArray();
    }
}