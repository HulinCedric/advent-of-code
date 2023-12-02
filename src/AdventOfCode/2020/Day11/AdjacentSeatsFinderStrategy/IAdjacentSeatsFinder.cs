using System.Collections.Generic;

namespace AdventOfCode._2020.Day11.AdjacentSeatsFinderStrategy
{
    public interface IAdjacentSeatsFinder
    {
        IEnumerable<char> GetAdjacentSeatsDescriptionForSeat(
            string[] seatLayoutDescription,
            int centralSeatRowIndex,
            int centralSeatColumnIndex);
    }
}