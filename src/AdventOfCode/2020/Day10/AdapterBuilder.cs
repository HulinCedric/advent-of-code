using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2020.Day10
{
    public static class AdapterBuilder
    {
        public static List<int> ParseAndBuildAdaptersJoltages(this string adaptersDescription)
        {
            var adaptersJoltages = adaptersDescription
                .Split("\n")
                .Select(int.Parse)
                .ToList();

            const int chargingOutletJoltage = 0;
            adaptersJoltages.Add(chargingOutletJoltage);

            var deviceBuiltInJoltage = adaptersJoltages.Max() + 3;
            adaptersJoltages.Add(deviceBuiltInJoltage);

            adaptersJoltages.Sort();

            return adaptersJoltages;
        }
    }
}