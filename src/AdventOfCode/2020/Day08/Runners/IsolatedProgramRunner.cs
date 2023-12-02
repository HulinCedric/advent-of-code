using System.Collections.Generic;
using System.Linq;
using AdventOfCode._2020.Day08.Programs;

namespace AdventOfCode._2020.Day08.Runners
{
    public static class IsolatedProgramRunner
    {
        public static ProgramExecutionResult Execute(Program program)
        {
            var accumulator = 0;
            var executedInstructionsIndexes = new List<int>();
            var currentInstructionIndex = 0;
            var isInfiniteLoopProgram = false;
            var isProgramTerminates = false;
            var terminatesInstructionIndex = program.Count();

            do
            {
                var instruction = program.ElementAt(currentInstructionIndex);

                var (nextInstructionIndex, accumulatorValue) = instruction.Execute(new ProgramContext(accumulator, currentInstructionIndex));

                executedInstructionsIndexes.Add(currentInstructionIndex);

                accumulator = accumulatorValue;
                currentInstructionIndex = nextInstructionIndex;

                if (currentInstructionIndex >= terminatesInstructionIndex)
                    isProgramTerminates = true;

                if (executedInstructionsIndexes.Contains(currentInstructionIndex))
                    isInfiniteLoopProgram = true;
            } while (!isProgramTerminates && !isInfiniteLoopProgram);

            return new ProgramExecutionResult(accumulator, isProgramTerminates, isInfiniteLoopProgram);
        }
    }
}