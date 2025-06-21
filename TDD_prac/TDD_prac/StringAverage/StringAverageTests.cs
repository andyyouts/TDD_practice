using FluentAssertions;

namespace TDD_prac.StringAverage;

public class StringAverageTests
{
    [Test]
    public void should_return_average_number_for_three_valid_number_strings()
    {
        var stringAverage = ComputeStringAverage("one two three");

        StringAverageShouldBe(stringAverage, "2");
    }

    [Test]
    public void should_return_average_number_for_multiple_valid_number_strings()
    {
        var stringAverage = ComputeStringAverage("one five two eight three");

        StringAverageShouldBe(stringAverage, "3");
    }

    [Test]
    public void should_return_na_for_invalid_numbers_strings()
    {
        var stringAverage = ComputeStringAverage("I'm Happy");

        StringAverageShouldBe(stringAverage, "n/a");
    }

    [Test]
    public void should_return_na_for_larger_than_nine_number_string()
    {
        var stringAverage = ComputeStringAverage("one two three ten");

        StringAverageShouldBe(stringAverage, "n/a");
    }

    [Test]
    public void should_return_na_for_empty_strings()
    {
        var stringAverage = ComputeStringAverage("");

        StringAverageShouldBe(stringAverage, "n/a");
    }

    [Test]
    public void should_return_average_number_for_different_cases_valid_number_strings()
    {
        var stringAverage = ComputeStringAverage("FiVe NInE SeVEn");

        StringAverageShouldBe(stringAverage, "7");
    }

    private static void StringAverageShouldBe(string stringAverage, string expectedValue)
    {
        stringAverage.Should().Be(expectedValue);
    }

    private string ComputeStringAverage(string numbersAsWords)
    {
        return StringAverageSolver.GetStringAverage(numbersAsWords);
    }
}