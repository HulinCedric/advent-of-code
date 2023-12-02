using System;

namespace AdventOfCode._2020.Day14
{
    public abstract class InitializationProgramInterpreter
    {
        public static Memory ExecuteInstruction(Memory memory, string programInstruction)
        {
            if (programInstruction.StartsWith("mask"))
                memory.UpdateBitMask(ExtractBitMask(programInstruction));
            else if (programInstruction.StartsWith("mem"))
                memory.WriteAt(
                    ExtractMemoryAddress(programInstruction),
                    ExtractMemoryValue(programInstruction));

            return memory;
        }

        private static BitMask ExtractBitMask(string programInstruction)
            => new(programInstruction[7..]);

        private static MemoryAddress ExtractMemoryAddress(string programInstruction)
            => new(ExtractPosition(programInstruction));

        private static MemoryValue ExtractMemoryValue(string programInstruction)
            => new(ExtractValue(programInstruction));

        private static long ExtractPosition(string programInstruction)
        {
            const int startIndex = 4;
            var endIndex = programInstruction.IndexOf(']');
            var rawPosition = programInstruction[startIndex..endIndex];
            return uint.Parse(rawPosition.Trim());
        }

        private static long ExtractValue(string programInstruction)
        {
            var startIndex = programInstruction.IndexOf("= ", StringComparison.Ordinal) + 2;
            var rawValue = programInstruction[startIndex..];
            return uint.Parse(rawValue.Trim());
        }
    }
}