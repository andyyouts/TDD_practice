namespace TDD_prac.NextSmallerNumber;

public static class NextSmallerNumberSolver
{
    private const int CannotGenerateNextSmallerNumber = -1;

    public static int GetNextSmallerNumber(int integer)
    {
        if (TryConvertToValidString(integer, out var integerAsString))
        {
            return CannotGenerateNextSmallerNumber;
        }

        var firstIncreasingIndex = FindFirstIncreasingIndex(integerAsString);

        if (IsStringInAscendingOrder(firstIncreasingIndex))
        {
            return CannotGenerateNextSmallerNumber;
        }

        var nextSmallerIndex = FindNextSmallerIndex(integerAsString, firstIncreasingIndex);

        return GenerateNextSmallerNumber(integerAsString, firstIncreasingIndex, nextSmallerIndex);
    }

    private static bool IsStringInAscendingOrder(int firstIncreasingIndex)
    {
        return firstIncreasingIndex == 0;
    }

    private static bool TryConvertToValidString(int integer, out string s)
    {
        s = integer.ToString();
        return s.Length == 1;
    }

    private static int GenerateNextSmallerNumber(string s, int firstIncreasingIndex, int nextSmallerIndex)
    {
        var charArray = s.ToCharArray();
        // Swap the pivot with the rightmost smaller digit
        (charArray[firstIncreasingIndex - 1], charArray[nextSmallerIndex]) = (charArray[nextSmallerIndex], charArray[firstIncreasingIndex - 1]);
        // Sort the suffix in descending order
        var prefix = charArray.Take(firstIncreasingIndex).ToArray();
        var suffix = charArray.Skip(firstIncreasingIndex).OrderByDescending(c => c).ToArray();
        var result = new string(prefix.Concat(suffix).ToArray());
        return NextSmallerNumber(result);
    }

    private static int NextSmallerNumber(string result)
    {
        if (result[0] == '0')
            return CannotGenerateNextSmallerNumber;
        return int.TryParse(result, out var nextSmallerNumber)
            ? nextSmallerNumber
            : CannotGenerateNextSmallerNumber;
    }

    private static int FindNextSmallerIndex(string s, int i)
    {
        var j = 0;
        for (j = s.Length - 1; j >= i - 1; j--)
        {
            if (s[i - 1] > s[j])
            {
                break;
            }
        }
        return j;
    }

    private static int FindFirstIncreasingIndex(string s)
    {
        var i = 0;
        for (i = s.Length - 1; i > 0; i--)
        {
            if (s[i] < s[i - 1])
            {
                break;
            }
        }
        return i;
    }
} 