using System.Linq;
using Xunit;

namespace AdventOfCode._2020.Day10
{
    public class AdapterArray
    {
        [Theory]
        [InlineData(AdaptersDescription.Example, 22, 7, 5)]
        [InlineData(AdaptersDescription.LageExample, 52, 22, 10)]
        [InputFileData("2020/Day10/input.txt", 177, 69, 36)]
        public void Find_jolts_differences_in_chain_that_uses_all_of_the_adapters(
            string adaptersDescription,
            int expectedDeviceBuiltInJoltage,
            int expected1JoltDifferences,
            int expected3JoltDifferences)
        {
            // Given
            var adaptersJoltages = adaptersDescription.ParseAndBuildAdaptersJoltages();

            // When
            var actualDeviceBuiltInJoltage = adaptersJoltages.Last();
            var (actual1JoltDifferences, actual3JoltDifferences) = adaptersJoltages.CountJoltDifferences();

            // Then
            Assert.Equal(expectedDeviceBuiltInJoltage, actualDeviceBuiltInJoltage);
            Assert.Equal(expected1JoltDifferences, actual1JoltDifferences);
            Assert.Equal(expected3JoltDifferences, actual3JoltDifferences);
        }

        [Theory]
        [InlineData(AdaptersDescription.Example, 8L)]
        [InlineData(AdaptersDescription.LageExample, 19208L)]
        [InputFileData("2020/Day10/input.txt", 15790581481472L)]
        public void Find_total_number_of_adapters_arrangement_to_connect_the_charging_outlet_to_the_device(
            string adaptersDescription,
            long expectedNumberOfArrangement)
        {
            // When
            var actualNumberOfArrangement = adaptersDescription
                .ParseAndBuildAdaptersJoltages()
                .CountTotalNumberOfArrangements();

            // Then
            Assert.Equal(expectedNumberOfArrangement, actualNumberOfArrangement);
        }
    }
}