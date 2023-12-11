namespace AdventOfCode._2023.Day06;

public record Race(int Time, long Distance)
{
    public int CalculateWaysToWin()
    {
        var waysToWin = 0;
        for (var i = 0; i < Time; i++)
        {
            var boat = new Boat();
            boat.HoldButton(i.Milliseconds());

            var timeLeftForTheRace = Time - i;

            boat.Move(timeLeftForTheRace.Milliseconds());

            if (boat.Distance > Distance)
            {
                waysToWin++;
            }
        }

        return waysToWin;
    }
}