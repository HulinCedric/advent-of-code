using Xunit;

namespace AdventOfCode._2020.Day06
{

    public class GroupsAnswersCounterShould
    {
        [Theory]
        [InlineData("a", 1)]
        [InlineData("a\na", 1)]
        [InlineData("a\n\na", 2)]
        [InlineData("a\n\na\na", 2)]
        [InlineData("a\n\na\nb", 3)]
        [InlineData("abc\n\na\nb\nc\n\nab\nac\n\na\na\na\na\n\nb", 11)]
        [InputFileData("2020/Day06/input.txt", 7283)]
        public void Sum_questions_to_which_anyone_answered_yes(
            string groupAnswersDescription,
            int expectedYesAnswersSum)
        {
            //When
            var yesAnswersSum = GroupsAnswersCounter.SumDistinctYesAnswers(groupAnswersDescription);

            //Then
            Assert.Equal(expectedYesAnswersSum, yesAnswersSum);
        }

        [Theory]
        [InlineData("a", 1)]
        [InlineData("ab", 2)]
        [InlineData("a\na", 1)]
        [InlineData("ab\na", 1)]
        [InlineData("a\n\na", 2)]
        [InlineData("a\n\na\na", 2)]
        [InlineData("a\n\na\nb", 1)]
        [InlineData("abc\n\na\nb\nc\n\nab\nac\n\na\na\na\na\n\nb", 6)]
        [InputFileData("2020/Day06/input.txt", 3520)]
        public void Sum_questions_to_which_everyone_answered_yes(
            string groupAnswersDescription,
            int expectedAnswersCount)
        {
            //When
            var answersCount = GroupsAnswersCounter.SumQuestionsToWhichEveryoneAnsweredYes(groupAnswersDescription);

            //Then
            Assert.Equal(expectedAnswersCount, answersCount);
        }
    }
}