using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2020.Day12.NavigationInstructions
{
    public static class NavigationInstructionsParser
    {
        public static IEnumerable<NavigationInstruction> Parse(string navigationInstructionsDescription)
        {
            return navigationInstructionsDescription
                .Split("\n")
                .Select(
                    navigationInstructionDescription =>
                        NavigationInstruction.CreateInstance(
                            ExtractAction(navigationInstructionDescription),
                            ExtractValue(navigationInstructionDescription)));
        }

        private static int ExtractValue(string navigationInstructionDescription)
            => int.Parse(navigationInstructionDescription[1..]);

        private static char ExtractAction(string navigationInstructionDescription)
            => navigationInstructionDescription[0];
    }
}