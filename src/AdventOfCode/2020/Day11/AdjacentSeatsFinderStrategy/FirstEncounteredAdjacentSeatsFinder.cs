using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2020.Day11.AdjacentSeatsFinderStrategy
{
    public class FirstEncounteredAdjacentSeatsFinder : IAdjacentSeatsFinder
    {
        public IEnumerable<char> GetAdjacentSeatsDescriptionForSeat(
            string[] seatLayoutDescription,
            int centralSeatRowIndex,
            int centralSeatColumnIndex)
            => from direction in Directions.All
               select FirstSeatInDirection(
                   seatLayoutDescription,
                   centralSeatRowIndex,
                   centralSeatColumnIndex,
                   direction)
                into potentialSeat
               where potentialSeat != null
               select potentialSeat.Value;

        private static char? FirstSeatInDirection(
            IReadOnlyList<string> seatLayoutDescription,
            int centralSeatRowIndex,
            int centralSeatColumnIndex,
            (int rowDirection, int columnDirection) direction)

        {
            var layoutMaxColumnIndex = seatLayoutDescription[0].Length - 1;
            var layoutMaxRowIndex = seatLayoutDescription.Count - 1;
            const int layoutMinColumnIndex = 0;
            const int layoutMinRowIndex = 0;

            var currentSeatCoords = (rowIndex: centralSeatRowIndex, columnIndex: centralSeatColumnIndex);
            do
            {
                var (rowDirection, columnDirection) = direction;
                currentSeatCoords = (
                    currentSeatCoords.rowIndex + rowDirection,
                    currentSeatCoords.columnIndex + columnDirection);

                if (currentSeatCoords.rowIndex < layoutMinRowIndex ||
                    currentSeatCoords.rowIndex > layoutMaxRowIndex ||
                    currentSeatCoords.columnIndex < layoutMinColumnIndex ||
                    currentSeatCoords.columnIndex > layoutMaxColumnIndex)
                    break;

                var currentSeatDescription =
                    seatLayoutDescription[currentSeatCoords.rowIndex][currentSeatCoords.columnIndex];
                if (currentSeatDescription != '.')
                    return currentSeatDescription;
            } while (true);

            return null;
        }

        private static class Directions
        {
            private static readonly (int, int) Up = (-1, 0);
            private static readonly (int, int) Down = (1, 0);
            private static readonly (int, int) Left = (0, -1);
            private static readonly (int, int) Right = (0, 1);
            private static readonly (int, int) UpRight = (-1, 1);
            private static readonly (int, int) DownRight = (1, 1);
            private static readonly (int, int) UpLeft = (-1, -1);
            private static readonly (int, int) DownLeft = (1, -1);

            internal static readonly (int, int)[] All =
            {
                Up, Down, Left, Right, UpRight, DownRight, UpLeft, DownLeft
            };
        }
    }
}