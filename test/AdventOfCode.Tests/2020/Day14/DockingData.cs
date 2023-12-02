using System.Linq;
using Xunit;

namespace AdventOfCode._2020.Day14
{
    public class DockingData
    {
        [Theory]
        [InlineData(InitializationProgramDescription.Example, 165)]
        [InputFileData("2020/Day14/input.txt", 15514035145260)]
        public void Determine_the_sum_of_all_values_left_in_memory_after_it_completes(
            string initializationProgramDescription,
            long expectedSum)
        {
            // Given
            var programInstructions = initializationProgramDescription.Split("\n");
            var memory = new Memory(new Memory.OverwriteStrategy());
            var expectedSumMemoryValue = new MemoryValue(expectedSum);

            // When
            memory = programInstructions.Aggregate(
                memory,
                InitializationProgramInterpreter.ExecuteInstruction);

            var actualSumMemoryValue = memory.Sum;

            // Then
            Assert.Equal(expectedSumMemoryValue, actualSumMemoryValue);
        }

        [Theory]
        [InlineData(InitializationProgramDescription.DecodeExample, 208)]
        [InputFileData("2020/Day14/input.txt", 3926790061594)]
        public void Determine_the_sum_of_all_values_left_in_memory_after_read_and_decode(
            string initializationProgramDescription,
            long expectedSum)
        {
            // Given
            var programInstructions = initializationProgramDescription.Split("\n");
            var memory = new Memory(new Memory.DecodeStrategy());
            var expectedSumMemoryValue = new MemoryValue(expectedSum);

            // When
            memory = programInstructions.Aggregate(
                memory,
                InitializationProgramInterpreter.ExecuteInstruction);

            var actualSumMemoryValue = memory.Sum;

            // Then
            Assert.Equal(expectedSumMemoryValue, actualSumMemoryValue);
        }
    }
}