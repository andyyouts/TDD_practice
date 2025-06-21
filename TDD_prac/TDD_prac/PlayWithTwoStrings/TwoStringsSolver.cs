namespace TDD_prac.PlayWithTwoStrings;
using System.Linq;

public static class TwoStringsSolver
{
    private static Dictionary<char, int> Counter = new();
    public static string Solve(string str1, string str2)
    {
        var changedA = SwapCases(str1, str2);
        var changedB = SwapCases(str2, str1);
        return string.Concat(changedA, changedB);;
    }

    private static string SwapCases(string source, string target)
    {
        CountCharacterOccurrences(target);
        var adjustedCharArray = source.Select(GetAdjustedCases).ToArray();
        return new string(adjustedCharArray);
    }

    private static void CountCharacterOccurrences(string target)
    {
        Counter = target
            .GroupBy(char.ToLower)
            .ToDictionary(g => g.Key, g => g.Count());
    }

    private static char GetAdjustedCases(char c)
    {
        var lower = char.ToLower(c);

        if (Counter.TryGetValue(lower, out var value) && value % 2 == 1)
        {
            // Odd number of matches => swap case
            return char.IsUpper(c)
                ? char.ToLower(c)
                : char.ToUpper(c);
        }

        return c;
    }
}