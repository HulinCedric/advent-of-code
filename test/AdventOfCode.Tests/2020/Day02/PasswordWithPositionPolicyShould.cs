using Xunit;

namespace AdventOfCode._2020.Day02
{
    public class PasswordWithPositionPolicyShould
    {
        [Fact]
        public void Be_Invalid_when_both_position_2_and_9_contain_c_for_Password_ccccccccc()
        {
            //Given
            var passwordPolicy = new PasswordPositionPolicy(2, 9, 'c');
            var password = new Password("ccccccccc", passwordPolicy);
            const bool expectedPasswordValidity = false;

            //When
            var passwordValidity = password.IsValid();

            //Then
            Assert.Equal(expectedPasswordValidity, passwordValidity);
        }

        [Fact]
        public void Be_Invalid_when_neither_position_1_nor_position_3_contains_b_for_Password_cdefg()
        {
            //Given
            var passwordPolicy = new PasswordPositionPolicy(1, 3, 'b');
            var password = new Password("cdefg", passwordPolicy);
            const bool expectedPasswordValidity = false;

            //When
            var passwordValidity = password.IsValid();

            //Then
            Assert.Equal(expectedPasswordValidity, passwordValidity);
        }

        [Fact]
        public void Be_valid_when_position_1_contains_a_and_position_3_does_not_for_Password_abcde()
        {
            //Given
            var passwordPolicy = new PasswordPositionPolicy(1, 3, 'a');
            var password = new Password("abcde", passwordPolicy);
            const bool expectedPasswordValidity = true;

            //When
            var passwordValidity = password.IsValid();

            //Then
            Assert.Equal(expectedPasswordValidity, passwordValidity);
        }
    }
}