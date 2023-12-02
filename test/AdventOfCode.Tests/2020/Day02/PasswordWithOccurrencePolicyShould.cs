using Xunit;

namespace AdventOfCode._2020.Day02
{
    public class PasswordWithOccurrencePolicyShould
    {
        [Fact]
        public void Be_Invalid_when_AtLeast_1_and_AtMost_3_character_b_for_Password_cdefg()
        {
            //Given
            var passwordPolicy = new PasswordOccurrencePolicy(1, 3, 'b');
            var password = new Password("cdefg", passwordPolicy);
            const bool expectedPasswordValidity = false;

            //When
            var passwordValidity = password.IsValid();

            //Then
            Assert.Equal(expectedPasswordValidity, passwordValidity);
        }

        [Fact]
        public void Be_Valid_when_AtLeast_1_and_AtMost_3_character_a_for_Password_abcde()
        {
            //Given
            var passwordPolicy = new PasswordOccurrencePolicy(1, 3, 'a');
            var password = new Password("abcde", passwordPolicy);
            const bool expectedPasswordValidity = true;

            //When
            var passwordValidity = password.IsValid();

            //Then
            Assert.Equal(expectedPasswordValidity, passwordValidity);
        }

        [Fact]
        public void Be_Valid_when_AtLeast_2_and_AtMost_9_character_c_for_Password_ccccccccc()
        {
            //Given
            var passwordPolicy = new PasswordOccurrencePolicy(2, 9, 'c');
            var password = new Password("ccccccccc", passwordPolicy);
            const bool expectedPasswordValidity = true;

            //When
            var passwordValidity = password.IsValid();

            //Then
            Assert.Equal(expectedPasswordValidity, passwordValidity);
        }
    }
}