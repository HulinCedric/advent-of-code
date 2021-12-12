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
    }


    public class Submarine
    {
        public Submarine(int horizontal, int depth)
            => Position = new Position(horizontal, depth);

        public Submarine() : this(0, 0)
        {
        }

        public Position Position { get; }
    }

    public record Position(int Horizontal, int Depth);
}