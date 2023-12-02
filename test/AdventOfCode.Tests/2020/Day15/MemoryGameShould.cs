using Xunit;

namespace AdventOfCode._2020.Day15
{
    public class MemoryGameShould
    {
        [Theory]
        [InlineData("0,1", 2, 1)]
        [InlineData(StartingNumbers.Example, 3, 6)]
        [InputFileData("2020/Day15/input.txt", 6, 6)]
        public void Have_turn_equals_to_starting_numbers_count(
            string startingNumbers,
            int expectedTurn,
            int expectedNumberSpoken)
        {
            // Given
            var memoryGame = new MemoryGame(startingNumbers);
            var expectedState = new MemoryGameState(expectedTurn, expectedNumberSpoken);

            // When
            var actualState = memoryGame.State;

            // Then
            Assert.Equal(expectedState, actualState);
        }

        [Theory]
        [InlineData(StartingNumbers.Example, 4, 0)]
        [InlineData(StartingNumbers.Example, 5, 3)]
        [InlineData(StartingNumbers.Example, 6, 3)]
        [InlineData(StartingNumbers.Example, 7, 1)]
        [InlineData(StartingNumbers.Example, 8, 0)]
        [InlineData(StartingNumbers.Example, 9, 4)]
        [InlineData(StartingNumbers.Example, 10, 0)]
        public void Play_until_specific_turn(
            string startingNumbers,
            int expectedTurn,
            int expectedNumberSpoken)
        {
            // Given
            var memoryGame = new MemoryGame(startingNumbers);
            var expectedState = new MemoryGameState(expectedTurn, expectedNumberSpoken);

            // When
            memoryGame.PlayUpToTurn(expectedTurn);
            var actualState = memoryGame.State;

            // Then
            Assert.Equal(expectedState, actualState);
        }

        [Theory]
        [InlineData("0,1", 4, 2)]
        [InlineData(StartingNumbers.Example, 5, 3)]
        [InputFileData("2020/Day15/input.txt", 8, 5)]
        public void Said_age_when_meet_already_spoken_number(
            string startingNumbers,
            int expectedTurn,
            int expectedNumberSpoken)
        {
            // Given
            var memoryGame = new MemoryGame(startingNumbers);
            var expectedState = new MemoryGameState(expectedTurn, expectedNumberSpoken);

            // When
            memoryGame.Play();
            memoryGame.Play();
            var actualState = memoryGame.State;

            // Then
            Assert.Equal(expectedState, actualState);
        }

        [Theory]
        [InlineData("0,1", 3, 0)]
        [InlineData(StartingNumbers.Example, 4, 0)]
        [InputFileData("2020/Day15/input.txt", 7, 0)]
        public void Said_zero_when_meet_first_number_spoken(
            string startingNumbers,
            int expectedTurn,
            int expectedNumberSpoken)
        {
            // Given
            var memoryGame = new MemoryGame(startingNumbers);
            var expectedState = new MemoryGameState(expectedTurn, expectedNumberSpoken);

            // When
            memoryGame.Play();
            var actualState = memoryGame.State;

            // Then
            Assert.Equal(expectedState, actualState);
        }
    }
}