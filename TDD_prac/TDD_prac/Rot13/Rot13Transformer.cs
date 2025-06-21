using System.Runtime.InteropServices.JavaScript;

namespace TDD_prac.Rot13;

public static class Rot13Transformer
{
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
        return char.IsLetter(c);
    }

    private static char Rot13(char c)
    {
        return c switch
        {
            >= 'A' and <= 'Z' => (char)('A' + (c - 'A' + 13) % 26),
            >= 'a' and <= 'z' => (char)('a' + (c - 'a' + 13) % 26),
            _ => c
        };
    }
}