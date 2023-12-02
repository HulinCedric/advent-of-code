using Xunit;

namespace AdventOfCode._2020.Day14
{
    public class MemoryAddressShould
    {
        [Theory]
        [InlineData("000000000000000000000000000000101010", 42U)]
        [InlineData("000000000000000000000000000000011010", 26U)]
        public void Be_construct_through_representation(
            string memoryAddressRepresentation,
            uint expectedPosition)
        {
            // Given
            var expectedMemoryAddress = new MemoryAddress(expectedPosition);

            // When
            var actualMemoryAddress = new MemoryAddress(memoryAddressRepresentation);

            // Then
            Assert.Equal(expectedMemoryAddress, actualMemoryAddress);
        }

        [Theory]
        [InlineData(42U, "000000000000000000000000000000101010")]
        [InlineData(26U, "000000000000000000000000000000011010")]
        public void Be_represented_on_36bits(
            uint position,
            string expectedRepresentation)
        {
            // Given

            // When
            var memoryAddress = new MemoryAddress(position);

            // Then
            Assert.Equal(expectedRepresentation, $"{memoryAddress}");
        }
    }
}