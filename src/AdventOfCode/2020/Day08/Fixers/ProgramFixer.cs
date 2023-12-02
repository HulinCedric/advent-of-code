using System.Linq;
using AdventOfCode._2020.Day08.Instructions;
using AdventOfCode._2020.Day08.Programs;
using AdventOfCode._2020.Day08.Runners;

namespace AdventOfCode._2020.Day08.Fixers
{
    public static class ProgramFixer
    {
        /// <summary>
        /// Fix a program by switching only one instruction.
        /// </summary>
        /// <param name="program"></param>
        /// <returns></returns>
        /// <remarks>Functional way.</remarks>
        public static Program Fix(Program program)
            => program
                .Select((instruction, index) => (instruction, index))
                .Where(switchable =>
                    switchable.instruction is JumpInstruction or NoOperationInstruction)
                .Select(switchable
                    => FixInstruction(
                        program,
                        switchable.instruction,
                        switchable.index))
                .Select(possiblyFixedProgram
                    => (
                        program: possiblyFixedProgram,
                        executionResult: IsolatedProgramRunner.Execute(possiblyFixedProgram)))
                .Where(possiblyFixedProgram
                    => possiblyFixedProgram.executionResult.IsProgramTerminates)
                .Select(fixedProgram => fixedProgram.program)
                .DefaultIfEmpty(program)
                .FirstOrDefault()!;


        /// <summary>
        /// Fix a program by switching only one instruction.
        /// </summary>
        /// <param name="program"></param>
        /// <returns></returns>
        /// <remarks>Imperative way.</remarks>
        public static Program ImperativeFix(Program program)
        {
            foreach (var (switchableInstruction, switchableIndex) in program
                .Select((instruction, index) => (instruction, index))
                .Where(instructionAndIndex =>
                    instructionAndIndex.instruction is JumpInstruction or NoOperationInstruction)
                .ToList())
            {
                var fixedProgram = FixInstruction(program, switchableInstruction, switchableIndex);
                var executionResult = IsolatedProgramRunner.Execute(fixedProgram);
                if (executionResult.IsProgramTerminates)
                    return fixedProgram;
            }

            return program;
        }

        private static Program FixInstruction(
            Program program,
            Instruction instruction,
            int index)
            => instruction switch
            {
                JumpInstruction => program.SwitchInstructionAt<NoOperationInstruction>(index),
                NoOperationInstruction => program.SwitchInstructionAt<JumpInstruction>(index),
                _ => program
            };
    }
}