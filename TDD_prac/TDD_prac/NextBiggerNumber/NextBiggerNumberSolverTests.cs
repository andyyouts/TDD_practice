using FluentAssertions;

namespace TDD_prac.NextBiggerNumber;

public class NextBiggerNumberSolverTests
{
    private NextBiggerNumberSolver _nextBiggerNumberSolver;

    [SetUp]
    public void SetUp()
    {
        _nextBiggerNumberSolver = new NextBiggerNumberSolver();
    }

    [Test]
    public void should_return_negative_one_for_string_with_single_digit()
    {
        var nextBiggerNumber = _nextBiggerNumberSolver.GetNextBiggerNumber(4);
        nextBiggerNumber.Should().Be(-1);
    }

    [TestCase(444, TestName = "three digit number with same digits")]
    [TestCase(44444444, TestName = "eight digit number with same digits")]
    public void should_return_negative_one_for_string_with_all_same_digits(int sameDigitInt)
    {
        var nextBiggerNumber = _nextBiggerNumberSolver.GetNextBiggerNumber(sameDigitInt);
        nextBiggerNumber.Should().Be(-1);
    }

    [TestCase(987654321, TestName = "consecutive sequence in descending order")]
    [TestCase(97531, TestName = "descending order with common difference two")]
    [TestCase(986532, TestName = "descending order with random differences")]
    public void should_return_negative_one_for_string_in_descending_order(int descendingInt)
    {
        var nextBiggerNumber = _nextBiggerNumberSolver.GetNextBiggerNumber(descendingInt);

        nextBiggerNumber.Should().Be(-1);
    }

    [TestCase(123456789, 123456798, TestName = "consecutive sequence in ascending order")]
    [TestCase(13579, 13597, TestName = "ascending order with common difference two")]
    [TestCase(235689, 235698, TestName = "ascending order with random differences")]
    public void should_return_last_two_digits_swap_for_string_in_ascending_order(int ascendingInt, int expectedInt)
    {
        var nextBiggerNumber = _nextBiggerNumberSolver.GetNextBiggerNumber(ascendingInt);

        nextBiggerNumber.Should().Be(expectedInt);
    }

    [TestCase(513, 531, TestName = "unsorted three digit number integer")]
    [TestCase(2017, 2071, TestName = "unsorted four digit number integer")]
    [TestCase(218765, 251678, TestName = "unsorted six digit number integer")]
    public void should_return_next_bigger_number_for_unsorted_string(int integer, int expectedInt)
    {
        var nextBiggerNumber = _nextBiggerNumberSolver.GetNextBiggerNumber(integer);

        nextBiggerNumber.Should().Be(expectedInt);
    }

    [Test]
    public void should_return_negative_one_if_result_overflows()
    {
        var nextBiggerNumber = _nextBiggerNumberSolver.GetNextBiggerNumber(2147483641);
        
        nextBiggerNumber.Should().Be(-1);
    }
}