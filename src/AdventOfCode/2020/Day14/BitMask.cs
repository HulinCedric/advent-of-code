using System.Linq;

namespace AdventOfCode._2020.Day14
{
    public record BitMask
    {
        private readonly string bitMaskDescription;

        public BitMask(string bitMaskDescription)
            => this.bitMaskDescription = bitMaskDescription;

        public static BitMask Default
            => new("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");

        public MemoryValue Overwrite(MemoryValue memoryValue)
            => new(string.Concat(
                memoryValue.ToString()
                    .Zip(
                        bitMaskDescription,
                        (memoryValueBit, maskBit) => maskBit == 'X' ? memoryValueBit : maskBit)));

        public string Overwrite(MemoryAddress memoryValue)
            => string.Concat(
                memoryValue.ToString()
                    .Zip(
                        bitMaskDescription,
                        (memoryAddressBit, maskBit) =>
                            maskBit switch
                            {
                                '0' => memoryAddressBit,
                                '1' => '1',
                                _ => maskBit
                            }));
    }
}