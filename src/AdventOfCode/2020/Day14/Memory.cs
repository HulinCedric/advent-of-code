using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2020.Day14
{
    public class Memory
    {
        private readonly Dictionary<long, MemoryValue> values = new();

        private readonly WriteStrategy writeStrategy;

        public Memory(WriteStrategy writeStrategy)
        {
            this.writeStrategy = writeStrategy;
            BitMask = BitMask.Default;
        }

        public BitMask BitMask { get; private set; }

        public MemoryValue Sum
            => values.Values.Aggregate(
                new MemoryValue(0),
                (acc, current) => acc + current);

        public IReadOnlyCollection<MemoryValue> Values
            => values.Values;

        public void UpdateBitMask(BitMask bitMask)
            => BitMask = bitMask;

        public MemoryValue ValueAt(long position)
            => values[position];


        public void WriteAt(MemoryAddress address, MemoryValue value)
            => writeStrategy.WriteAt(this, address, value);

        public sealed class OverwriteStrategy : WriteStrategy
        {
            protected internal override void WriteAt(Memory memory, MemoryAddress address, MemoryValue value)
                => memory.values[address.Position] = memory.BitMask.Overwrite(value);
        }

        public sealed class DecodeStrategy : WriteStrategy
        {
            protected internal override void WriteAt(Memory memory, MemoryAddress address, MemoryValue value)
            {
                foreach (var decodedMemoryAddress in MemoryAddressDecoder.Decode(memory.BitMask, address))
                    memory.values[decodedMemoryAddress.Position] = value;
            }
        }

        public abstract class WriteStrategy
        {
            protected internal abstract void WriteAt(Memory memory, MemoryAddress address, MemoryValue value);
        }
    }
}