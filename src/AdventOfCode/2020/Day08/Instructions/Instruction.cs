using System;
using AdventOfCode._2020.Day08.Programs;

namespace AdventOfCode._2020.Day08.Instructions
{
    public abstract class Instruction
        : IEquatable<Instruction>
    {
        protected Instruction(int argument)
            => Argument = argument;

        protected int Argument { get; }

        protected abstract string Operation { get; }

        public bool Equals(Instruction? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Argument == other.Argument &&
                   Operation == other.Operation;
        }

        public abstract InstructionExecutionResult Execute(ProgramContext context);

        public override string ToString() => $"{Operation} {(Argument >= 0 ? '+' : string.Empty)}{Argument}";

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Instruction)obj);
        }

        public override int GetHashCode()
            => HashCode.Combine(Argument, Operation);

        public T SwitchTo<T>() where T : Instruction
            => (Activator.CreateInstance(typeof(T), Argument) as T)!;
    }
}