using System.Linq;

namespace AdventOfCode._2020.Day05
{
    public static class BoardingPassScanner
    {
        public static int GetHighestSeatId(string boardingPassesDescription)
            => BoardingPassParser
            .ParseBoardingPassesToSeatIds(boardingPassesDescription)
            .Max();
    }
}