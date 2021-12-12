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


    public abstract record SubmarineCommand(int Unit)
    {
        public abstract Position ExecuteFor(Position position);
    }

    public record UpCommand(int Unit) : SubmarineCommand(Unit)
    {
        public override Position ExecuteFor(Position position)
            => position with { Depth = position.Depth - Unit };
    }

    public record DownCommand(int Unit) : SubmarineCommand(Unit)
    {
        public override Position ExecuteFor(Position position)
            => position with { Depth = position.Depth + Unit };
    }

    public record ForwardCommand(int Unit) : SubmarineCommand(Unit)
    {
        public override Position ExecuteFor(Position position)
            => position with { Horizontal = position.Horizontal + Unit };
    }

    public class Submarine
    {
        public Submarine(int horizontal, int depth)
            => Position = new Position(horizontal, depth);

        public Submarine() : this(0, 0)
        {
        }

        public Position Position { get; private set; }

        public void Execute(SubmarineCommand command)
            => Position = command.ExecuteFor(Position);
    }

    public record Position(int Horizontal, int Depth);
}