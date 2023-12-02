using System.Linq;

namespace AdventOfCode._2020.Day05
{
    public static class BoardingPassFinder
    {
        public static int FindAvailableSeatId(string boardingPassesDescription)
        {
            var bookedSeatIds = BoardingPassParser.ParseBoardingPassesToSeatIds(boardingPassesDescription).ToArray();
            var allSeatIds = Enumerable.Range(bookedSeatIds.Min(), bookedSeatIds.Length);
            return allSeatIds.Except(bookedSeatIds).Single();
        }
    }
}