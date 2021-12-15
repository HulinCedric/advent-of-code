using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace AdventOfCode.Day04
{
    public class BinaryDiagnosticShould
    {
        [Theory]
        [InlineData(
            "7,4,9,5,11,17,23,2,0,14,21,24,10,16,13,6,15,25,12,22,18,20,8,19,3,26,1\n\n22 13 17 11  0\n 8  2 23  4 24\n21  9 14 16  7\n 6 10  3 18  5\n 1 12 20 15 19\n\n 3 15  0  2 22\n 9 18 13 17  5\n19  8  7 25 23\n20 11 10 24  4\n14 21 16 12  6\n\n14 21 17 24  4\n10 16 15  9 19\n18  8 23 26 20\n22 11 13  6  5\n 2  0 12  3  7",
            4512)]
        [InputFileData("Day04/input.txt", 28082)]
        public void What_will_your_final_score_be_if_you_choose_that_board(
            string gameNumbersAndBoardsRepresentation,
            int expectedWinningScore)
        {
            // Given
            var (randomNumbers, bingoGame) = BingoGameFactory.CreateRandomNumbersAndBoardsRepresentation(
                gameNumbersAndBoardsRepresentation);

            // When
            var randomNumberIndex = 0;
            while (bingoGame.HasNotWinner)
            {
                var drawNumber = randomNumbers[randomNumberIndex++];
                bingoGame.AnnounceNumber(drawNumber);
            }

            var actualWinningScore = bingoGame.WinningScore;

            // Then
            actualWinningScore.Should().Be(expectedWinningScore);
        }
    }

    public class BingoGame
    {
        private readonly BingoBoard[] bingoBoards;


        public BingoGame(BingoBoard[] bingoBoards)
            => this.bingoBoards = bingoBoards;

        public bool HasNotWinner
            => bingoBoards.All(board => board.HasNotWon);

        public int WinningScore { get; private set; }

        public void AnnounceNumber(int drawNumber)
        {
            foreach (var bingoBoard in bingoBoards)
                bingoBoard.Mark(drawNumber);

            WinningScore = bingoBoards.FirstOrDefault(board => board.HasWon)?.WinningScore ?? 0;
        }
    }

    public static class BingoGameFactory
    {
        public static (int[], BingoGame) CreateRandomNumbersAndBoardsRepresentation(
            string gameNumbersAndBoardsRepresentation)
        {
            var splitRepresentation = gameNumbersAndBoardsRepresentation.Split("\n\n");

            var randomNumbers = ExtractRandomNumbers(splitRepresentation);

            var bingoBoards = ExtractBingoBoard(splitRepresentation).ToArray();

            return (randomNumbers, new BingoGame(bingoBoards));
        }

        private static IEnumerable<BingoBoard> ExtractBingoBoard(string[] splitRepresentation)
            => splitRepresentation
                .Skip(1)
                .Select(BingoBoardFactory.CreateWithRepresentation);

        private static int[] ExtractRandomNumbers(string[] splitRepresentation)
            => splitRepresentation[0]
                .Split(",")
                .Select(int.Parse)
                .ToArray();
    }
}