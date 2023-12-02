using System.Linq;
using Xunit;

namespace AdventOfCode._2020.Day20
{
    public class MonsterMessagesShould
    {
        [Theory]
        [InlineData(CameraArrayDescription.Example, 20899048083289L)]
        [InputFileData("2020/Day20/input.txt", 63187742854073L)]
        public void What_do_you_get_if_you_multiply_together_the_IDs_of_the_four_corner_tiles(
            string cameraArrayDescription,
            long expectedCameraArrayCornerProduct)
        {
            // Given
            var tiles = TilesParser.ParseAll(cameraArrayDescription);

            // When
            var ids = CameraArray.FindCornerIds(tiles);

            var actualCameraArrayCornerProduct = ids.Aggregate(1L, (acc, tileId) => acc * tileId);

            // Then
            Assert.Equal(expectedCameraArrayCornerProduct, actualCameraArrayCornerProduct);
        }
    }
}