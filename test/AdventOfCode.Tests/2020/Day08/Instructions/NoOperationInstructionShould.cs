using AdventOfCode._2020.Day08.Programs;
using Xunit;

namespace AdventOfCode._2020.Day08.Instructions
{
    public class NoOperationInstructionShould
    {
        [Theory]
        [InlineData(0, 0, 0, 1, 0)]
        public void Not_change_accumulator_and_give_immediately_below_instruction_index(
            int currentInstructionIndex,
            int initialAccumulatorValue,
            int instructionArgumentValue,
            int expectedNextInstructionIndex,
            int expectedAccumulatorValue)
        {
            // Given
            var programContext = new ProgramContext(initialAccumulatorValue, currentInstructionIndex);
            var instruction = new NoOperationInstruction(instructionArgumentValue);

            // When
            var (actualNextInstructionIndex, actualAccumulatorValue) = instruction.Execute(programContext);

            // Then
            Assert.Equal(expectedNextInstructionIndex, actualNextInstructionIndex);
            Assert.Equal(expectedAccumulatorValue, actualAccumulatorValue);
        }
    }
}