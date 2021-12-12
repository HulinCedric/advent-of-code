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
    }

    public class Submarine
    {
        public Submarine()
            => Position = new Position(0, 0);

        public Position Position { get; }
    }

    public record Position(int Horizontal, int Depth);
}