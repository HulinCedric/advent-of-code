using Xunit;

namespace AdventOfCode._2020.Day14
{
    public class MemoryValueShould
    {
        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(3, 6, 9)]
        public void Be_add_up(
            long firstValue,
            long secondValue,
            long totalValue)
        {
            // Given
            var firstMemoryValue = new MemoryValue(firstValue);
            var secondMemoryValue = new MemoryValue(secondValue);
            var expectedTotalMemoryValue = new MemoryValue(totalValue);

            // When
            var actualTotalMemoryValue = firstMemoryValue + secondMemoryValue;

            // Then
            Assert.Equal(expectedTotalMemoryValue, actualTotalMemoryValue);
        }

        [Theory]
        [InlineData("000000000000000000000000000000001011", 11)]
        [InlineData("000000000000000000000000000001100101", 101)]
        [InlineData("000000000000000000000000000000000000", 0)]
        public void Be_construct_through_representation(
            string memoryValueRepresentation,
            long expectedValue)
        {
            // Given
            var expectedMemoryValue = new MemoryValue(expectedValue);

            // When
            var actualMemoryValue = new MemoryValue(memoryValueRepresentation);

            // Then
            Assert.Equal(expectedMemoryValue, actualMemoryValue);
        }

        [Theory]
        [InlineData(11, "000000000000000000000000000000001011")]
        [InlineData(101, "000000000000000000000000000001100101")]
        [InlineData(0, "000000000000000000000000000000000000")]
        public void Be_represented_on_36bits(
            long value,
            string expectedRepresentation)
        {
            // Given

            // When
            var memValue = new MemoryValue(value);

            // Then
            Assert.Equal(expectedRepresentation, $"{memValue}");
        }
    }
}