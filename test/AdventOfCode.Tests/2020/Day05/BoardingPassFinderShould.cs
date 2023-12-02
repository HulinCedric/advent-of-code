using Xunit;

namespace AdventOfCode._2020.Day05
{
    public class BoardingPassFinderShould
    {
        [Theory]
        [InlineData("FF\nBF", 1)]
        [InlineData("BFF\nFBF", 3)]
        [InputFileData("2020/Day05/input.txt", 517)]
        public void Find_the_only_missing_seat_id_in_full_flight_boarding_passes(
             string boardingPassesDescription,
             int expectedAvailableSeatId)
        {
            //When
            var availableSeatId = BoardingPassFinder.FindAvailableSeatId(boardingPassesDescription);

            //Then
            Assert.Equal(expectedAvailableSeatId, availableSeatId);
        }
    }
}