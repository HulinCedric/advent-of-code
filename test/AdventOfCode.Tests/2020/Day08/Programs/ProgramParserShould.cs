using Xunit;

namespace AdventOfCode._2020.Day08.Programs
{
    public class ProgramParserShould
    {
        [Theory]
        [InlineData("nop +0\nacc +1\njmp +4\n", new[] { "nop +0", "acc +1", "jmp +4" })]
        public void Parse_instructions_split_by_a_new_line(
            string programDescription,
            string[] instructionsDescriptions)
        {
            var program = ProgramParser.Parse(programDescription);

            Assert.Collection(program,
                instruction => Assert.Equal(instruction.ToString(), instructionsDescriptions[0]),
                instruction => Assert.Equal(instruction.ToString(), instructionsDescriptions[1]),
                instruction => Assert.Equal(instruction.ToString(), instructionsDescriptions[2]));
        }
    }
}