using System.Globalization;

namespace TDD_prac.StringAverage;

public class StringAverageSolver
{
    private readonly Dictionary<string, int> _numberStringToInt = new()
    {
        {"one", 1},
        {"two", 2},
        {"three", 3},
        {"four", 4},
        {"five", 5},
        {"six", 6},
        {"seven", 7},
        {"eight", 8},
        {"nine", 9},
    };

    public string GetStringAverage(string numbersAsWords)
    {
        if (string.IsNullOrWhiteSpace(numbersAsWords))
        {
            return "n/a";
        }

        var wordNumbers = numbersAsWords.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        return !TryParseAllNumbers(wordNumbers, out var sum)
            ? "n/a"
            : CalculateAverage(sum, wordNumbers.Length);
    }

    private bool TryParseAllNumbers(string[] wordNumbers, out int sum)
    {
        sum = 0;

        foreach (var wordNumber in wordNumbers)
        {
            if (!_numberStringToInt.TryGetValue(wordNumber.ToLower(), out var value))
            {
                return false;
            }

            sum += value;
        }

        return true;
    }

    private static string CalculateAverage(int sum, int count)
    {
        var average = Math.Floor(sum / (double)count);
        return average.ToString(CultureInfo.InvariantCulture);
    }
    
}