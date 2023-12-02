using AdventOfCode._2020.Day08.Programs;
using AdventOfCode._2020.Day08.Runners;
using Xunit;

namespace AdventOfCode._2020.Day08.Fixers
{
    public class ProgramFixerShould
    {
        [Theory]
        [InlineData(
            ProgramDescription.InfiniteLoopExampleDescription,
            ProgramDescription.TerminableExampleDescription)]
        public void Fix_infinite_loop_program_by_switching_only_one_instruction(
            string infiniteLoopProgramDescription,
            string expectedTerminableProgramDescription)
        {
            // Given
            var infiniteLoopProgram = ProgramParser.Parse(infiniteLoopProgramDescription);
            var expectedFixedProgram = ProgramParser.Parse(expectedTerminableProgramDescription);

            // When
            var actualFixedProgram = ProgramFixer.Fix(infiniteLoopProgram);
            var executionResult = IsolatedProgramRunner.Execute(actualFixedProgram);

            // Then
            Assert.Equal(expectedFixedProgram, actualFixedProgram);
            Assert.True(executionResult.IsProgramTerminates);
        }

        [Theory]
        [InlineData(ProgramDescription.InfiniteLoopExampleDescription, 8)]
        [InputFileData("2020/Day08/input.txt", 1375)]
        public void Fix_program_and_give_terminates_program_accumulator(
            string infiniteLoopProgramDescription,
            int expectedAccumulator)
        {
            // Given
            var infiniteLoopProgram = ProgramParser.Parse(infiniteLoopProgramDescription);

            // When
            var fixedProgram = ProgramFixer.Fix(infiniteLoopProgram);
            var executionResult = IsolatedProgramRunner.Execute(fixedProgram);

            // Then
            Assert.Equal(expectedAccumulator, executionResult.AccumulatorValue);
        }
    }
}