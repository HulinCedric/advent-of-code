using System;
using Xunit;

namespace AdventOfCode._2020.Day04.PassportFields
{
    public class PassportFieldFactoryShould
    {
        [Theory]
        [InlineData("byr:2002", typeof(BirthYearPassportField))]
        [InlineData("iyr:2014", typeof(IssueYearPassportField))]
        [InlineData("eyr:2021", typeof(ExpirationYearPassportField))]
        [InlineData("hgt:165cm", typeof(HeightInCentimetrePassportField))]
        [InlineData("hgt:74in", typeof(HeightInInchPassportField))]
        [InlineData("hgt:74wa", typeof(HeightPassportField))]
        [InlineData("hcl:#a97842", typeof(HairColorPassportField))]
        [InlineData("ecl:blu", typeof(EyeColorPassportField))]
        [InlineData("pid:0123456789", typeof(PassportIdPassportField))]
        [InlineData("cid:88", typeof(CountryIdPassportField))]
        [InlineData("azz:1234", typeof(UnknownPassportField))]
        public void Create_a_passport_field_for_passport_field_description(
            string passportFieldDescription,
            Type expectedPassportFieldType)
        {
            //When
            var passportField = PassportFieldFactory.Create(passportFieldDescription);

            //Then
            Assert.IsType(expectedPassportFieldType, passportField);
        }
    }
}