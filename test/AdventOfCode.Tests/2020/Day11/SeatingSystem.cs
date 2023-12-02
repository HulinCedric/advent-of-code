using System;
using AdventOfCode._2020.Day11.AdjacentSeatsFinderStrategy;
using Xunit;

namespace AdventOfCode._2020.Day11
{
    public class SeatingSystem
    {
        private static IAdjacentSeatsFinder InstantiateAdjacentSeatsFinderStrategy(Type adjacentSeatsFinderStrategyType)
            => Activator.CreateInstance(adjacentSeatsFinderStrategyType) is IAdjacentSeatsFinder
                adjacentSeatsFinderStrategy ?
                adjacentSeatsFinderStrategy :
                throw new InvalidOperationException(
                    $"Couldn't instantiate {nameof(IAdjacentSeatsFinder)} for {nameof(adjacentSeatsFinderStrategyType)}");

        [Theory]
        [InlineData(SeatLayoutDescription.Example, 4, typeof(ImmediatelyAdjacentSeatsFinder), 37)]
        [InlineData(SeatLayoutDescription.Example, 5, typeof(FirstEncounteredAdjacentSeatsFinder), 26)]
        [InputFileData("2020/Day11/input.txt", 4, typeof(ImmediatelyAdjacentSeatsFinder), 2277)]
        [InputFileData("2020/Day11/input.txt", 5, typeof(FirstEncounteredAdjacentSeatsFinder), 2066)]
        public void Count_seats_occupied_when_people_stop_moving(
            string seatLayoutDescription,
            int peopleTolerance,
            Type adjacentSeatsFinderStrategyType,
            int expectedSeatsOccupiedCount)
        {
            // Given
            var adjacentSeatsFinderStrategy = InstantiateAdjacentSeatsFinderStrategy(adjacentSeatsFinderStrategyType);
            var seatLayout = SeatLayoutParser.Parse(seatLayoutDescription);
            var seatAllocationSimulator = new SeatAllocationSimulator(peopleTolerance, adjacentSeatsFinderStrategy);

            // When
            var allocationSimulation = seatAllocationSimulator.SimulateAllocation(seatLayout);
            var actualSeatsOccupiedCount = allocationSimulation.CountOccupiedSeats();

            // Then
            Assert.Equal(expectedSeatsOccupiedCount, actualSeatsOccupiedCount);
        }
    }
}