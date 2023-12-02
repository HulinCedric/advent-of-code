namespace AdventOfCode._2020.Day08.Programs
{
    public static class ProgramDescription
    {
        public const string InfiniteLoopExampleDescription =
            "nop +0\n" +
            "acc +1\n" +
            "jmp +4\n" +
            "acc +3\n" +
            "jmp -3\n" +
            "acc -99\n" +
            "acc +1\n" +
            "jmp -4\n" +
            "acc +6";

        public const string TerminableExampleDescription =
            "nop +0\n" +
            "acc +1\n" +
            "jmp +4\n" +
            "acc +3\n" +
            "jmp -3\n" +
            "acc -99\n" +
            "acc +1\n" +
            "nop -4\n" +
            "acc +6";
    }
}