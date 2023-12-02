using AdventOfCode._2020.Day08.Programs;
using Xunit;

namespace AdventOfCode._2020.Day08.Instructions
{
    public class AccumulatorInstructionShould
    {
        [Theory]
        [InlineData(0, 4, 4)]
        [InlineData(0, -4, -4)]
        public void Increase_or_decrease_accumulator_by_argument_value(
            int initialAccumulatorValue,
            int instructionArgument,
            int expectedAccumulatorValue)
        {
            // Given
            var programContext = new ProgramContext(initialAccumulatorValue, 0);
            var instruction = new AccumulatorInstruction(instructionArgument);

            // When
            var executionResult = instruction.Execute(programContext);
            var actualAccumulatorValue = executionResult.AccumulatorValue;

            // Then
            Assert.Equal(expectedAccumulatorValue, actualAccumulatorValue);
        }

        [Theory]
        [InlineData(0, 1)]
        public void Give_immediately_below_instruction_index_after_execution(
            int currentInstructionIndex,
            int expectedNextInstructionIndex)
        {
            // Given
            var programContext = new ProgramContext(0, currentInstructionIndex);
            var instruction = new AccumulatorInstruction(0);

            // When
            var executionResult = instruction.Execute(programContext);
            var actualNextInstructionIndex = executionResult.NextInstructionIndex;

            // Then
            Assert.Equal(expectedNextInstructionIndex, actualNextInstructionIndex);
        }
    }
}