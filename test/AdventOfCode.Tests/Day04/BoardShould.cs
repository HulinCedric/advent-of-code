using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace AdventOfCode.Day04
{
    public class BoardShould
    {
        [Theory]
        [InlineData(
            "14 21 17 24  4\n10 16 15  9 19\n18  8 23 26 20\n22 11 13  6  5\n 2  0 12  3  7",
            4)]
        [InlineData(
            "14 21 17 24  4\n10 16 15  9 19\n18  8 23 26 20\n22 11 13  6  5\n 2  0 12  3  7",
            14)]
        public void Mark_number_when_contain_draw_number(
            string boardRepresentation,
            int expectedDrawNumber)
        {
            // Given
            var bingoBoard = BingoBoardFactory.CreateWithRepresentation(boardRepresentation);

            // When
            bingoBoard.Mark(expectedDrawNumber);

            var markedNumbers = bingoBoard.MarkedNumbers;

            // Then
            markedNumbers.Should().Contain(expectedDrawNumber);
        }
    }

    public static class BingoBoardFactory
    {
        public static BingoBoard CreateWithRepresentation(string boardRepresentation)
            => new(
                boardRepresentation
                    .Split("\n")
                    .Select(
                        row => row
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray()));
    }

    public class BingoBoard
    {
        private readonly BoardNumber[][] numbers;

        public BingoBoard(IEnumerable<int[]> numbers)
            => this.numbers = numbers
                   .Select(rowNumbers => rowNumbers.Select(number => new BoardNumber(number)).ToArray())
                   .ToArray();

        public IEnumerable<int> MarkedNumbers
            => numbers.SelectMany(rowNumbers => rowNumbers)
                .Where(number => number.IsMarked)
                .Select(number => number.Value);

        public void Mark(int drawNumber)
        {
            foreach (var rowNumbers in numbers)
            foreach (var number in rowNumbers)
                if (number.Value == drawNumber)
                    number.IsMarked = true;
        }

        private record BoardNumber(int Value)
        {
            internal bool IsMarked { get; set; }
        }
    }
}