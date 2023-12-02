namespace AdventOfCode._2020.Day11
{
    public static class SeatLayoutParser
    {
        public static SeatLayout Parse(string seatLayoutDescription)
            => new(seatLayoutDescription.Split("\n"));
    }
}