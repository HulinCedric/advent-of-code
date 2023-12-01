using System.Linq;
using FluentAssertions;
using Xunit;

namespace AdventOfCode._2021.Day04
{
    public class BinaryDiagnosticShould
    {
        [Theory]
        [InlineData(
            "7,4,9,5,11,17,23,2,0,14,21,24,10,16,13,6,15,25,12,22,18,20,8,19,3,26,1\n\n22 13 17 11  0\n 8  2 23  4 24\n21  9 14 16  7\n 6 10  3 18  5\n 1 12 20 15 19\n\n 3 15  0  2 22\n 9 18 13 17  5\n19  8  7 25 23\n20 11 10 24  4\n14 21 16 12  6\n\n14 21 17 24  4\n10 16 15  9 19\n18  8 23 26 20\n22 11 13  6  5\n 2  0 12  3  7",
            4512)]
        [InputFileData("2021/Day04/input.txt", 28082)]
        public void What_will_the_final_score_of_the_first_winning_board(
            string gameNumbersAndBoardsRepresentation,
            int expectedWinningScore)
        {
            // Given
            var (randomNumbers, bingoGame) = BingoGameFactory.CreateRandomNumbersAndBoardsRepresentation(
                gameNumbersAndBoardsRepresentation);

            // When
            foreach (var drawNumber in randomNumbers)
                bingoGame.AnnounceNumber(drawNumber);

            var actualWinningScore = bingoGame.LeaderBoardScores.First();

            // Then
            actualWinningScore.Should().Be(expectedWinningScore);
        }

        [Theory]
        [InlineData(
            "7,4,9,5,11,17,23,2,0,14,21,24,10,16,13,6,15,25,12,22,18,20,8,19,3,26,1\n\n22 13 17 11  0\n 8  2 23  4 24\n21  9 14 16  7\n 6 10  3 18  5\n 1 12 20 15 19\n\n 3 15  0  2 22\n 9 18 13 17  5\n19  8  7 25 23\n20 11 10 24  4\n14 21 16 12  6\n\n14 21 17 24  4\n10 16 15  9 19\n18  8 23 26 20\n22 11 13  6  5\n 2  0 12  3  7",
            1924)]
        [InputFileData("2021/Day04/input.txt", 8224)]
        public void What_will_the_final_score_of_the_last_winning_board(
            string gameNumbersAndBoardsRepresentation,
            int expectedWinningScore)
        {
            // Given
            var (randomNumbers, bingoGame) = BingoGameFactory.CreateRandomNumbersAndBoardsRepresentation(
                gameNumbersAndBoardsRepresentation);

            // When
            foreach (var drawNumber in randomNumbers)
                bingoGame.AnnounceNumber(drawNumber);

            var actualWinningScore = bingoGame.LeaderBoardScores.Last();

            // Then
            actualWinningScore.Should().Be(expectedWinningScore);
        }
    }
}