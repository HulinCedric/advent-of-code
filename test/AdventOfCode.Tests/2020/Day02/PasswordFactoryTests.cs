using Xunit;

namespace AdventOfCode._2020.Day02
{
    public class PasswordFactoryTests
    {
        [Fact]
        public void Invalid_When_DescriptionIs_1_3_b_cdefg()
        {
            //Given
            var password = PasswordFactory.CreatePasswordWithOccurrencePolicy("1-3 b: cdefg");
            const bool expectedPasswordValidity = false;

            //When
            var passwordValidity = password.IsValid();

            //Then
            Assert.Equal(expectedPasswordValidity, passwordValidity);
        }

        [Fact]
        public void Valid_When_DescriptionIs_1_3_a_abcde()
        {
            //Given
            var password = PasswordFactory.CreatePasswordWithOccurrencePolicy("1-3 a: abcde");
            const bool expectedPasswordValidity = true;

            //When
            var passwordValidity = password.IsValid();

            //Then
            Assert.Equal(expectedPasswordValidity, passwordValidity);
        }

        [Fact]
        public void Valid_When_DescriptionIs_2_9_c_ccccccccc()
        {
            //Given
            var password = PasswordFactory.CreatePasswordWithOccurrencePolicy("2-9 c: ccccccccc");
            const bool expectedPasswordValidity = true;

            //When
            var passwordValidity = password.IsValid();

            //Then
            Assert.Equal(expectedPasswordValidity, passwordValidity);
        }
    }
}