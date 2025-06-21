using FluentAssertions;

namespace TDD_prac.PlayWithTwoStrings;

public class TwoStringsSolverTests
{
    [Test]
    public void should_return_empty_strings_if_two_strings_all_empty()
    {
        var combinedString = CombineTwoStrings("", "");
        CombinedStringShouldBe(combinedString, "");
    }

    [TestCase("a", "", "a", TestName = "the second string is empty")]
    [TestCase("", "b", "b", TestName = "the first string is empty")]
    public void should_return_the_other_string_if_one_string_is_empty(string str1, string str2, string expectedCombinedString)
    {
        var combinedString = CombineTwoStrings(str1, str2);
        CombinedStringShouldBe(combinedString, expectedCombinedString);
    }

    [TestCase("abc", "cef", "abCCef", TestName = "strings with distinct letters")]
    [TestCase("hello", "world", "heLLOwOrld", TestName = "strings with overlapping letters")]
    [TestCase("test", "test", "tESttESt", TestName = "identical strings")]
    [TestCase("a", "a", "AA", TestName = "single character")]
    public void should_handle_basic_string_combinations(string str1, string str2, string expectedCombinedString)
    {
        var combinedString = CombineTwoStrings(str1, str2);
        CombinedStringShouldBe(combinedString, expectedCombinedString);
    }

    [TestCase("abc123", "123def", "abc123123def", TestName = "letters and numbers")]
    [TestCase("!@#", "$%^", "!@#$%^", TestName = "only special characters")]
    [TestCase("Hello123!", "World456?", "HeLLO123!WOrld456?", TestName = "mixed content")]
    public void should_handle_non_letter_characters(string str1, string str2, string expectedCombinedString)
    {
        var combinedString = CombineTwoStrings(str1, str2);
        CombinedStringShouldBe(combinedString, expectedCombinedString);
    }

    [TestCase("AABB", "AABB", "AABBAABB", TestName = "even occurrences")]
    [TestCase("aaa", "a", "AAAA", TestName = "odd count repeated characters")]
    [TestCase("aaa", "aa", "aaaAA", TestName = "even count repeated characters")]
    public void should_handle_repeated_characters(string str1, string str2, string expectedCombinedString)
    {
        var combinedString = CombineTwoStrings(str1, str2);
        CombinedStringShouldBe(combinedString, expectedCombinedString);
    }

    [TestCase("café", "cafe", "CAFéCAFe", TestName = "unicode characters")]
    [TestCase("hello world", "world hello", "HELLo WoRLDWoRLD HELLo", TestName = "spaces and punctuation")]
    [TestCase("Programming", "grammar", "ProGramminGgrAmmAr", TestName = "complex case swapping")]
    public void should_handle_special_cases(string str1, string str2, string expectedCombinedString)
    {
        var combinedString = CombineTwoStrings(str1, str2);
        CombinedStringShouldBe(combinedString, expectedCombinedString);
    }

    private static void CombinedStringShouldBe(string solve, string expectedCombinedString)
    {
        solve.Should().Be(expectedCombinedString);
    }

    private static string CombineTwoStrings(string str1, string str2)
    {
        return TwoStringsSolver.Solve(str1, str2);
    }
}