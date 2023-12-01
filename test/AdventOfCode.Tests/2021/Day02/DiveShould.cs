using System.Linq;
using AdventOfCode._2021.Day02.AimCommands;
using AdventOfCode._2021.Day02.Commands;
using FluentAssertions;
using Xunit;

namespace AdventOfCode._2021.Day02
{
    public class DiveShould
    {
        [Theory]
        [InlineData("forward 5\ndown 5\nforward 8\nup 3\ndown 8\nforward 2", 150)]
        [InputFileData("2021/Day02/input.txt", 1882980)]
        public void What_do_you_get_if_you_multiply_your_final_horizontal_position_by_your_final_depth(
            string plannedCourseRepresentation,
            int expectedPositionScore)
        {
            // Given
            var submarine = new Submarine();
            var commands = plannedCourseRepresentation
                .Split("\n")
                .Select(SubmarineCommandFactory.CreateForRepresentation)
                .ToList();

            // When
            foreach (var command in commands)
                submarine.Execute(command);

            // Then
            var actualPositionScore = submarine.Position.Horizontal * submarine.Position.Depth;

            actualPositionScore.Should().Be(expectedPositionScore);
        }

        [Theory]
        [InlineData("forward 5\ndown 5\nforward 8\nup 3\ndown 8\nforward 2", 900)]
        [InputFileData("2021/Day02/input.txt", 1971232560)]
        public void What_do_you_get_if_you_multiply_your_final_horizontal_position_by_your_final_depth_with_aime(
            string plannedCourseRepresentation,
            int expectedPositionScore)
        {
            // Given
            var submarine = new Submarine();
            var commands = plannedCourseRepresentation
                .Split("\n")
                .Select(SubmarineAimCommandFactory.CreateForRepresentation)
                .ToList();

            // When
            foreach (var command in commands)
                submarine.Execute(command);

            // Then
            var actualPositionScore = submarine.Position.Horizontal * submarine.Position.Depth;

            actualPositionScore.Should().Be(expectedPositionScore);
        }
    }
}