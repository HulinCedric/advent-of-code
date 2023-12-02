using Xunit;

namespace AdventOfCode._2020.Day05
{
    public class SeatIdDecoderShould
    {
        [Theory]
        [InlineData("FBFBBFFRLR", 357)]
        [InlineData("BFFFBBFRRR", 567)]
        [InlineData("FFFBBBFRRR", 119)]
        [InlineData("BBFFBBFRLL", 820)]
        public void Decode_seat_description_to_seat_id(
            string boardingPassDescription,
            int expectedSeatId)
        {
            //When
            var seatId = SeatIdDecoder.Decode(boardingPassDescription);

            //Then
            Assert.Equal(expectedSeatId, seatId);
        }
    }
}