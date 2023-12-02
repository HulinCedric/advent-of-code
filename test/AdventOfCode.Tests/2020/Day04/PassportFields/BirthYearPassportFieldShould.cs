using Xunit;

namespace AdventOfCode._2020.Day04.PassportFields
{
    public class BirthYearPassportFieldShould
    {
        [Theory]
        [InlineData("byr:a")]
        [InlineData("byr:12a4")]
        [InlineData("byr:1")]
        [InlineData("byr:12345")]
        [InlineData("byr:2003")]
        [InlineData("byr:1919")]
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
        [InlineData("byr:2002")]
        [InlineData("byr:1920")]
        public void Be_valid_when_composed_of_four_digits_at_least_1920_and_at_most_2002(string passportFieldDescription)
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