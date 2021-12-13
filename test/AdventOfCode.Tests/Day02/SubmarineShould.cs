using FluentAssertions;
using Xunit;

namespace AdventOfCode.Day02
{
    public class SubmarineShould
    {
        [Fact]
        public void Start_at_position_0_by_default()
        {
            // Given
            var expectedPosition = new Position(0, 0);
            var submarine = new Submarine();

            // When
            var actualPosition = submarine.Position;

            // Then
            actualPosition.Should().Be(expectedPosition);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(5, 10)]
        public void Start_at_position_indicated(
            int horizontal,
            int depth)

        {
            // Given
            var expectedPosition = new Position(horizontal, depth);
            var submarine = new Submarine(horizontal, depth);

            // When
            var actualPosition = submarine.Position;

            // Then
            actualPosition.Should().Be(expectedPosition);
        }

        [Fact]
        public void Start_with_aim_at_0_by_default()
        {
            // Given
            var expectedAim = new Aim(0);
            var submarine = new Submarine();

            // When
            var actualAim = submarine.Aim;

            // Then
            actualAim.Should().Be(expectedAim);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(5)]
        public void Start_with_aim_indicated(int aimValue)
        {
            // Given
            var expectedAim = new Aim(aimValue);
            var submarine = new Submarine(expectedAim);

            // When
            var actualAim = submarine.Aim;

            // Then
            actualAim.Should().Be(expectedAim);
        }
    }
}