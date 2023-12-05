using System.Net.Http.Headers;
using System.Reflection;

var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty, "input.txt");
var lines = File.ReadAllLines(path).ToList();

#region Part One

var sum1 = 0;
foreach (var line in lines)
{
    var digits = line.Where(char.IsDigit).ToArray();
    if (digits.Length == 1)
    {
        sum1 += int.Parse(digits) * 11;
    }
    else
    {
        sum1 += int.Parse($"{digits[0]}{digits[^1]}");
    }
}

Console.WriteLine($"Part One: {sum1}");

#endregion

#region Part Two

var sum2 = 0;
var digitWords = new Dictionary<string, string> { 
    {"one", "o1e"}, 
    {"two", "t2o"}, 
    {"three", "t3e"}, 
    {"four", "f4r"}, 
    {"five", "f5e"}, 
    {"six", "s6x"}, 
    {"seven", "s7n"}, 
    {"eight", "e8t"}, 
    {"nine", "n9e"} 
};

foreach (var line in lines)
{
    var newLine = line;
    var wordIndex = new Dictionary<string, int> { 
        {"one", 0}, 
        {"two", 0}, 
        {"three", 0}, 
        {"four", 0}, 
        {"five", 0}, 
        {"six", 0}, 
        {"seven", 0}, 
        {"eight", 0}, 
        {"nine", 0}
    };
    while (wordIndex.Values.Any(x => x != int.MaxValue))
    {
        foreach (var word in wordIndex)
        {
            var index = newLine.IndexOf(word.Key, StringComparison.Ordinal);
            if (index == -1)
            {
                wordIndex[word.Key] = int.MaxValue;
            }
            else
            {
                wordIndex[word.Key] = index;
            }
        }


        var digit = wordIndex.Keys.First(x => wordIndex[x] == wordIndex.Values.Min());
        newLine = newLine.Replace(digit, digitWords.First(x => x.Key == digit).Value);
    }
    
    
    
    var digits = new string(newLine.Where(char.IsDigit).ToArray());
    if (digits.Length == 1)
    {
        sum2 += int.Parse(digits) * 11;
    }
    else
    {
        sum2 += int.Parse($"{digits[0]}{digits[^1]}");
    }
}

Console.WriteLine($"Part One: {sum2}");

#endregion