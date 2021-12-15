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

        [Theory]
        [InlineData(
            "14 21 17 24  4\n10 16 15  9 19\n18  8 23 26 20\n22 11 13  6  5\n 2  0 12  3  7",
            new[] { 14, 21, 17, 24, 4 })]
        [InlineData(
            "14 21 17 24  4\n10 16 15  9 19\n18  8 23 26 20\n22 11 13  6  5\n 2  0 12  3  7",
            new[] { 18, 8, 23, 26, 20 })]
        public void Win_when_all_number_of_a_row_is_marked(
            string boardRepresentation,
            int[] drawNumbers)
        {
            // Given
            var bingoBoard = BingoBoardFactory.CreateWithRepresentation(boardRepresentation);
            foreach (var drawNumber in drawNumbers)
                bingoBoard.Mark(drawNumber);

            // When
            var hasWon = bingoBoard.HasWon;

            // Then
            hasWon.Should().BeTrue();
        }

        [Theory]
        [InlineData(
            "14 21 17 24  4\n10 16 15  9 19\n18  8 23 26 20\n22 11 13  6  5\n 2  0 12  3  7",
            new[] { 14, 10, 18, 22, 2 })]
        [InlineData(
            "14 21 17 24  4\n10 16 15  9 19\n18  8 23 26 20\n22 11 13  6  5\n 2  0 12  3  7",
            new[] { 17, 15, 23, 13, 12 })]
        public void Win_when_all_number_of_a_column_is_marked(
            string boardRepresentation,
            int[] drawNumbers)
        {
            // Given
            var bingoBoard = BingoBoardFactory.CreateWithRepresentation(boardRepresentation);
            foreach (var drawNumber in drawNumbers)
                bingoBoard.Mark(drawNumber);

            // When
            var hasWon = bingoBoard.HasWon;

            // Then
            hasWon.Should().BeTrue();
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

        public bool HasWon
            => ContainWinningSet(NumbersByRow) || ContainWinningSet(NumbersByColumn);

        public IEnumerable<int> MarkedNumbers
            => numbers.SelectMany(rowNumbers => rowNumbers)
                .Where(number => number.IsMarked)
                .Select(number => number.Value);

        private IEnumerable<IEnumerable<BoardNumber>> NumbersByColumn
            => numbers.SelectMany(
                    (rowNumbers, rowIndex) => rowNumbers
                        .Select((number, columnIndex) => new { number, columnIndex, rowIndex }))
                .GroupBy(flatten => flatten.columnIndex)
                .Select(
                    numbersGroupedByColumn => numbersGroupedByColumn
                        .Select(flatten => flatten.number));

        private IEnumerable<IEnumerable<BoardNumber>> NumbersByRow
            => numbers;

        private bool ContainWinningSet(IEnumerable<IEnumerable<BoardNumber>> numberSet)
            => numberSet.Any(rowNumbers => rowNumbers.All(number => number.IsMarked));

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