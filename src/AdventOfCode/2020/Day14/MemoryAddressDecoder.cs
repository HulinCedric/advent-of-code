using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2020.Day14
{
    public static class MemoryAddressDecoder
    {
        public static IEnumerable<MemoryAddress> Decode(BitMask mask, MemoryAddress memoryAddress)
        {
            var floatingAddress = mask.Overwrite(memoryAddress);

            var decodingAddress = new List<string>
            {
                string.Empty
            };

            foreach (var bit in floatingAddress)
            {
                var assignBit = bit == 'X' ? '0' : bit;

                for (var i = 0; i < decodingAddress.Count; i++)
                    decodingAddress[i] += assignBit;

                if (bit != 'X')
                    continue;

                foreach (var decodingResult in decodingAddress.ToList())
                    decodingAddress.Add(decodingResult[..^1] + '1');
            }

            decodingAddress.Sort();

            foreach (var decodingResult in decodingAddress)
                yield return new MemoryAddress(decodingResult);
        }
    }
}