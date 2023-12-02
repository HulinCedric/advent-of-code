using System;
using System.Linq;
using System.Text;
using AdventOfCode._2020.Day11.AdjacentSeatsFinderStrategy;

namespace AdventOfCode._2020.Day11
{
    public class SeatLayout
    {
        private readonly string[] seatLayout;

        public SeatLayout(string[] seatLayout)
            => this.seatLayout = seatLayout;


        public int CountOccupiedSeats()
            => string.Join('\n', seatLayout)
                .Count(seat => seat == '#');

        public SeatLayout NextRound(int peopleTolerance, IAdjacentSeatsFinder adjacentSeatsFinder)
        {
            var nextRoundSeatLayout = new string[seatLayout.Length];
            for (var rowIndex = 0; rowIndex < seatLayout.Length; rowIndex++)
            {
                var seatRow = seatLayout[rowIndex];
                var seatRowBuilder = new StringBuilder();
                for (var columnIndex = 0; columnIndex < seatRow.Length; columnIndex++)
                {
                    var seat = seatRow[columnIndex];
                    var adjacentSeats = adjacentSeatsFinder.GetAdjacentSeatsDescriptionForSeat(
                        seatLayout,
                        rowIndex,
                        columnIndex);
                    var newSeat = seat switch
                    {
                        'L' when adjacentSeats.All(s => s != '#') => '#',
                        '#' when adjacentSeats.Count(s => s == '#') >= peopleTolerance => 'L',
                        _ => seat
                    };

                    seatRowBuilder.Append(newSeat);
                }

                nextRoundSeatLayout[rowIndex] = seatRowBuilder.ToString();
            }

            return new SeatLayout(nextRoundSeatLayout);
        }

        private bool Equals(SeatLayout other)
            => seatLayout.Zip(other.seatLayout)
                .All(
                    seatsElementsToCompare
                        => string.Equals(
                            seatsElementsToCompare.First,
                            seatsElementsToCompare.Second,
                            StringComparison.OrdinalIgnoreCase));

        public override bool Equals(object? obj)
            => obj?.GetType() == GetType() && Equals((SeatLayout)obj);

        public override int GetHashCode()
            => seatLayout.GetHashCode();

        public static bool operator ==(SeatLayout left, SeatLayout right)
            => Equals(left, right);

        public static bool operator !=(SeatLayout left, SeatLayout right)
            => !Equals(left, right);
    }
}