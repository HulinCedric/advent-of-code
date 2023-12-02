using Xunit;

namespace AdventOfCode._2020.Day14
{
    public class BitMaskShould
    {
        [Fact]
        public void Have_a_default_value()
        {
            // Given
            var expectedMask = new BitMask("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");

            // When
            var actualMask = BitMask.Default;

            // Then
            Assert.Equal(expectedMask, actualMask);
        }

        [Theory]
        [InlineData(42U, "000000000000000000000000000000X1001X", "000000000000000000000000000000X1101X")]
        [InlineData(26U, "00000000000000000000000000000000X0XX", "00000000000000000000000000000001X0XX")]
        public void Overwrite_memory_address(
            uint position,
            string maskDescription,
            string expectedRepresentation)
        {
            // Given
            // var expectedMemoryAddress = new MemoryAddress(expectedRepresentation);
            var memoryAddress = new MemoryAddress(position);
            var mask = new BitMask(maskDescription);

            // When
            var overwrittenMemoryAddress = mask.Overwrite(memoryAddress);

            // Then
            Assert.Equal(expectedRepresentation, overwrittenMemoryAddress);
        }

        [Theory]
        [InlineData(11, "XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X", "000000000000000000000000000001001001")]
        [InlineData(101, "XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X", "000000000000000000000000000001100101")]
        [InlineData(0, "XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X", "000000000000000000000000000001000000")]
        public void Overwrite_memory_value(
            long value,
            string maskDescription,
            string expectedRepresentation)
        {
            // Given
            var expectedMemoryValue = new MemoryValue(expectedRepresentation);
            var memoryValue = new MemoryValue(value);
            var mask = new BitMask(maskDescription);

            // When
            var overwrittenMemoryValue = mask.Overwrite(memoryValue);

            // Then
            Assert.Equal(expectedMemoryValue, overwrittenMemoryValue);
        }
    }
}