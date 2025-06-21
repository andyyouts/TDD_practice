using System.Globalization;

namespace TDD_prac.StringAverage;

public static class StringAverageSolver
{
    private static readonly Dictionary<string, int> NumberStringToInt = new()
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

    public static string GetStringAverage(string numbersAsWords)
    {
        if (string.IsNullOrWhiteSpace(numbersAsWords))
        {
            return "n/a";
        }

        var wordNumbers = numbersAsWords.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        return TryParseAllNumbers(wordNumbers, out var sum)
            ? CalculateAverage(sum, wordNumbers.Length)
            : "n/a";
    }

    private static bool TryParseAllNumbers(string[] wordNumbers, out int sum)
    {
        sum = 0;

        foreach (var wordNumber in wordNumbers)
        {
            if (IsNumberValid(wordNumber, out var value))
            {
                return false;
            }

            sum += value;
        }

        return true;
    }

    private static bool IsNumberValid(string wordNumber, out int value)
    {
        return !NumberStringToInt.TryGetValue(wordNumber.ToLower(), out value);
    }

    private static string CalculateAverage(int sum, int count)
    {
        var average = Math.Floor(sum / (double)count);
        return average.ToString(CultureInfo.InvariantCulture);
    }
    
}