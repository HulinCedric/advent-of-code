using Xunit;

namespace AdventOfCode._2020.Day15
{
    public class RambunctiousRecitation
    {
        [Theory]
        [InlineData("1,3,2", 2020, 1)]
        [InlineData("2,1,3", 2020, 10)]
        [InlineData("1,2,3", 2020, 27)]
        [InlineData("2,3,1", 2020, 78)]
        [InlineData("3,2,1", 2020, 438)]
        [InlineData("3,1,2", 2020, 1836)]
        [InlineData(StartingNumbers.Example, 2020, 436)]
        [InlineData(StartingNumbers.Example, 30000000, 175_594)]
        [InputFileData("2020/Day15/input.txt", 2020, 441)]
        [InputFileData("2020/Day15/input.txt", 30000000, 10_613_991)]
        public void Determine_the_number_spoken_at_specific_turn(
            string startingNumbers,
            int expectedTurn,
            int expectedSpokenNumber)
        {
            // Given
            var memoryGame = new MemoryGame(startingNumbers);
            var expectedState = new MemoryGameState(expectedTurn, expectedSpokenNumber);

            // When
            memoryGame.PlayUpToTurn(expectedTurn);
            var actualState = memoryGame.State;

            // Then
            Assert.Equal(expectedState, actualState);
        }
    }
}