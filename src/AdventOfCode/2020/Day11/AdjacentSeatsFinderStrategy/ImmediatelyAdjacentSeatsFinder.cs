using System.Collections.Generic;

namespace AdventOfCode._2020.Day11.AdjacentSeatsFinderStrategy
{
    public class ImmediatelyAdjacentSeatsFinder : IAdjacentSeatsFinder
    {
        public IEnumerable<char> GetAdjacentSeatsDescriptionForSeat(
            string[] seatLayoutDescription,
            int centralSeatRowIndex,
            int centralSeatColumnIndex)
        {
            var layoutMaxColumnIndex = seatLayoutDescription[0].Length - 1;
            var layoutMaxRowIndex = seatLayoutDescription.Length - 1;
            const int layoutMinColumnIndex = 0;
            const int layoutMinRowIndex = 0;

            for (var seatRowIndex = centralSeatRowIndex - 1; seatRowIndex <= centralSeatRowIndex + 1; seatRowIndex++)
                for (var seatColumnIndex = centralSeatColumnIndex - 1;
                    seatColumnIndex <= centralSeatColumnIndex + 1;
                    seatColumnIndex++)
                    if (seatRowIndex >= layoutMinRowIndex &&
                        seatRowIndex <= layoutMaxRowIndex &&
                        seatColumnIndex >= layoutMinColumnIndex &&
                        seatColumnIndex <= layoutMaxColumnIndex &&
                        !(seatRowIndex == centralSeatRowIndex && seatColumnIndex == centralSeatColumnIndex))
                        yield return seatLayoutDescription[seatRowIndex][seatColumnIndex];
        }
    }
}