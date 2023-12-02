using System.Linq;
using AdventOfCode._2020.Day04.Passports;

namespace AdventOfCode._2020.Day04
{
    public static class PassportScanner
    {
        public static int CountValidPassports(string batchFileDescription)
            => PassportParser
                .ParseBatchFile(batchFileDescription)
                .Select(PassportFactory.Create)
                .Count(passport => passport.ContainsAllRequiredFields());

        public static int CountValidPassportsWithValidValues(string batchFileDescription)
            => PassportParser
                .ParseBatchFile(batchFileDescription)
                .Select(PassportFactory.Create)
                .Count(passport => passport.ContainsAllRequiredValidFields());
    }
}