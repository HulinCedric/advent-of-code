using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace AdventOfCode._2021.Day19;

public class BeaconScannerShould
{
    [Theory]
    [InlineData(
        "--- scanner 0 ---\n404,-588,-901\n528,-643,409\n-838,591,734\n390,-675,-793\n-537,-823,-458\n-485,-357,347\n-345,-311,381\n-661,-816,-575\n-876,649,763\n-618,-824,-621\n553,345,-567\n474,580,667\n-447,-329,318\n-584,868,-557\n544,-627,-890\n564,392,-477\n455,729,728\n-892,524,684\n-689,845,-530\n423,-701,434\n7,-33,-71\n630,319,-379\n443,580,662\n-789,900,-551\n459,-707,401\n\n--- scanner 1 ---\n686,422,578\n605,423,415\n515,917,-361\n-336,658,858\n95,138,22\n-476,619,847\n-340,-569,-846\n567,-361,727\n-460,603,-452\n669,-402,600\n729,430,532\n-500,-761,534\n-322,571,750\n-466,-666,-811\n-429,-592,574\n-355,545,-477\n703,-491,-529\n-328,-685,520\n413,935,-424\n-391,539,-444\n586,-435,557\n-364,-763,-893\n807,-499,-711\n755,-354,-619\n553,889,-390\n\n--- scanner 2 ---\n649,640,665\n682,-795,504\n-784,533,-524\n-644,584,-595\n-588,-843,648\n-30,6,44\n-674,560,763\n500,723,-460\n609,671,-379\n-555,-800,653\n-675,-892,-343\n697,-426,-610\n578,704,681\n493,664,-388\n-671,-858,530\n-667,343,800\n571,-461,-707\n-138,-166,112\n-889,563,-600\n646,-828,498\n640,759,510\n-630,509,768\n-681,-892,-333\n673,-379,-804\n-742,-814,-386\n577,-820,562\n\n--- scanner 3 ---\n-589,542,597\n605,-692,669\n-500,565,-823\n-660,373,557\n-458,-679,-417\n-488,449,543\n-626,468,-788\n338,-750,-386\n528,-832,-391\n562,-778,733\n-938,-730,414\n543,643,-506\n-524,371,-870\n407,773,750\n-104,29,83\n378,-903,-323\n-778,-728,485\n426,699,580\n-438,-605,-362\n-469,-447,-387\n509,732,623\n647,635,-688\n-868,-804,481\n614,-800,639\n595,780,-596\n\n--- scanner 4 ---\n727,592,562\n-293,-554,779\n441,611,-461\n-714,465,-776\n-743,427,-804\n-660,-479,-426\n832,-632,460\n927,-485,-438\n408,393,-506\n466,436,-512\n110,16,151\n-258,-428,682\n-393,719,612\n-211,-452,876\n808,-476,-593\n-575,615,604\n-485,667,467\n-680,325,-822\n-627,-443,-432\n872,-547,-609\n833,512,582\n807,604,487\n839,-516,451\n891,-625,532\n-652,-548,-490\n30,-46,-14",
        79)]
    [InputFileData("2021/Day19/input.txt", 13148)]
    public void How_many_beacons_are_there(
        string input,
        int expected)
    {
        // Given


        // When
        var actual = GetCoords(input).beacons.Count;

        // Then
        expected.Should().Be(actual);
    }

    [Theory]
    [InlineData(
        "--- scanner 0 ---\n404,-588,-901\n528,-643,409\n-838,591,734\n390,-675,-793\n-537,-823,-458\n-485,-357,347\n-345,-311,381\n-661,-816,-575\n-876,649,763\n-618,-824,-621\n553,345,-567\n474,580,667\n-447,-329,318\n-584,868,-557\n544,-627,-890\n564,392,-477\n455,729,728\n-892,524,684\n-689,845,-530\n423,-701,434\n7,-33,-71\n630,319,-379\n443,580,662\n-789,900,-551\n459,-707,401\n\n--- scanner 1 ---\n686,422,578\n605,423,415\n515,917,-361\n-336,658,858\n95,138,22\n-476,619,847\n-340,-569,-846\n567,-361,727\n-460,603,-452\n669,-402,600\n729,430,532\n-500,-761,534\n-322,571,750\n-466,-666,-811\n-429,-592,574\n-355,545,-477\n703,-491,-529\n-328,-685,520\n413,935,-424\n-391,539,-444\n586,-435,557\n-364,-763,-893\n807,-499,-711\n755,-354,-619\n553,889,-390\n\n--- scanner 2 ---\n649,640,665\n682,-795,504\n-784,533,-524\n-644,584,-595\n-588,-843,648\n-30,6,44\n-674,560,763\n500,723,-460\n609,671,-379\n-555,-800,653\n-675,-892,-343\n697,-426,-610\n578,704,681\n493,664,-388\n-671,-858,530\n-667,343,800\n571,-461,-707\n-138,-166,112\n-889,563,-600\n646,-828,498\n640,759,510\n-630,509,768\n-681,-892,-333\n673,-379,-804\n-742,-814,-386\n577,-820,562\n\n--- scanner 3 ---\n-589,542,597\n605,-692,669\n-500,565,-823\n-660,373,557\n-458,-679,-417\n-488,449,543\n-626,468,-788\n338,-750,-386\n528,-832,-391\n562,-778,733\n-938,-730,414\n543,643,-506\n-524,371,-870\n407,773,750\n-104,29,83\n378,-903,-323\n-778,-728,485\n426,699,580\n-438,-605,-362\n-469,-447,-387\n509,732,623\n647,635,-688\n-868,-804,481\n614,-800,639\n595,780,-596\n\n--- scanner 4 ---\n727,592,562\n-293,-554,779\n441,611,-461\n-714,465,-776\n-743,427,-804\n-660,-479,-426\n832,-632,460\n927,-485,-438\n408,393,-506\n466,436,-512\n110,16,151\n-258,-428,682\n-393,719,612\n-211,-452,876\n808,-476,-593\n-575,615,604\n-485,667,467\n-680,325,-822\n-627,-443,-432\n872,-547,-609\n833,512,582\n807,604,487\n839,-516,451\n891,-625,532\n-652,-548,-490\n30,-46,-14",
        3621)]
    [InputFileData("2021/Day19/input.txt", 1)]
    public void What_is_the_largest_Manhattan_distance_between_any_two_scanners(
        string input,
        int expected)
    {
        // Given
        var scanners = GetCoords(input).scanners;

        // When
        var actual = (
                         from sA in scanners
                         from sB in scanners
                         where sA != sB
                         select Math.Abs(sA.x - sB.x) + Math.Abs(sA.y - sB.y) + Math.Abs(sA.z - sB.z)
                     ).Max();

        // Then
        expected.Should().Be(actual);
    }

    private (HashSet<Coord> beacons, HashSet<Coord> scanners) GetCoords(string input)
    {
        var scanners = new List<Scanner>(Parse(input));
        var fixedScanners = new Dictionary<Coord, Scanner>();

        fixedScanners[new Coord(0, 0, 0)] = scanners[0];
        scanners.RemoveAt(0);

        while (scanners.Any())
        {
            var (posB, scannerB) = GetCenter(fixedScanners, scanners);
            fixedScanners[posB] = scannerB;
            Console.WriteLine("found " + scanners.Count);
        }

        var beacons = new HashSet<Coord>();
        foreach (var (pos, scanner) in fixedScanners)
        foreach (var c in scanner.GetBeaconsRelativeTo(pos))
            beacons.Add(c);
        return (beacons, fixedScanners.Keys.ToHashSet());
    }

    private (Coord, Scanner) GetCenter(Dictionary<Coord, Scanner> fixedScanners, List<Scanner> scanners)
    {
        for (var i = 0; i < scanners.Count; i++)
        {
            var scannerB = scanners[i];
            foreach (var (posA, scannerA) in fixedScanners)
            {
                var ptAs = scannerA.GetBeaconsRelativeTo(posA).ToHashSet();
                foreach (var ptA in ptAs)
                    for (var rotation = 0; rotation < 48; rotation++, scannerB = scannerB.Rotate())
                        foreach (var ptB in scannerB.GetBeaconsRelativeTo(new Coord(0, 0, 0)))
                        {
                            var center = new Coord(ptA.x - ptB.x, ptA.y - ptB.y, ptA.z - ptB.z);
                            var ptBs = scannerB.GetBeaconsRelativeTo(center).ToHashSet();

                            var c = ptAs.Intersect(ptBs).Count();

                            if (c >= 12)
                            {
                                Console.WriteLine("x");
                                scanners.RemoveAt(i);
                                return (center, scannerB);
                            }
                        }
            }
        }

        Console.WriteLine("---");
        throw new Exception();
    }

    private Scanner[] Parse(string input)
        => (
               from block in input.Split("\n\n")
               let beacons =
                   from line in block.Split("\n").Skip(1)
                   let parts = line.Split(",").Select(int.Parse).ToArray()
                   select new Coord(parts[0], parts[1], parts[2])
               select new Scanner(0, beacons.ToList())
           ).ToArray();
}

internal record Coord(int x, int y, int z);

internal record Scanner(int rotation, List<Coord> beacons)
{
    public Scanner Rotate()
        => new(rotation + 1, beacons);

    public Coord[] GetBeaconsRelativeTo(Coord coord)
    {
        Coord transform(Coord coord)
        {
            var (x, y, z) = coord;

            switch (rotation % 6)
            {
                case 0:
                    (x, y, z) = (x, y, z);
                    break;
                case 1:
                    (x, y, z) = (x, z, y);
                    break;
                case 2:
                    (x, y, z) = (y, x, z);
                    break;
                case 3:
                    (x, y, z) = (y, z, x);
                    break;
                case 4:
                    (x, y, z) = (z, x, y);
                    break;
                case 5:
                    (x, y, z) = (z, y, x);
                    break;
                default:
                    throw new Exception();
            }

            switch (rotation / 6 % 8)
            {
                case 0:
                    (x, y, z) = (x, y, z);
                    break;
                case 1:
                    (x, y, z) = (-x, y, z);
                    break;
                case 2:
                    (x, y, z) = (x, -y, z);
                    break;
                case 3:
                    (x, y, z) = (-x, -y, z);
                    break;
                case 4:
                    (x, y, z) = (x, y, -z);
                    break;
                case 5:
                    (x, y, z) = (-x, y, -z);
                    break;
                case 6:
                    (x, y, z) = (x, -y, -z);
                    break;
                case 7:
                    (x, y, z) = (-x, -y, -z);
                    break;
                default:
                    throw new Exception();
            }

            return new Coord(x, y, z);
        }

        return beacons.Select(
                beacon =>
                {
                    var t = transform(beacon);
                    return new Coord(coord.x + t.x, coord.y + t.y, coord.z + t.z);
                })
            .ToArray();
    }
}