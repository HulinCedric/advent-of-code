using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2020.Day10
{
    public static class AdapterCounter
    {
        public static (int count1JoltDifferences, int count3JoltDifferences) CountJoltDifferences(
            this List<int> adaptersJoltages)
        {
            var count1JoltDifferences = 0;
            var count3JoltDifferences = 0;
            var chainedAdapters = adaptersJoltages.Zip(
                adaptersJoltages.Skip(1),
                (fromAdapter, toAdapter) => (fromAdapter, toAdapter));

            foreach (var (fromAdapter, toAdapter) in chainedAdapters)
                switch (toAdapter - fromAdapter)
                {
                    case 1:
                        count1JoltDifferences++;
                        break;
                    case 3:
                        count3JoltDifferences++;
                        break;
                }

            return (count1JoltDifferences, count3JoltDifferences);
        }

        public static long CountTotalNumberOfArrangements(this IEnumerable<int> adaptersJoltages)
            => adaptersJoltages.CountTotalNumberOfArrangements(new Dictionary<int, long>());

        private static long CountTotalNumberOfArrangements(
            this IEnumerable<int> adaptersJoltages,
            IDictionary<int, long> memoizedSum)
        {
            var adaptersJoltagesList = adaptersJoltages.ToList();
            if (adaptersJoltagesList.Count == 1)
                return 1;

            var firstAdapterJoltage = adaptersJoltagesList.First();
            if (memoizedSum.ContainsKey(firstAdapterJoltage))
                return memoizedSum[firstAdapterJoltage];

            var sum = adaptersJoltagesList
                .Select((adapterJoltage, index) => (adapterJoltage, index))
                .Skip(1)
                .TakeWhile(item => item.adapterJoltage - firstAdapterJoltage <= 3)
                .Sum(
                    item => CountTotalNumberOfArrangements(
                        adaptersJoltagesList.Skip(item.index),
                        memoizedSum));

            memoizedSum.Add(firstAdapterJoltage, sum);

            return sum;
        }
    }
}