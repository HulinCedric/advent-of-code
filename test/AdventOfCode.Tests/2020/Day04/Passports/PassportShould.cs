using AdventOfCode._2020.Day04.Inputs;
using Xunit;

namespace AdventOfCode._2020.Day04.Passports
{
    public class PassportShould
    {
        [Theory]
        [InlineData("eyr:1972 cid:100\nhcl:#18171d ecl:amb hgt:170 pid:186cm iyr:2018 byr:1926")]
        [InlineData("iyr:2019\nhcl:#602927 eyr:1967 hgt:170cm\necl:grn pid:012533040 byr:1946")]
        [InlineData("hcl:dab227 iyr:2012\necl:brn hgt:182cm pid:021572410 eyr:2020 byr:1992 cid:277")]
        [InlineData("hgt:59cm ecl:zzz\neyr:2038 hcl:74454a iyr:2023\npid:3556412378 byr:2007")]
        public void Be_invalid_when_all_fields_are_present_and_some_values_are_invalid(string passportDescription)
        {
            //Given
            var passport = PassportFactory.Create(passportDescription);
            const bool expectedPassportValidity = false;

            //When
            var passportValidity = passport.ContainsAllRequiredValidFields();

            //Then
            Assert.Equal(expectedPassportValidity, passportValidity);
        }

        [Fact]
        public void Be_invalid_when_missing_cid_and_byr_fields()
        {
            //Given
            var passport = PassportFactory.Create(PassportDescription.Fourth);
            const bool expectedPassportValidity = false;

            //When
            var passportValidity = passport.ContainsAllRequiredFields();

            //Then
            Assert.Equal(expectedPassportValidity, passportValidity);
        }

        [Fact]
        public void Be_invalid_when_missing_hgt_field()
        {
            //Given
            var passport = PassportFactory.Create(PassportDescription.Second);
            const bool expectedPassportValidity = false;

            //When
            var passportValidity = passport.ContainsAllRequiredFields();

            //Then
            Assert.Equal(expectedPassportValidity, passportValidity);
        }

        [Fact]
        public void Be_valid_when_all_fields_are_present()
        {
            //Given
            var passport = PassportFactory.Create(PassportDescription.First);
            const bool expectedPassportValidity = true;

            //When
            var passportValidity = passport.ContainsAllRequiredFields();

            //Then
            Assert.Equal(expectedPassportValidity, passportValidity);
        }

        [Theory]
        [InlineData("pid:087499704 hgt:74in ecl:grn iyr:2012 eyr:2030 byr:1980\nhcl:#623a2f")]
        [InlineData("eyr:2029 ecl:blu cid:129 byr:1989\niyr:2014 pid:896056539 hcl:#a97842 hgt:165cm")]
        [InlineData("hcl:#888785\nhgt:164cm byr:2001 iyr:2015 cid:88\npid:545766238 ecl:hzl\neyr:2022")]
        [InlineData("iyr:2010 hgt:158cm hcl:#b6652a ecl:blu byr:1944 eyr:2021 pid:093154719")]
        public void Be_valid_when_all_fields_are_present_and_all_values_are_valid(string passportDescription)
        {
            //Given
            var passport = PassportFactory.Create(passportDescription);
            const bool expectedPassportValidity = true;

            //When
            var passportValidity = passport.ContainsAllRequiredValidFields();

            //Then
            Assert.Equal(expectedPassportValidity, passportValidity);
        }

        [Fact]
        public void Be_valid_when_only_missing_cid_field()
        {
            //Given
            var passport = PassportFactory.Create(PassportDescription.Third);
            const bool expectedPassportValidity = true;

            //When
            var passportValidity = passport.ContainsAllRequiredFields();

            //Then
            Assert.Equal(expectedPassportValidity, passportValidity);
        }
    }
}