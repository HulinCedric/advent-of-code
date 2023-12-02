using Xunit;

namespace AdventOfCode._2020.Day14
{
    public class MemoryShould
    {
        [Fact]
        public void Get_value()
        {
            // Given
            var memory = new Memory(new Memory.OverwriteStrategy());
            var expectedMemoryValue = new MemoryValue(11);
            var memoryAddress = new MemoryAddress(8);
            memory.WriteAt(memoryAddress, new MemoryValue(11));

            // When
            var actualMemoryValue = memory.ValueAt(8);

            // Then
            Assert.Equal(expectedMemoryValue, actualMemoryValue);
        }

        [Fact]
        public void Overwrite_value_when_write_at_same_address()
        {
            // Given
            var memory = new Memory(new Memory.OverwriteStrategy());
            var memoryAddress = new MemoryAddress(8);

            // When
            memory.WriteAt(memoryAddress, new MemoryValue(11));
            memory.WriteAt(memoryAddress, new MemoryValue(12));

            // Then
            Assert.NotEmpty(memory.Values);
            Assert.Equal(1, memory.Values.Count);
        }

        [Fact]
        public void Sum_all_values()
        {
            // Given
            var memory = new Memory(new Memory.OverwriteStrategy());
            var eightMemoryAddress = new MemoryAddress(8);
            var seventhMemoryAddress = new MemoryAddress(7);
            var mask = new BitMask("XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X");

            memory.UpdateBitMask(mask);

            memory.WriteAt(eightMemoryAddress, new MemoryValue(11));
            memory.WriteAt(seventhMemoryAddress, new MemoryValue(101));
            memory.WriteAt(eightMemoryAddress, new MemoryValue(0));

            var expectedSumMemoryValue = new MemoryValue(165);

            // When
            var actualSumMemoryValue = memory.Sum;

            // Then
            Assert.Equal(expectedSumMemoryValue, actualSumMemoryValue);
        }

        [Fact]
        public void Update_bitmask()
        {
            // Given
            var memory = new Memory(new Memory.OverwriteStrategy());
            var expectedMask = new BitMask("XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X");

            // When
            memory.UpdateBitMask(expectedMask);

            // Then
            Assert.Equal(expectedMask, memory.BitMask);
        }

        [Theory]
        [InlineData(11, "XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X", "000000000000000000000000000001001001")]
        [InlineData(101, "XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X", "000000000000000000000000000001100101")]
        [InlineData(0, "XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X", "000000000000000000000000000001000000")]
        public void Write_value_with_bitmask_overwrite_value(
            long value,
            string maskDescription,
            string expectedRepresentation)
        {
            // Given
            var memory = new Memory(new Memory.OverwriteStrategy());
            memory.UpdateBitMask(new BitMask(maskDescription));
            var expectedMemoryValue = new MemoryValue(expectedRepresentation);

            // When
            memory.WriteAt(new MemoryAddress(1), new MemoryValue(value));

            // Then
            Assert.Equal(expectedMemoryValue, memory.ValueAt(1));
        }
    }
}