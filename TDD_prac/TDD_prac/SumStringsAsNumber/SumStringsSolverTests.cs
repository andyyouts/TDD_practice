using FluentAssertions;

namespace TDD_prac.SumStringsAsNumber;

public class SumStringsSolverTests
{
    [TestCase("aaa", "123", TestName = "str1 is not a number")]
    [TestCase("456", "bbb", TestName = "str2 is not a number")]
    [TestCase("aaa", "bbb", TestName = "str1 and str2 are not a number")]
    public void should_return_na_for_invalid_input(string str1, string str2)
    {
        var sumStrings = ComputeSumStrings(str1, str2);
        SumStringShouldBe(sumStrings, "n/a");
    }

    [TestCase("123", "456", "579", TestName = "Basic valid numbers")]
    [TestCase("0", "0", "0",TestName = "Zeros")]
    [TestCase("999", "1", "1000",TestName = "Three digits plus one digit")]
    public void should_return_sum_as_string_for_valid_non_negative_inputs(string str1, string str2, string expectedSumString)
    {
        var sumString = ComputeSumStrings(str1, str2);
        SumStringShouldBe(sumString, expectedSumString);
    }
    
    [TestCase("-123", "456", "333", TestName = "smaller negative and larger positive inputs")]
    [TestCase("123", "-456", "-333", TestName = "larger negative and smaller positive inputs")]
    [TestCase("-123", "-456", "-579", TestName = "both inputs are negative")]
    public void should_return_sum_as_string_for_valid_negative_inputs(string str1, string str2, string expectedSumString)
    {
        var sumStrings = ComputeSumStrings(str1, str2);
        SumStringShouldBe(sumStrings, (expectedSumString).ToString());
    }

    [Test]
    public void should_throw_overflow_exception_if_sum_overflows()
    {
        Assert.Throws<OverflowException>(() => ComputeSumStrings("2147483647", "1"));
    }
    
    private static void SumStringShouldBe(string sumStrings, string expectedSumString)
    {
        sumStrings.Should().Be(expectedSumString);
    }

    private static string ComputeSumStrings(string str1, string str2)
    {
        return SumStringsSolver.SumStrings(str1, str2);
    }
}