using Xunit;

namespace AdventOfCode._2020.Day14
{
    public class InitializationProgramInterpreterShould
    {
        [Theory]
        [InlineData("mem[8] = 11", 8, 11)]
        [InlineData("mem[7] = 101", 7, 101)]
        public void Read_set_memory_instruction(string programInstruction, uint memoryPosition, long value)
        {
            // Given
            var expectedMemoryValue = new MemoryValue(value);

            // When
            var actualMemory = InitializationProgramInterpreter.ExecuteInstruction(
                new Memory(new Memory.OverwriteStrategy()),
                programInstruction);
            var actualMemoryValue = actualMemory.ValueAt(memoryPosition);

            // Then
            Assert.Equal(expectedMemoryValue, actualMemoryValue);
        }

        [Theory]
        [InlineData("mask = XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X", "XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X")]
        [InlineData("mask = X11XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", "X11XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX")]
        public void Read_update_bitmask_instruction(string programInstruction, string expectedBitmaskDescription)
        {
            // Given
            var expectedBitMask = new BitMask(expectedBitmaskDescription);

            // When
            var actualMemory = InitializationProgramInterpreter.ExecuteInstruction(
                new Memory(new Memory.OverwriteStrategy()),
                programInstruction);

            // Then
            Assert.Equal(expectedBitMask, actualMemory.BitMask);
        }
    }
}