using System.Linq;
using Xunit;

namespace AdventOfCode._2020.Day14
{
    public class MemoryAddressDecoderShould
    {
        [Theory]
        [InlineData(
            42U,
            "000000000000000000000000000000X1001X",
            new[]
            {
                26U, 27U, 58U, 59U
            })]
        [InlineData(
            26U,
            "00000000000000000000000000000000X0XX",
            new[]
            {
                16U, 17U, 18U, 19U, 24U, 25U, 26U, 27U
            })]
        public void Decode_memory_address(
            uint memoryAddressPosition,
            string maskDescription,
            uint[] expectedMemoriesPositions)
        {
            // Given
            var memoryAddress = new MemoryAddress(memoryAddressPosition);
            var bitMask = new BitMask(maskDescription);
            var expectedMemoriesAddresses = expectedMemoriesPositions
                .Select(m => new MemoryAddress(m));

            // When
            var decodedMemoriesAddresses = MemoryAddressDecoder.Decode(bitMask, memoryAddress);

            // Then
            Assert.Equal(expectedMemoriesAddresses, decodedMemoriesAddresses);
        }
    }
}