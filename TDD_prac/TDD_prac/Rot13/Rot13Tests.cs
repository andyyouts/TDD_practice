using FluentAssertions;
using NUnit.Framework.Internal;

namespace TDD_prac.Rot13;

public class Rot13Tests
{
    [TestCase("", TestName = "empty string")]
    [TestCase("     ", TestName = "whitespace string")]
    public void should_return_empty_string_for_empty_input_or_contains_only_whitespaces(string input)
    {
        var transformedString = TransformByRot13(input);
        TransformedStringShouldBe(transformedString, "");
    }
    
    [TestCase("this", "guvf", TestName = "single word with only lowercase")]
    [TestCase("This", "Guvf", TestName = "single word with mixed cases")]
    [TestCase("THIS IS MY FIRST EXCERCISE", "GUVF VF ZL SVEFG RKPREPVFR", TestName = "multiple words with only uppercase")]
    [TestCase("This is My fiRst exCercIse", "Guvf vf Zl svEfg rkPrepVfr", TestName = "multiple words with mixed cases")]
    public void should_return_correct_rot13_transformation_for_all_alphabetical_input(string input, string expectedTransformedString)
    {
        var transformedString = TransformByRot13(input);
        TransformedStringShouldBe(transformedString, expectedTransformedString);
    }
    
    [TestCase("thi_s", "guv_f", TestName = "single word with only lowercase with an underline")]
    [TestCase("!T?his", "!G?uvf", TestName = "single word with mixed cases with question mark and exclamation mark")]
    [TestCase("THIS (IS MY FIR)ST (EXCERCISE", "GUVF (VF ZL SVE)FG (RKPREPVFR", TestName = "multiple words with only uppercase with parentheses")]
    [TestCase("This* i*s My fiRst99 7exCercIse*", "Guvf* v*f Zl svEfg99 7rkPrepVfr*", TestName = "multiple words with mixed cases with asterisks and numbers")]
    public void should_ignore_non_alphabets_if_contains_any(string input, string expectedTransformedString)
    {
        var transformedString = TransformByRot13(input);
        TransformedStringShouldBe(transformedString, expectedTransformedString);
    }
    
    private static void TransformedStringShouldBe(string transformedString, string expectedResult)
    {
        transformedString.Should().Be(expectedResult);
    }

    private static string TransformByRot13(string input)
    {
        return Rot13Transformer.Transform(input);
    }
}