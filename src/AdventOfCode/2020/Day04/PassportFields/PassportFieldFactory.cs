namespace AdventOfCode._2020.Day04.PassportFields
{
    public static class PassportFieldFactory
    {
        public static PassportField Create(string passportFieldDescription)
        {
            var passportFieldInformations = PassportParser.ParsePassportFieldDescription(passportFieldDescription);
            return passportFieldInformations switch
            {
                ("byr", _) => new BirthYearPassportField(passportFieldInformations.Value),
                ("iyr", _) => new IssueYearPassportField(passportFieldInformations.Value),
                ("eyr", _) => new ExpirationYearPassportField(passportFieldInformations.Value),
                ("hgt", _) when passportFieldInformations.Value.EndsWith("cm") => new HeightInCentimetrePassportField(passportFieldInformations.Value),
                ("hgt", _) when passportFieldInformations.Value.EndsWith("in") => new HeightInInchPassportField(passportFieldInformations.Value),
                ("hgt", _) => new HeightPassportField(passportFieldInformations.Value),
                ("hcl", _) => new HairColorPassportField(passportFieldInformations.Value),
                ("ecl", _) => new EyeColorPassportField(passportFieldInformations.Value),
                ("pid", _) => new PassportIdPassportField(passportFieldInformations.Value),
                ("cid", _) => new CountryIdPassportField(passportFieldInformations.Value),
                _ => new UnknownPassportField(passportFieldInformations.Value)
            };
        }
    }
}