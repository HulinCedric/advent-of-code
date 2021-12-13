using AdventOfCode.Day02.AimCommands;
using FluentAssertions;
using Xunit;

namespace AdventOfCode.Day02
{
    public class SubmarineWithAimCommandShould
    {
        [Theory]
        [InlineData(0, 0, 0, 5, 5, 0, 0)]
        [InlineData(5, 0, 5, 8, 13, 40, 5)]
        [InlineData(13, 40, 10, 2, 15, 60, 10)]
        public void Increases_the_horizontal_position_by_number_of_unit_from_forward_command(
            int startHorizontal,
            int startDepth,
            int startAim,
            int commandUnit,
            int endHorizontal,
            int endDepth,
            int endAim)
        {
            // Given
            var expectedPosition = new Position(endHorizontal, endDepth);
            var expectedAim = new Aim(endAim);
            var submarine = new Submarine(startHorizontal, startDepth, new Aim(startAim));

            // When
            submarine.Execute(new ForwardAimCommand(commandUnit));

            // Then
            var actualPosition = submarine.Position;
            actualPosition.Should().Be(expectedPosition);

            var actualAim = submarine.Aim;
            actualAim.Should().Be(expectedAim);
        }

        [Theory]
        [InlineData(0, 0, 0, 5, 5, 0, 0)]
        [InlineData(5, 0, 5, 8, 13, 40, 5)]
        [InlineData(13, 40, 10, 2, 15, 60, 10)]
        public void Increases_the_depth_by_the_aim_multiplied_by_the_number_of_unit_from_forward_command(
            int startHorizontal,
            int startDepth,
            int startAim,
            int commandUnit,
            int endHorizontal,
            int endDepth,
            int endAim)
        {
            // Given
            var expectedPosition = new Position(endHorizontal, endDepth);
            var expectedAim = new Aim(endAim);
            var submarine = new Submarine(startHorizontal, startDepth, new Aim(startAim));

            // When
            submarine.Execute(new ForwardAimCommand(commandUnit));

            // Then
            var actualPosition = submarine.Position;
            actualPosition.Should().Be(expectedPosition);

            var actualAim = submarine.Aim;
            actualAim.Should().Be(expectedAim);
        }

        [Theory]
        [InlineData(5, 0, 0, 5, 5, 0, 5)]
        [InlineData(13, 40, 2, 8, 13, 40, 10)]
        public void Increases_the_aim_by_number_of_unit_from_down_command(
            int startHorizontal,
            int startDepth,
            int startAim,
            int commandUnit,
            int endHorizontal,
            int endDepth,
            int endAim)
        {
            // Given
            var expectedPosition = new Position(endHorizontal, endDepth);
            var expectedAim = new Aim(endAim);
            var submarine = new Submarine(startHorizontal, startDepth, new Aim(startAim));

            // When
            submarine.Execute(new DownAimCommand(commandUnit));

            // Then
            var actualPosition = submarine.Position;
            actualPosition.Should().Be(expectedPosition);

            var actualAim = submarine.Aim;
            actualAim.Should().Be(expectedAim);
        }

        [Theory]
        [InlineData(13, 40, 5, 3, 13, 40, 2)]
        public void Decreases_the_aim_by_number_of_unit_from_up_command(
            int startHorizontal,
            int startDepth,
            int startAim,
            int commandUnit,
            int endHorizontal,
            int endDepth,
            int endAim)
        {
            // Given
            var expectedPosition = new Position(endHorizontal, endDepth);
            var expectedAim = new Aim(endAim);
            var submarine = new Submarine(startHorizontal, startDepth, new Aim(startAim));

            // When
            submarine.Execute(new UpAimCommand(commandUnit));

            // Then
            var actualPosition = submarine.Position;
            actualPosition.Should().Be(expectedPosition);

            var actualAim = submarine.Aim;
            actualAim.Should().Be(expectedAim);
        }
    }
}