using Xunit;

namespace AdventOfCode._2020.Day20
{
    public class TileShould
    {
        [Theory]
        [InlineData(TilesDescription.TopLeft, TilesDescription.TopMiddle)]
        [InlineData(TilesDescription.MiddleLeft, TilesDescription.MiddleMiddle)]
        [InlineData(TilesDescription.BottomLeft, TilesDescription.BottomMiddle)]
        public void Are_adjacent_on_right_left_borders(
            string firstTileDescription,
            string secondTileDescription)
        {
            // Given
            Tile first = TilesParser.ParseOne(firstTileDescription);
            Tile second = TilesParser.ParseOne(secondTileDescription);

            // When
            var (areAdjacent, fromBorder, toBorder) = Tile.AreAdjacent(first, second);

            // Then
            CheckRightLeftAdjacentBorders(areAdjacent, fromBorder, toBorder);
        }


        [Theory]
        [InlineData(TilesDescription.TopMiddle, TilesDescription.TopRight)]
        public void Are_adjacent_on_right_left_borders_after_vertical_flip(
            string firstTileDescription,
            string secondTileDescription)
        {
            // Given
            Tile first = TilesParser.ParseOne(firstTileDescription);
            Tile second = TilesParser.ParseOne(secondTileDescription);

            // When
            first = first.VerticalFlip();
            var (areAdjacent, fromBorder, toBorder) = Tile.AreAdjacent(first, second);

            // Then
            CheckRightLeftAdjacentBorders(areAdjacent, fromBorder, toBorder);
        }

        [Theory]
        [InlineData(TilesDescription.BottomMiddle, TilesDescription.BottomRight)]
        public void Are_adjacent_on_right_left_borders_after_horizontal_flip(
            string firstTileDescription,
            string secondTileDescription)
        {
            // Given
            Tile first = TilesParser.ParseOne(firstTileDescription);
            Tile second = TilesParser.ParseOne(secondTileDescription);

            // When
            first = first.VerticalFlip();
            second = second.HorizontalFlip();
            var (areAdjacent, fromBorder, toBorder) = Tile.AreAdjacent(first, second);

            // Then
            CheckRightLeftAdjacentBorders(areAdjacent, fromBorder, toBorder);
        }

        [Theory]
        [InlineData(TilesDescription.MiddleMiddle, TilesDescription.MiddleRight)]
        public void Are_adjacent_on_right_left_borders_after_flip_and_rotate(
            string firstTileDescription,
            string secondTileDescription)
        {
            // Given
            Tile first = TilesParser.ParseOne(firstTileDescription);
            Tile second = TilesParser.ParseOne(secondTileDescription);

            // When
            first = first.VerticalFlip();
            second = second.HorizontalFlip();
            second = second.ClockwiseRotate();
            var (areAdjacent, fromBorder, toBorder) = Tile.AreAdjacent(first, second);

            // Then
            CheckRightLeftAdjacentBorders(areAdjacent, fromBorder, toBorder);
        }

        [Theory]
        [InlineData(TilesDescription.MiddleMiddle, TilesDescription.TopMiddle)]
        [InlineData(TilesDescription.MiddleMiddle, TilesDescription.MiddleRight)]
        [InlineData(TilesDescription.MiddleMiddle, TilesDescription.BottomMiddle)]
        [InlineData(TilesDescription.MiddleMiddle, TilesDescription.MiddleLeft)]
        public void Find_orientation_for_adjacent_with_all_orientations(
            string firstTileDescription,
            string secondTileDescription)
        {
            // Given
            Tile first = TilesParser.ParseOne(firstTileDescription);
            Tile second = TilesParser.ParseOne(secondTileDescription);

            // When
            (first, second) = Tile.FindAdjacentOrientation(first, second);
            var (areAdjacent, fromBorder, toBorder) = Tile.AreAdjacent(first, second);

            // Then
            Assert.True(areAdjacent);
        }

        private static void CheckRightLeftAdjacentBorders(
            bool areAdjacent,
            TileBorder? fromBorder,
            TileBorder? toBorder)
        {
            Assert.True(areAdjacent);
            Assert.Equal(TileBorder.Right, fromBorder);
            Assert.Equal(TileBorder.Left, toBorder);
        }
    }
}