using System;
using System.Linq;

namespace AdventOfCode._2020.Day05
{
    public static class SeatIdDecoder
    {
        public static int Decode(string boardingPassDescription)
            => Convert.ToInt32(MapToBinary(boardingPassDescription), 2);

        private static string MapToBinary(string boardingPassDescription)
            => new(
                boardingPassDescription
                .Select(MapToBit)
                .ToArray());

        private static char MapToBit(char boardingPassCharacterDescription)
            => boardingPassCharacterDescription switch
            {
                'F' => '0',
                'L' => '0',
                _ => '1'
            };
    }
}