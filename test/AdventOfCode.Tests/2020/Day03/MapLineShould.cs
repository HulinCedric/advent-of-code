using Xunit;

namespace AdventOfCode._2020.Day03
{
    public class MapLineShould
    {
        private const string LineDescription = "#.";

        private readonly MapLine mapLine;

        public MapLineShould()
            => mapLine = new MapLine(LineDescription);

        [Theory]
        [InlineData(1, true)]
        [InlineData(2, false)]
        public void Give_presence_of_three_at(int position, bool expectedTreePresence)
        {
            //When
            var treePresence = mapLine.GetTreePresenceAtPosition(position);

            //Then
            Assert.Equal(expectedTreePresence, treePresence);
        }

        [Theory]
        [InlineData(3, true)]
        [InlineData(4, false)]
        public void Have_the_same_pattern_repeats_to_the_right_many_times(int position, bool expectedTreePresence)
        {
            //When
            var treePresence = mapLine.GetTreePresenceAtPosition(position);

            //Then
            Assert.Equal(expectedTreePresence, treePresence);
        }
    }
}