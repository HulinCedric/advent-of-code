using Xunit;

namespace AdventOfCode._2020.Day05
{

    public class BoardingPassParserShould
    {
        [Theory]
        [InlineData("F\nB", new[] { 0, 1 })]
        public void Parse_boarding_passes_to_seat_ids(
            string boardingPassesDescription,
            int[] expectedSeatIds)
        {
            //When
            var seatIds = BoardingPassParser.ParseBoardingPassesToSeatIds(boardingPassesDescription);

            //Then
            Assert.Equal(expectedSeatIds, seatIds);
        }
    }
}