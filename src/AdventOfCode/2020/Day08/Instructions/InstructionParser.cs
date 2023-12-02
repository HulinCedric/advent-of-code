namespace AdventOfCode._2020.Day08.Instructions
{
    public static class InstructionParser
    {
        public static InstructionRepresentation Parse(string instructionDescription)
            => new(
                instructionDescription.Split(" ")[0],
                int.Parse(instructionDescription.Split(" ")[1]));
    }
}