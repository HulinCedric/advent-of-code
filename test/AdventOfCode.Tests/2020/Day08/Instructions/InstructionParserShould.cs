using Xunit;

namespace AdventOfCode._2020.Day08.Instructions
{
    public class InstructionParserShould
    {
        [Theory]
        [InlineData("nop +0", "nop", 0)]
        [InlineData("acc +1", "acc", 1)]
        [InlineData("jmp +4", "jmp", 4)]
        [InlineData("acc -99", "acc", -99)]
        public void Parse_operation_and_argument_split_by_a_space(
            string instructionDescription,
            string expectedOperationDescription,
            int expectedArgumentDescription)
        {
            var (operation, argument) = InstructionParser.Parse(instructionDescription);

            Assert.Equal(operation, expectedOperationDescription);
            Assert.Equal(argument, expectedArgumentDescription);
        }
    }
}