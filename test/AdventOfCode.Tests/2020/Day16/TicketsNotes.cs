namespace AdventOfCode._2020.Day16
{
    public static class TicketsNotes
    {
        public const string FirstExample =
            TicketFieldsRulesInformation.FirstExample +
            "\n" +
            YourTicketNumbers.FirstExample +
            "\n" +
            NearbyTicketsNumbers.FirstExample;

        public const string SecondExample =
            TicketFieldsRulesInformation.SecondExample +
            "\n" +
            YourTicketNumbers.SecondExample +
            "\n" +
            NearbyTicketsNumbers.SecondExample;
    }

    public static class TicketFieldsRulesInformation
    {
        public const string FirstExample =
            "class: 1-3 or 5-7\n" +
            "row: 6-11 or 33-44\n" +
            "seat: 13-40 or 45-50\n";

        public const string SecondExample =
            "class: 0-1 or 4-19\n" +
            "row: 0-5 or 8-19\n" +
            "seat: 0-13 or 16-19\n";
    }

    public static class YourTicketNumbers
    {
        public const string FirstExample =
            "your ticket:\n" +
            "7,1,14\n";

        public const string SecondExample =
            "your ticket:\n" +
            "11,12,13\n";
    }

    public static class NearbyTicketsNumbers
    {
        public const string FirstExample =
            "nearby tickets:\n" +
            "7,3,47\n" +
            "40,4,50\n" +
            "55,2,20\n" +
            "38,6,12";

        public const string SecondExample =
            "nearby tickets:\n" +
            "3,9,18\n" +
            "15,1,5\n" +
            "5,14,9";
    }
}