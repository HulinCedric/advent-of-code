using Xunit;

namespace AdventOfCode._2020.Day04.PassportFields
{
    public class IssueYearPassportFieldShould
    {
        [Theory]
        [InlineData("iyr:a")]
        [InlineData("iyr:12a4")]
        [InlineData("iyr:1")]
        [InlineData("iyr:12345")]
        [InlineData("iyr:2009")]
        [InlineData("iyr:2021")]
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
        [InlineData("iyr:2010")]
        [InlineData("iyr:2020")]
        public void Be_valid_when_composed_of_four_digits_at_least_2010_and_at_most_2020(string passportFieldDescription)
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