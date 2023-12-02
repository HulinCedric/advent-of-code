using Xunit;

namespace AdventOfCode._2020.Day17
{
    public class ConwayCubesShould
    {
        [Theory]
        [InlineData(ConwayCubesDescription.Example, 112)]
        [InputFileData("2020/Day17/input.txt", 267)]
        public void How_many_cubes_are_left_in_the_active_state_after_the_sixth_cycle_3_dimensions(
            string conwayCubesDescription,
            ushort expectedActiveCubeCount)
        {
            // Given
            var coordinates = ConwayCubesParser.ParseTo3Dimension(conwayCubesDescription);

            // When
            var actualActiveCubeCount = new ConwayCubes().Play6Cycles(coordinates);

            // Then
            Assert.Equal(expectedActiveCubeCount, actualActiveCubeCount);
        }

        [Theory]
        [InlineData(ConwayCubesDescription.Example, 848)]
        [InputFileData("2020/Day17/input.txt", 1812)]
        public void How_many_cubes_are_left_in_the_active_state_after_the_sixth_cycle_4_dimensions(
            string conwayCubesDescription,
            ushort expectedActiveCubeCount)
        {
            // Given
            var coordinates = ConwayCubesParser.ParseTo4Dimension(conwayCubesDescription);

            // When
            var actualActiveCubeCount = new ConwayCubes().Play6Cycles(coordinates);

            // Then
            Assert.Equal(expectedActiveCubeCount, actualActiveCubeCount);
        }
    }
}