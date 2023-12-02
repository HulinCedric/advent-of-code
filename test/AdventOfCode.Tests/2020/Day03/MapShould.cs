using Xunit;

namespace AdventOfCode._2020.Day03
{
    public class MapShould
    {
        [Theory]
        [InlineData(MapDescription.ExampleDescription, 2, 4, false)]
        [InlineData(MapDescription.ExampleDescription, 3, 7, true)]
        [InlineData(MapDescription.ExampleDescription, 4, 10, false)]
        [InlineData(MapDescription.ExampleDescription, 5, 13, true)]
        [InlineData(MapDescription.ExampleDescription, 6, 16, true)]
        [InlineData(MapDescription.ExampleDescription, 7, 19, false)]
        [InlineData(MapDescription.ExampleDescription, 8, 22, true)]
        [InlineData(MapDescription.ExampleDescription, 9, 25, true)]
        [InlineData(MapDescription.ExampleDescription, 10, 28, true)]
        [InlineData(MapDescription.ExampleDescription, 11, 31, true)]
        public void Give_tree_presence_at(
            string mapDescription,
            int lineNumber,
            int position,
            bool expectedTreePresence)
        {
            //Given
            var map = new Map(mapDescription);

            //When
            var treePresence = map.GetTreePresenceAt(lineNumber, position);

            //Then
            Assert.Equal(expectedTreePresence, treePresence);
        }
    }
}