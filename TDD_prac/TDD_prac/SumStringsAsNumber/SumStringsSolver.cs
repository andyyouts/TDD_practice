namespace TDD_prac.SumStringsAsNumber;

public static class SumStringsSolver
{
    private const string InputError = "n/a";

    public static string SumStrings(string str1, string str2)
    {
        if (!IsFirstInputValid(str1, out var int1) || !IsSecondInputValid(str2, out var int2))
        {
            return InputError;
        }

        return ConvertSumToString(int1, int2);
    }

    private static string ConvertSumToString(int int1, int int2)
    {
        var sum = checked(int1 + int2);
        return sum.ToString();
    }

    private static bool IsSecondInputValid(string str2, out int int2)
    {
        return int.TryParse(str2, out int2);
    }

    private static bool IsFirstInputValid(string str1, out int int1)
    {
        return int.TryParse(str1, out int1);
    }
}