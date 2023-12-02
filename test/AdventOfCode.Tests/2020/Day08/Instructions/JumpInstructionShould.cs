using AdventOfCode._2020.Day08.Programs;
using Xunit;

namespace AdventOfCode._2020.Day08.Instructions
{
    public class JumpInstructionShould
    {
        [Theory]
        [InlineData(0, 4, 4)]
        [InlineData(4, -4, 0)]
        public void Give_next_instruction_index_based_on_argument_value(
            int currentInstructionIndex,
            int instructionArgumentValue,
            int expectedNextInstructionIndex)
        {
            // Given
            var programContext = new ProgramContext(0, currentInstructionIndex);
            var instruction = new JumpInstruction(instructionArgumentValue);

            // When
            var executionResult = instruction.Execute(programContext);
            var actualNextInstructionIndex = executionResult.NextInstructionIndex;

            // Then
            Assert.Equal(expectedNextInstructionIndex, actualNextInstructionIndex);
        }
    }
}