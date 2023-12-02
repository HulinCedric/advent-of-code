using Xunit;

namespace AdventOfCode._2020.Day04.PassportFields
{
    public class PassportIdPassportFieldShould
    {
        [Theory]
        [InlineData("pid:aaaaaaaaa")]
        [InlineData("pid:0123456789")]
        [InlineData("pid:01234567")]
        public void Be_invalid_for(string passportFieldDescription)
        {
            //Given
            var passportField = PassportFieldFactory.Create(passportFieldDescription);

            //When
            var passportFieldValidity = passportField.IsValid();

            //Then
            Assert.False(passportFieldValidity);
        }

        [Theory]
        [InlineData("pid:000000001")]
        [InlineData("pid:896056539")]
        public void Be_valid_when_composed_of_nine_digit_number_including_leading_zeroes(string passportFieldDescription)
        {
            //Given
            var passportField = PassportFieldFactory.Create(passportFieldDescription);

            //When
            var passportFieldValidity = passportField.IsValid();

            //Then
            Assert.True(passportFieldValidity);
        }
    }
}