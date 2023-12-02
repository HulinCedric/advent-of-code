using AdventOfCode._2020.Day12.NavigationInstructions;
using AdventOfCode._2020.Day12.Ships;
using Xunit;

namespace AdventOfCode._2020.Day12
{
    public class RainRisk
    {
        [Theory]
        [InlineData(NavigationInstructionsDescription.Example, 25)]
        [InputFileData("2020/Day12/input.txt", 1133)]
        public void
            Determine_Manhattan_distance_between_ships_with_directions_starting_position_and_instructions_location(
                string navigationInstructionsDescription,
                int expectedManhattanDistance)
        {
            // Given
            var navigationInstructions = NavigationInstructionsParser.Parse(navigationInstructionsDescription);
            var ship = new ShipWithDirection(Direction.East, 0, 0);

            // When
            foreach (var navigationInstruction in navigationInstructions)
                ship.Navigate(navigationInstruction);

            var actualManhattanDistance = ship.GetManhattanDistance();

            // Then
            Assert.Equal(expectedManhattanDistance, actualManhattanDistance);
        }

        [Theory]
        [InlineData(NavigationInstructionsDescription.Example, 286)]
        [InputFileData("2020/Day12/input.txt", 61053)]
        public void
            Determine_Manhattan_distance_between_ships_with_waypoint_starting_position_and_instructions_location(
                string navigationInstructionsDescription,
                int expectedManhattanDistance)
        {
            // Given
            var navigationInstructions = NavigationInstructionsParser.Parse(navigationInstructionsDescription);
            var ship = new ShipWithWaypoint(new Waypoint(10, 1), 0, 0);

            // When
            foreach (var navigationInstruction in navigationInstructions)
                ship.Navigate(navigationInstruction);

            var actualManhattanDistance = ship.GetManhattanDistance();

            // Then
            Assert.Equal(expectedManhattanDistance, actualManhattanDistance);
        }
    }
}