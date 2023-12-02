using System;

namespace AdventOfCode._2020.Day08.Instructions
{
    public static class InstructionFactory
    {
        public static Instruction Create(string instructionDescription)
        {
            var (operation, argument) = InstructionParser.Parse(instructionDescription);
            return operation switch
            {
                AccumulatorInstruction.OperationName => new AccumulatorInstruction(argument),
                JumpInstruction.OperationName => new JumpInstruction(argument),
                NoOperationInstruction.OperationName => new NoOperationInstruction(argument),
                _ => throw new ArgumentException(
                    $"Instruction {operation} is unknown",
                    nameof(instructionDescription))
            };
        }
    }
}