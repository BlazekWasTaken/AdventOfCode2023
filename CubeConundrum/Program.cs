using System.Reflection;

var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty, "input.txt");
var lines = File.ReadAllLines(path).ToList();

#region Part One

var sum1 = 0;

foreach (var line in lines)
{
    Game game = new()
    {
        Id = int.Parse(line.Split(":")[0].Split(" ")[1])
    };
    foreach (var roundText in line.Split(":")[1].Split(";"))
    {
        Round round = new();
        foreach (var count in roundText.TrimStart().TrimEnd().Split(","))
        {
            var color = count.TrimStart().TrimEnd().Split(" ")[1];
            switch (color)
            {
                case "red":
                    round.Red = int.Parse(count.TrimStart().TrimEnd().Split(" ")[0]);
                    break;
                case "green":
                    round.Green = int.Parse(count.TrimStart().TrimEnd().Split(" ")[0]);
                    break;
                case "blue":
                    round.Blue = int.Parse(count.TrimStart().TrimEnd().Split(" ")[0]);
                    break;
            }
        }
        game.Rounds.Add(round);
    }

    if (!game.Rounds.Any(x => x.Red > 12 || x.Green > 13 || x.Blue > 14))
    {
        sum1 += game.Id;
    }
}

Console.WriteLine($"Part Two: {sum1}");

#endregion

#region Part Two

var sum2 = 0;

foreach (var line in lines)
{
    Game game = new()
    {
        Id = int.Parse(line.Split(":")[0].Split(" ")[1])
    };
    foreach (var roundText in line.Split(":")[1].Split(";"))
    {
        Round round = new();
        foreach (var count in roundText.TrimStart().TrimEnd().Split(","))
        {
            var color = count.TrimStart().TrimEnd().Split(" ")[1];
            switch (color)
            {
                case "red":
                    round.Red = int.Parse(count.TrimStart().TrimEnd().Split(" ")[0]);
                    break;
                case "green":
                    round.Green = int.Parse(count.TrimStart().TrimEnd().Split(" ")[0]);
                    break;
                case "blue":
                    round.Blue = int.Parse(count.TrimStart().TrimEnd().Split(" ")[0]);
                    break;
            }
        }
        game.Rounds.Add(round);
    }

    var maxRed = game.Rounds.Max(x => x.Red);
    var maxGreen = game.Rounds.Max(x => x.Green);
    var maxBlue = game.Rounds.Max(x => x.Blue);
    var power = maxRed * maxGreen * maxBlue;
    sum2 += power;
}

Console.WriteLine($"Part Two: {sum2}");

#endregion

internal class Round
{
    public int Red { get; set; } = 0;
    public int Green { get; set; } = 0;
    public int Blue { get; set; } = 0;
}

internal class Game
{
    public int Id { get; init; }
    public List<Round> Rounds { get; } = new();
}