using AdventOfCode.Day02.Commands;
using FluentAssertions;
using Xunit;

namespace AdventOfCode.Day02
{
    public class SubmarineWithCommandShould
    {
        [Theory]
        [InlineData(0, 0, 5, 5, 0)]
        [InlineData(5, 5, 8, 13, 5)]
        [InlineData(13, 10, 2, 15, 10)]
        public void Increases_the_horizontal_position_by_number_of_unit_from_forward_command(
            int startHorizontal,
            int startDepth,
            int commandUnit,
            int endHorizontal,
            int endDepth)
        {
            // Given
            var expectedPosition = new Position(endHorizontal, endDepth);
            var submarine = new Submarine(startHorizontal, startDepth);

            // When
            submarine.Execute(new ForwardCommand(commandUnit));

            // Then
            var actualPosition = submarine.Position;
            actualPosition.Should().Be(expectedPosition);
        }

        [Theory]
        [InlineData(5, 0, 5, 5, 5)]
        [InlineData(13, 2, 8, 13, 10)]
        public void Increases_the_depth_position_by_number_of_unit_from_down_command(
            int startHorizontal,
            int startDepth,
            int commandUnit,
            int endHorizontal,
            int endDepth)
        {
            // Given
            var expectedPosition = new Position(endHorizontal, endDepth);
            var submarine = new Submarine(startHorizontal, startDepth);

            // When
            submarine.Execute(new DownCommand(commandUnit));

            // Then
            var actualPosition = submarine.Position;
            actualPosition.Should().Be(expectedPosition);
        }

        [Theory]
        [InlineData(8, 5, 3, 8, 2)]
        public void Decreases_the_depth_position_by_number_of_unit_from_up_command(
            int startHorizontal,
            int startDepth,
            int commandUnit,
            int endHorizontal,
            int endDepth)
        {
            // Given
            var expectedPosition = new Position(endHorizontal, endDepth);
            var submarine = new Submarine(startHorizontal, startDepth);

            // When
            submarine.Execute(new UpCommand(commandUnit));

            // Then
            var actualPosition = submarine.Position;
            actualPosition.Should().Be(expectedPosition);
        }
    }
}