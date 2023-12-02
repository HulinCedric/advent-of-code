using Xunit;

namespace AdventOfCode._2020.Day04.PassportFields
{
    public class HairColorPassportFieldShould
    {
        [Theory]
        [InlineData("hcl:#123abc")]
        [InlineData("hcl:#a97842")]
        public void Be_valid_when_start_with_sharp_followed_by_exactly_six_characters_0_9_or_a_f(string passportFieldDescription)
        {
            //Given
            var passportField = PassportFieldFactory.Create(passportFieldDescription);

            //When
            var passportFieldValidity = passportField.IsValid();

            //Then
            Assert.True(passportFieldValidity);
        }

        [Theory]
        [InlineData("hcl:123abc")]
        [InlineData("hcl:#123abz")]
        [InlineData("hcl:74454a")]
        public void Be_invalid_for(string passportFieldDescription)
        {
            //Given
            var passportField = PassportFieldFactory.Create(passportFieldDescription);

            //When
            var passportFieldValidity = passportField.IsValid();

            //Then
            Assert.False(passportFieldValidity);
        }
    }
}