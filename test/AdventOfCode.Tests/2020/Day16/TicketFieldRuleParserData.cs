using Xunit;

namespace AdventOfCode._2020.Day16
{
    public class TicketFieldRuleParserData
        : TheoryData<string, string[], ushort[][]>
    {
        public TicketFieldRuleParserData()
        {
            Add(
                "class: 1-3 or 5-7",
                new[]
                {
                    "class"
                },
                new[]
                {
                    new ushort[]
                    {
                        1, 3, 5, 7
                    }
                });

            Add(
                "row: 6-11 or 33-44",
                new[]
                {
                    "row"
                },
                new[]
                {
                    new ushort[]
                    {
                        6, 11, 33, 44
                    }
                });


            Add(
                "seat: 13-40 or 45-50",
                new[]
                {
                    "seat"
                },
                new[]
                {
                    new ushort[]
                    {
                        13, 40, 45, 50
                    }
                });

            Add(
                TicketFieldsRulesInformation.FirstExample,
                new[]
                {
                    "class",
                    "row",
                    "seat"
                },
                new[]
                {
                    new ushort[]
                    {
                        1, 3, 5, 7
                    },
                    new ushort[]
                    {
                        6, 11, 33, 44
                    },
                    new ushort[]
                    {
                        13, 40, 45, 50
                    }
                });
        }
    }
}