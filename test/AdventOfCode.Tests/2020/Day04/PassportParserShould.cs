using System.Linq;
using AdventOfCode._2020.Day04.Inputs;
using AdventOfCode._2020.Day04.PassportFields;
using Xunit;

namespace AdventOfCode._2020.Day04
{
    public class PassportParserShould
    {
        [Theory]
        [InlineData("byr:2002", "byr", "2002")]
        [InlineData("hgt:190in", "hgt", "190in")]
        public void Give_passeport_field_informations_separate_by_colon(
            string passportFieldDescription,
            string expectedPassportFieldName,
            string expectedPassportFieldValue)
        {
            // Given
            var expectedPassportFieldInformation = new PassportFieldInformation(
                expectedPassportFieldName,
                expectedPassportFieldValue);

            //When
            var actualPassportFieldInformation = PassportParser.ParsePassportFieldDescription(passportFieldDescription);

            //Then
            Assert.Equal(expectedPassportFieldInformation, actualPassportFieldInformation);
        }

        [Theory]
        [InlineData(0, 8)]
        [InlineData(1, 7)]
        [InlineData(2, 7)]
        [InlineData(3, 6)]
        public void Give_passeport_fields_separate_by_spaces_or_newlines(
            int passportNumber,
            int expectedPassportFieldsCount)
        {
            //Given
            const string batchFileDescription = BatchFileDescription.PartOneExampleDescription;

            //When
            var passportFieldsCount = PassportParser.ParsePassportDescription(
                    PassportParser
                        .ParseBatchFile(batchFileDescription)
                        .ElementAt(passportNumber))
                .Count();

            //Then
            Assert.Equal(expectedPassportFieldsCount, passportFieldsCount);
        }

        [Fact]
        public void Give_passeports_separate_by_blank_lines()
        {
            //Given
            const string batchFileDescription = BatchFileDescription.PartOneExampleDescription;
            const int expectedPassportsCount = 4;

            //When
            var passportsCount = PassportParser.ParseBatchFile(batchFileDescription).Count();

            //Then
            Assert.Equal(expectedPassportsCount, passportsCount);
        }
    }
}