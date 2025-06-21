namespace TDD_prac.NextBiggerNumber;

public static class NextBiggerNumberSolver
{
    private const int CannotGenerateNextBiggerNumber = -1;

    public static int GetNextBiggerNumber(int integer)
    {
        if (TryConvertToValidString(integer, out var integerAsString))
        {
            return CannotGenerateNextBiggerNumber;
        }

        var firstDecreasingIndex = FindFirstDecreasingIndex(integerAsString);

        if (IsStringInDescendingOrder(firstDecreasingIndex))
        {
            return CannotGenerateNextBiggerNumber;
        }

        var nextLargerIndex = FindNextLargerIndex(integerAsString, firstDecreasingIndex);

        return GenerateNextBiggerNumber(integerAsString, firstDecreasingIndex, nextLargerIndex);
    }

    private static bool IsStringInDescendingOrder(int firstDecreasingIndex)
    {
        return firstDecreasingIndex == 0;
    }

    private static bool TryConvertToValidString(int integer, out string s)
    {
        s = integer.ToString();
        
        return s.Length == 1;
    }

    private static int GenerateNextBiggerNumber(string s, int firstDecreasingIndex, int nextLargerIndex)
    {
        var charArray = SwapAndSortCharacters(s, firstDecreasingIndex, nextLargerIndex);
        var nextPart = GenerateSortedNextPart(firstDecreasingIndex, charArray);
        var result = ConstructNextBiggerNumberString(firstDecreasingIndex, charArray, nextPart);

        return NextBiggerNumber(result);
    }

    private static string ConstructNextBiggerNumberString(int firstDecreasingIndex, char[] charArray, List<char> nextPart)
    {
        var result = new string(charArray.Take(firstDecreasingIndex).ToArray()) + new string(nextPart.ToArray());
        return result;
    }

    private static List<char> GenerateSortedNextPart(int firstDecreasingIndex, char[] charArray)
    {
        var nextPart = charArray[firstDecreasingIndex..].ToList();
        nextPart.Sort();
        return nextPart;
    }

    private static char[] SwapAndSortCharacters(string s, int firstDecreasingIndex, int nextLargerIndex)
    {
        var charArray = s.ToCharArray();
        (charArray[firstDecreasingIndex - 1], charArray[nextLargerIndex]) = (charArray[nextLargerIndex], charArray[firstDecreasingIndex - 1]);
        return charArray;
    }

    private static int NextBiggerNumber(string result)
    {
        return int.TryParse(result, out var nextBiggerNumber)
            ? nextBiggerNumber
            : CannotGenerateNextBiggerNumber;
    }

    private static int FindNextLargerIndex(string s, int i)
    {
        var j = 0;

        for (j = s.Length - 1; j >= i - 1; j--)
        {
            if (s[i - 1] < s[j])
            {
                break;
            }
        }

        return j;
    }

    private static int FindFirstDecreasingIndex(string s)
    {
        var i = 0;

        for (i = s.Length - 1; i > 0; i--)
        {
            if (s[i] > s[i - 1])
            {
                break;
            }
        }

        return i;
    }
}