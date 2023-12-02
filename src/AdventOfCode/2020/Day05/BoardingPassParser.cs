using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2020.Day05
{
    public static class BoardingPassParser
    {
        public static IEnumerable<int> ParseBoardingPassesToSeatIds(string boardingPassesDescription)
            => boardingPassesDescription
            .Split("\n")
            .Select(SeatIdDecoder.Decode);
    }
}