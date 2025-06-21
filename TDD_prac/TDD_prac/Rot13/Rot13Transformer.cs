using System.Runtime.InteropServices.JavaScript;

namespace TDD_prac.Rot13;

public static class Rot13Transformer
{
    private const int LowercaseFirstLetter = 'a';
    private const int UppercaseFirstLetter = 'A';

    public static string Transform(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return "";
        }

        var charArray = input.ToCharArray();

        TransformedCharArray(charArray);

        return new string(charArray);
    }

    private static void TransformedCharArray(char[] charArray)
    {
        for (var i = 0; i < charArray.Length; i++)
        {
            if (IsAlphabet(charArray[i]))
            {
                charArray[i] = Rot13(charArray[i]);
            }
        }
    }

    private static bool IsAlphabet(char c)
    {
        return c is >= 'A' and <= 'Z' or >= 'a' and <= 'z';
    }

    private static char Rot13(char c)
    {
        var firstLetter = char.IsUpper(c) ? UppercaseFirstLetter : LowercaseFirstLetter;
        return TransformCharacter(c, firstLetter);
    }

    private static char TransformCharacter(char c, int firstLetter)
    {
        return (char)(firstLetter + (c - firstLetter + 13) % 26);
    }
}