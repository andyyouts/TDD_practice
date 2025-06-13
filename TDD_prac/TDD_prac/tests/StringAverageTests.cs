using FluentAssertions;

namespace TDD_prac.tests;

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
        GivenNumbersOfStrings("one two three").Should().Be("2");
    }
    
    [Test]
    public void should_return_average_number_for_multiple_valid_number_strings()
    {
        GivenNumbersOfStrings("one five two eight three").Should().Be("3");
    }

    [Test]
    public void should_return_na_for_invalid_numbers_strings()
    {
        GivenNumbersOfStrings("I'm Happy").Should().Be("n/a");
    }
    

    [Test]
    public void should_return_na_for_larger_than_nine_number_string()
    {
        GivenNumbersOfStrings("one two three ten").Should().Be("n/a");
    }

    [Test]
    public void should_return_na_for_empty_strings()
    {
        GivenNumbersOfStrings("").Should().Be("n/a");
    }

    [Test]
    public void should_return_average_number_for_different_cases_valid_number_strings()
    {
        GivenNumbersOfStrings("FiVe NInE SeVEn").Should().Be("7");
    }

    private string GivenNumbersOfStrings(string numbersAsStrings)
    {
        return _stringAverageSolver.GetStringAverage(numbersAsStrings);
    }
}