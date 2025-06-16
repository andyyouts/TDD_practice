using FluentAssertions;

namespace TDD_prac.StringAverage;

public class StringAverageTests
{
    private StringAverageSolver _stringAverageSolver;

    [SetUp]
    public void SetUp()
    {
        _stringAverageSolver = new StringAverageSolver();
    }

    [Test]
    public void should_return_average_number_for_three_valid_number_strings()
    {
        var stringAverage = ComputeStringAverage("one two three");

        stringAverage.Should().Be("2");
    }


    [Test]
    public void should_return_average_number_for_multiple_valid_number_strings()
    {
        var stringAverage = ComputeStringAverage("one five two eight three");

        stringAverage.Should().Be("3");
    }

    [Test]
    public void should_return_na_for_invalid_numbers_strings()
    {
        var stringAverage = ComputeStringAverage("I'm Happy");

        stringAverage.Should().Be("n/a");
    }
    

    [Test]
    public void should_return_na_for_larger_than_nine_number_string()
    {
        var stringAverage = ComputeStringAverage("one two three ten");

        stringAverage.Should().Be("n/a");
    }

    [Test]
    public void should_return_na_for_empty_strings()
    {
        var stringAverage = ComputeStringAverage("");

        stringAverage.Should().Be("n/a");
    }

    [Test]
    public void should_return_average_number_for_different_cases_valid_number_strings()
    {
        var stringAverage = ComputeStringAverage("FiVe NInE SeVEn");

        stringAverage.Should().Be("7");
    }
    private string ComputeStringAverage(string numbersAsWords)
    {
        return _stringAverageSolver.GetStringAverage(numbersAsWords);
    }
}
