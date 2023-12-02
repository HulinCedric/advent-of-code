using Xunit;

namespace AdventOfCode._2020.Day04.PassportFields
{
    public class CountryIdPassportFieldShould
    {
        [Theory]
        [InlineData("cid:000000001")]
        [InlineData("cid:")]
        [InlineData("cid:a")]
        public void Be_always_valid(string passportFieldDescription)
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