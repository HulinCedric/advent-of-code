using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode._2020.Day08.Instructions;

namespace AdventOfCode._2020.Day08.Programs
{
    public class Program : IEnumerable<Instruction>
    {
        private readonly IList<Instruction> instructions;

        public Program(IEnumerable<string> instructionsDescriptions)
            => instructions = instructionsDescriptions.Select(InstructionFactory.Create).ToList();

        public IEnumerator<Instruction> GetEnumerator()
            => instructions.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        public Program SwitchInstructionAt<T>(int index) where T : Instruction
        {
            var programCopy = GetCopy();
            programCopy.instructions[index] = programCopy.instructions[index].SwitchTo<T>();
            return programCopy;
        }

        private Program GetCopy()
            => new(
                instructions
                    .Select(instruction => instruction.ToString())
                    .ToList());
    }
}