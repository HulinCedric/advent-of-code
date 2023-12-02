using System.Linq;
using Xunit;

namespace AdventOfCode._2020.Day13
{
    public class ShuttleSearch
    {
        [Theory]
        [InlineData(NotesDescription.Example, 59, 5)]
        [InputFileData("2020/Day13/input.txt", 19, 9)]
        public void Determine_the_earliest_bus_id_and_the_waiting_minutes_to_take_it(
            string notesDescription,
            int expectedEarliestBusId,
            int expectedWaitingMinutes)
        {
            // Given
            var notes = NotesParser.Parse(notesDescription);
            var departureTimestamp = notes.EarliestDepartureTimestamp;
            var buses = notes.Buses;

            // When
            var (earliestBus, nextDepartTimestamp) = buses
                .OfType<InServiceBus>()
                .Select(bus => (bus, nextDepartTimestamp: bus.GetNextDepartTimestamp(departureTimestamp)))
                .OrderBy(busWithNextDepart => busWithNextDepart.nextDepartTimestamp)
                .First();
            var actualEarliestBusId = earliestBus.Id;
            var actualWaitingMinutes = nextDepartTimestamp - departureTimestamp;

            // Then
            Assert.Equal(expectedEarliestBusId, actualEarliestBusId);
            Assert.Equal(expectedWaitingMinutes, actualWaitingMinutes);
        }

        [Theory]
        [InlineData(NotesDescription.Example, 1_068_781L)]
        [InputFileData("2020/Day13/input.txt", 539_746_751_134_958L)]
        public void
            Determine_the_earliest_timestamp_such_that_all_of_the_listed_bus_depart_at_offsets_matching_their_positions_in_the_list(
                string notesDescription,
                long expectedEarliestTimestamp)
        {
            // Given
            var notes = NotesParser.Parse(notesDescription);
            var buses = notes.Buses.ToList();

            // When
            var actualCommonDepartureTimestamp = buses.Cast<InServiceBus>().Select(bus => (long)bus.Id).First();
            var increment = actualCommonDepartureTimestamp;
            foreach (var (bus, busPosition) in buses.Skip(1).Select((bus, index) => (bus, index + 1)))
                switch (bus)
                {
                    case OutOfServiceBus:
                        continue;
                    case InServiceBus inServiceBus:
                        (actualCommonDepartureTimestamp, increment) =
                            BusTimestampCalculator.ComputeCommonDepartureTimestamp(
                                inServiceBus,
                                busPosition,
                                actualCommonDepartureTimestamp,
                                increment);
                        break;
                }

            // Then
            Assert.Equal(expectedEarliestTimestamp, actualCommonDepartureTimestamp);
        }
    }
}