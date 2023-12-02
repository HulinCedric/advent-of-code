using Xunit;

namespace AdventOfCode._2020.Day04.PassportFields
{
    public class EyeColorPassportFieldShould
    {
        [Theory]
        [InlineData("ecl:wat")]
        [InlineData("ecl:zzz")]
        [InlineData("ecl:1")]
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
        [InlineData("ecl:amb")]
        [InlineData("ecl:blu")]
        [InlineData("ecl:brn")]
        [InlineData("ecl:gry")]
        [InlineData("ecl:grn")]
        [InlineData("ecl:hzl")]
        [InlineData("ecl:oth")]
        public void Be_valid_when_know_eye_color(string passportFieldDescription)
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