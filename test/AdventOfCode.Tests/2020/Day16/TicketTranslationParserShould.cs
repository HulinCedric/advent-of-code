using System.Linq;
using Xunit;

namespace AdventOfCode._2020.Day16
{
    public class TicketTranslationParserShould
    {
        public static TheoryData<string, TicketTranslation> TicketTranslationParserSet
            => new()
            {
                {
                    TicketsNotes.FirstExample,
                    new TicketTranslation(
                        TicketFieldRuleParser.Parse(TicketFieldsRulesInformation.FirstExample),
                        TicketParser.Parse(YourTicketNumbers.FirstExample).Single(),
                        TicketParser.Parse(NearbyTicketsNumbers.FirstExample))
                }
            };

        [Theory]
        [MemberData(nameof(TicketTranslationParserSet))]
        public void Build_ticket_translation(
            string ticketNotesDescription,
            TicketTranslation expectedTicketTranslation)
        {
            // Given

            // When
            var actualTicketTranslation = TicketTranslationParser.Parse(ticketNotesDescription);

            // Then
            Assert.Equal(expectedTicketTranslation, actualTicketTranslation);
        }
    }

    public static class TicketTranslationParser
    {
        public static TicketTranslation Parse(string ticketNotesDescription)
        {
            var ticketNotesParts = ticketNotesDescription.Split("\n\n");
            return new TicketTranslation(
                TicketFieldRuleParser.Parse(ticketNotesParts[0]),
                TicketParser.Parse(ticketNotesParts[1]).Single(),
                TicketParser.Parse(ticketNotesParts[2]));
        }
    }
}