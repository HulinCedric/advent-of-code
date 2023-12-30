namespace AdventOfCode._2023.Day17;

public class CrucibleFactory(int minStraight, int maxStraight)
{
    public static CrucibleFactory NormalCrucible()
        => new(minStraight: 0, maxStraight: 3);


    public static CrucibleFactory UltraCrucible()
        => new(minStraight: 4, maxStraight: 10);

    public Crucible Create(Position position, Direction direction)
        => Crucible.New(position, direction, minStraight, maxStraight);
}