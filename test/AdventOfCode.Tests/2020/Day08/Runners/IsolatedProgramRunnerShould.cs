using AdventOfCode._2020.Day08.Programs;
using Xunit;

namespace AdventOfCode._2020.Day08.Runners
{
    public class IsolatedProgramRunnerShould
    {
        [Theory]
        [InlineData(ProgramDescription.InfiniteLoopExampleDescription, 5)]
        [InputFileData("2020/Day08/input.txt", 1548)]
        public void Give_accumulator_before_the_program_run_an_instruction_a_second_time(
            string programDescription,
            int expectedAccumulatorValue)
        {
            // Given
            var program = ProgramParser.Parse(programDescription);

            // When
            var (actualAccumulatorValue, _, isInfiniteLoop) = IsolatedProgramRunner.Execute(program);

            // Then
            Assert.Equal(expectedAccumulatorValue, actualAccumulatorValue);
            Assert.True(isInfiniteLoop);
        }

        [Theory]
        [InlineData(ProgramDescription.TerminableExampleDescription, 8)]
        public void Give_accumulator_after_the_program_terminates(
            string programDescription,
            int expectedAccumulatorValue)
        {
            // Given
            var program = ProgramParser.Parse(programDescription);

            // When
            var (actualAccumulatorValue, isProgramTerminates, _) = IsolatedProgramRunner.Execute(program);

            // Then
            Assert.Equal(expectedAccumulatorValue, actualAccumulatorValue);
            Assert.True(isProgramTerminates);
        }
    }
}