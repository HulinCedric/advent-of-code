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

    public class Submarine
    {
        public Submarine()
            : this(0, 0, new Aim(0))
        {
        }

        public Submarine(int horizontal, int depth)
            : this(horizontal, depth, new Aim(0))
        {
        }


        public Submarine(Aim aim)
            : this(0, 0, aim)
        {
        }

        public Submarine(int horizontal, int depth, Aim aim)
        {
            Position = new Position(horizontal, depth);
            Aim = aim;
        }

        public Aim Aim { get; set; }

        public Position Position { get; private set; }

        public void Execute(SubmarineCommand command)
            => Position = command.ExecuteFor(Position);

        public void Execute(SubmarineAimCommand command)
            => (Position, Aim) = command.ExecuteFor(this);
    }

    public record Aim(int Value);

    public record Position(int Horizontal, int Depth);
}