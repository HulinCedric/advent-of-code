using Xunit;

namespace AdventOfCode._2020.Day04.PassportFields
{
    public class HeightPassportFieldShould
    {
        [Theory]
        [InlineData("hgt:")]
        [InlineData("hgt:a")]
        [InlineData("hgt:1")]
        [InlineData("hgt:42aa")]
        [InlineData("hgt:58in")]
        [InlineData("hgt:77in")]
        [InlineData("hgt:149cm")]
        [InlineData("hgt:194cm")]
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
        [InlineData("hgt:150cm")]
        [InlineData("hgt:193cm")]
        public void Be_valid_when_number_at_least_150_and_at_most_193_and_followed_by_cm(string passportFieldDescription)
        {
            //Given
            var passportField = PassportFieldFactory.Create(passportFieldDescription);

            //When
            var passportFieldValidity = passportField.IsValid();

            //Then
            Assert.True(passportFieldValidity);
        }

        [Theory]
        [InlineData("hgt:59in")]
        [InlineData("hgt:76in")]
        public void Be_valid_when_number_at_least_59_and_at_most_76_and_followed_by_in(string passportFieldDescription)
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