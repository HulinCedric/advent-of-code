using System.Linq;
using Xunit;

namespace AdventOfCode._2020.Day02
{
    public class PasswordPhilosophyShould
    {
        private const string PasswordsAndPoliciesDescriptionsExample = "1-3 a: abcde\n1-3 b: cdefg\n2-9 c: ccccccccc";

        [Theory]
        [InlineData(PasswordsAndPoliciesDescriptionsExample, 2)]
        [InputFileData("2020/Day02/input.txt", 474)]
        public void Count_x_valid_Passwords_with_OccurencePolicy(
            string passwordsAndPoliciesDescriptions,
            int expectedValidPasswordsCount)
        {
            //Given
            var passwordsWithOccurrencePolicy = PasswsordAndPolicyParser
                .ParsePasswordsAndPoliciesDescriptions(passwordsAndPoliciesDescriptions)
                .Select(PasswordFactory.CreatePasswordWithOccurrencePolicy);

            //When
            var validPasswordsCount = passwordsWithOccurrencePolicy
                .Count(password => password.IsValid());

            //Then
            Assert.Equal(expectedValidPasswordsCount, validPasswordsCount);
        }

        [Theory]
        [InlineData(PasswordsAndPoliciesDescriptionsExample, 1)]
        [InputFileData("2020/Day02/input.txt", 745)]
        public void Count_x_valid_Passwords_with_PositionPolicy(
            string passwordsAndPoliciesDescriptions,
            int expectedValidPasswordsCount)
        {
            //Given
            var passwordsWithPositionPolicy = PasswsordAndPolicyParser
                .ParsePasswordsAndPoliciesDescriptions(passwordsAndPoliciesDescriptions)
                .Select(PasswordFactory.CreatePasswordWithPositionPolicy);

            //When
            var validPasswordsCount = passwordsWithPositionPolicy
                .Count(password => password.IsValid());

            //Then
            Assert.Equal(expectedValidPasswordsCount, validPasswordsCount);
        }
    }
}