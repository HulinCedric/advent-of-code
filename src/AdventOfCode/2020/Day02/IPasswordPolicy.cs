namespace AdventOfCode._2020.Day02
{
    public interface IPasswordPolicy
    {
        bool Validate(string password);
    }
}