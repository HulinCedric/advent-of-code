using AdventOfCode._2020.Day04.Inputs;
using Xunit;

namespace AdventOfCode._2020.Day04.Passports
{
    public class PassportFactoryShould
    {
        [Fact]
        public void Give_a_credential_when_only_missing_cid_field()
        {
            //Given
            var expectedType = typeof(Credential);

            //When
            var credential = PassportFactory.Create(PassportDescription.Third);

            //Then
            Assert.IsType(expectedType, credential);
        }

        [Fact]
        public void Give_a_passport_when_presence_of_cid_field()
        {
            //Given
            var expectedType = typeof(Passport);

            //When
            var passport = PassportFactory.Create(PassportDescription.First);

            //Then
            Assert.IsType(expectedType, passport);
        }
    }
}