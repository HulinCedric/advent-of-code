using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2023.Day17;

public class Map : Dictionary<Position, int>
{
    private const int InitialHeatLoss = 0;
    private readonly Position bottomRight;
    private readonly Position topLeft;

    public Map(IEnumerable<KeyValuePair<Position, int>> collection)
        : base(collection)
    {
        topLeft = Keys.MinBy(pos => pos.X + pos.Y);
        bottomRight = Keys.MaxBy(pos => pos.X + pos.Y);
    }

    public int LeastHeatLoss(CrucibleFactory crucibleFactory)
    {
        var queue = new PriorityQueue<Crucible, int>();
        queue.Enqueue(Start(crucibleFactory, Direction.Right), InitialHeatLoss);
        queue.Enqueue(Start(crucibleFactory, Direction.Down), InitialHeatLoss);

        var seen = new HashSet<Crucible>();
        while (queue.TryDequeue(out var crucible, out var heatLoss))
        {
            if (ReachEnd(crucible) &&
                crucible.CanStop())
            {
                return heatLoss;
            }

            foreach (var nextCrucible in crucible.Moves())
            {
                if (NoInMap(nextCrucible))
                {
                    continue;
                }

                if (AlreadySeen(seen, nextCrucible))
                {
                    continue;
                }

                seen.Add(nextCrucible);

                var nextHeatLoss = this[nextCrucible.Position];
                queue.Enqueue(nextCrucible, heatLoss + nextHeatLoss);
            }
        }

        return int.MaxValue;
    }

    private static bool AlreadySeen(HashSet<Crucible> seen, Crucible nextCrucible)
        => seen.Contains(nextCrucible);

    private bool NoInMap(Crucible nextCrucible)
        => !ContainsKey(nextCrucible.Position);

    private Crucible Start(CrucibleFactory crucibleFactory, Direction direction)
        => crucibleFactory.Create(topLeft, direction);

    private bool ReachEnd(Crucible crucible)
        => crucible.Position == bottomRight;
}