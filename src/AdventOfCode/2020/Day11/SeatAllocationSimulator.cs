using AdventOfCode._2020.Day11.AdjacentSeatsFinderStrategy;

namespace AdventOfCode._2020.Day11
{
    public class SeatAllocationSimulator
    {
        private readonly IAdjacentSeatsFinder adjacentSeatsFinderStrategy;
        private readonly int peopleTolerance;

        public SeatAllocationSimulator(
            int peopleTolerance,
            IAdjacentSeatsFinder adjacentSeatsFinderStrategy)
        {
            this.peopleTolerance = peopleTolerance;
            this.adjacentSeatsFinderStrategy = adjacentSeatsFinderStrategy;
        }

        public SeatLayout SimulateAllocation(SeatLayout seatLayout)
        {
            var nextSeatLayoutSimulation = seatLayout;

            do
            {
                seatLayout = nextSeatLayoutSimulation;
                nextSeatLayoutSimulation = seatLayout.NextRound(peopleTolerance, adjacentSeatsFinderStrategy);
            } while (nextSeatLayoutSimulation != seatLayout);

            return seatLayout;
        }
    }
}