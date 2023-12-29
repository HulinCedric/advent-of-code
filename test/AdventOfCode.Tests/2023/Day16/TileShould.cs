using AdventOfCode._2023.Day16.Tiles;
using FluentAssertions;
using Xunit;

namespace AdventOfCode._2023.Day16;

public static class TilesTests
{
    public class Mirror45DegreesShould
    {
        private readonly Tile mirror45Degrees = TileFactory.Tile('/');

        [Fact]
        public void Reflect_right_to_up()
        {
            var direction = Direction.Right;

            var result = mirror45Degrees.Reflect(direction);

            result.Should().HaveCount(1);
            result[0].Should().Be(Direction.Up);
        }

        [Fact]
        public void Reflect_left_to_down()
        {
            var direction = Direction.Left;

            var result = mirror45Degrees.Reflect(direction);

            result.Should().HaveCount(1);
            result[0].Should().Be(Direction.Down);
        }

        [Fact]
        public void Reflect_down_to_left()
        {
            var direction = Direction.Down;

            var result = mirror45Degrees.Reflect(direction);

            result.Should().HaveCount(1);
            result[0].Should().Be(Direction.Left);
        }

        [Fact]
        public void Reflect_up_to_right()
        {
            var direction = Direction.Up;

            var result = mirror45Degrees.Reflect(direction);

            result.Should().HaveCount(1);
            result[0].Should().Be(Direction.Right);
        }
    }

    public class Mirror135DegreesShould
    {
        private readonly Tile mirror135Degrees = TileFactory.Tile('\\');

        [Fact]
        public void Reflect_right_to_up()
        {
            var direction = Direction.Right;

            var result = mirror135Degrees.Reflect(direction);

            result.Should().HaveCount(1);
            result[0].Should().Be(Direction.Down);
        }

        [Fact]
        public void Reflect_left_to_down()
        {
            var direction = Direction.Left;

            var result = mirror135Degrees.Reflect(direction);

            result.Should().HaveCount(1);
            result[0].Should().Be(Direction.Up);
        }

        [Fact]
        public void Reflect_down_to_left()
        {
            var direction = Direction.Down;

            var result = mirror135Degrees.Reflect(direction);

            result.Should().HaveCount(1);
            result[0].Should().Be(Direction.Right);
        }

        [Fact]
        public void Reflect_up_to_right()
        {
            var direction = Direction.Up;

            var result = mirror135Degrees.Reflect(direction);

            result.Should().HaveCount(1);
            result[0].Should().Be(Direction.Left);
        }
    }

    public class VerticalSplitterShould
    {
        private readonly Tile verticalSplitter = TileFactory.Tile('|');

        [Fact]
        public void Reflect_right_to_up_and_down_when_beam_encounters_flat_side()
        {
            var direction = Direction.Right;

            var result = verticalSplitter.Reflect(direction);

            result.Should().HaveCount(2);
            result.Should().Contain(Direction.Up);
            result.Should().Contain(Direction.Down);
        }

        [Fact]
        public void Reflect_left_to_up_and_down_when_beam_encounters_flat_side()
        {
            var direction = Direction.Left;

            var result = verticalSplitter.Reflect(direction);

            result.Should().HaveCount(2);
            result.Should().Contain(Direction.Up);
            result.Should().Contain(Direction.Down);
        }


        [Fact]
        public void Pass_through_up_when_beam_encounters_the_pointy_end_of_the_splitter()
        {
            var direction = Direction.Up;

            var result = verticalSplitter.Reflect(direction);

            result.Should().HaveCount(1);
            result[0].Should().Be(Direction.Up);
        }

        [Fact]
        public void Pass_through_down_when_beam_encounters_the_pointy_end_of_the_splitter()
        {
            var direction = Direction.Down;

            var result = verticalSplitter.Reflect(direction);

            result.Should().HaveCount(1);
            result[0].Should().Be(Direction.Down);
        }
    }

    public class HorizontalSplitterShould
    {
        private readonly Tile horizontalSplitter = TileFactory.Tile('-');

        [Fact]
        public void Reflect_up_to_left_and_right_when_beam_encounters_flat_side()
        {
            var direction = Direction.Up;

            var result = horizontalSplitter.Reflect(direction);

            result.Should().HaveCount(2);
            result.Should().Contain(Direction.Left);
            result.Should().Contain(Direction.Right);
        }

        [Fact]
        public void Reflect_down_to_left_and_right_when_beam_encounters_flat_side()
        {
            var direction = Direction.Down;

            var result = horizontalSplitter.Reflect(direction);

            result.Should().HaveCount(2);
            result.Should().Contain(Direction.Left);
            result.Should().Contain(Direction.Right);
        }


        [Fact]
        public void Pass_through_left_when_beam_encounters_the_pointy_end_of_the_splitter()
        {
            var direction = Direction.Left;

            var result = horizontalSplitter.Reflect(direction);

            result.Should().HaveCount(1);
            result[0].Should().Be(Direction.Left);
        }

        [Fact]
        public void Pass_through_right_when_beam_encounters_the_pointy_end_of_the_splitter()
        {
            var direction = Direction.Right;

            var result = horizontalSplitter.Reflect(direction);

            result.Should().HaveCount(1);
            result[0].Should().Be(Direction.Right);
        }
    }

    public class EmptySpaceShould
    {
        private readonly Tile emptySpace = TileFactory.Tile('.');

        [Fact]
        public void Continue_left_in_the_same_direction()
        {
            var direction = Direction.Left;

            var result = emptySpace.Reflect(direction);

            result.Should().HaveCount(1);
            result[0].Should().Be(direction);
        }

        [Fact]
        public void Continue_right_in_the_same_direction()
        {
            var direction = Direction.Right;

            var result = emptySpace.Reflect(direction);

            result.Should().HaveCount(1);
            result[0].Should().Be(direction);
        }

        [Fact]
        public void Continue_up_in_the_same_direction()
        {
            var direction = Direction.Up;

            var result = emptySpace.Reflect(direction);

            result.Should().HaveCount(1);
            result[0].Should().Be(direction);
        }

        [Fact]
        public void Continue_down_in_the_same_direction()
        {
            var direction = Direction.Down;

            var result = emptySpace.Reflect(direction);

            result.Should().HaveCount(1);
            result[0].Should().Be(direction);
        }
    }
}