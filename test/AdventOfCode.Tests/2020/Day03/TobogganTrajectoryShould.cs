using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AdventOfCode._2020.Day03
{
    public class TobogganTrajectoryShould
    {
        [Theory]
        [InlineData(MapDescription.ExampleDescription, 7)]
        [InputFileData("2020/Day03/input.txt", 189)]
        public void Encounter_trees(
            string mapDescription,
            int expectedNumberOfTreesEncountered)
        {
            //Given
            var toboggan = new Toboggan(new Map(mapDescription));

            //When
            var numberOfTreesEncountered = toboggan.GetNumberOfTreesEncounteredOnTrajectory();

            //Then
            Assert.Equal(expectedNumberOfTreesEncountered, numberOfTreesEncountered);
        }

        [Theory]
        [InlineData(MapDescription.ExampleDescription, 1, 1, 2)]
        [InlineData(MapDescription.ExampleDescription, 3, 1, 7)]
        [InlineData(MapDescription.ExampleDescription, 5, 1, 3)]
        [InlineData(MapDescription.ExampleDescription, 7, 1, 4)]
        [InlineData(MapDescription.ExampleDescription, 1, 2, 2)]
        [InputFileData("2020/Day03/input.txt", 1, 1, 74)]
        [InputFileData("2020/Day03/input.txt", 3, 1, 189)]
        [InputFileData("2020/Day03/input.txt", 5, 1, 65)]
        [InputFileData("2020/Day03/input.txt", 7, 1, 63)]
        [InputFileData("2020/Day03/input.txt", 1, 2, 30)]
        public void Encounter_trees_with_slope(
            string mapDescription,
            int right,
            int down,
            int expectedNumberOfTreesEncountered)
        {
            //Given
            var toboggan = new Toboggan(
                new Map(mapDescription),
                new Slope(right, down));

            //When
            var numberOfTreesEncountered = toboggan.GetNumberOfTreesEncounteredOnTrajectory();

            //Then
            Assert.Equal(expectedNumberOfTreesEncountered, numberOfTreesEncountered);
        }

        [Theory]
        [InlineData(MapDescription.ExampleDescription, 336L)]
        [InputFileData("2020/Day03/input.txt", 1718180100)]
        public void Encounter_x_multiplied_trees_with_range_of_toboggans(
            string mapDescription,
            long expectedMultipliedNumberOfTreesEncountered)
        {
            //Given
            var map = new Map(mapDescription);
            var toboggans = new List<Toboggan>
            {
                new(map, new Slope(1, 1)),
                new(map, new Slope(3, 1)),
                new(map, new Slope(5, 1)),
                new(map, new Slope(7, 1)),
                new(map, new Slope(1, 2))
            };

            //When
            var multipliedNumberOfTreesEncountered = toboggans
                .Select(toboggan => toboggan.GetNumberOfTreesEncounteredOnTrajectory())
                .Aggregate(1L, (a, b) => a * b);

            //Then
            Assert.Equal(expectedMultipliedNumberOfTreesEncountered, multipliedNumberOfTreesEncountered);
        }
    }
}