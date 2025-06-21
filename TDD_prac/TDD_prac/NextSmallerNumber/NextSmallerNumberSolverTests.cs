using FluentAssertions;

namespace TDD_prac.NextSmallerNumber;

public class NextSmallerNumberSolverTests
{
    [Test]
    public void should_return_negative_one_for_string_with_single_digit()
    {
        var nextSmallerNumber = GetNextSmallerNumber(4);
        NextSmallerNumberShouldBe(nextSmallerNumber, -1);
    }

    [TestCase(444, TestName = "three digit number with same digits")]
    [TestCase(44444444, TestName = "eight digit number with same digits")]
    public void should_return_negative_one_for_string_with_all_same_digits(int sameDigitInt)
    {
        var nextSmallerNumber = GetNextSmallerNumber(sameDigitInt);
        NextSmallerNumberShouldBe(nextSmallerNumber, -1);
    }

    [TestCase(123456789, TestName = "consecutive sequence in ascending order")]
    [TestCase(13579, TestName = "ascending order with common difference two")]
    [TestCase(235689, TestName = "ascending order with random differences")]
    public void should_return_negative_one_for_string_in_ascending_order(int ascendingInt)
    {
        var nextSmallerNumber = GetNextSmallerNumber(ascendingInt);
        NextSmallerNumberShouldBe(nextSmallerNumber, -1);
    }

    [TestCase(987654321, 987654312, TestName = "consecutive sequence in descending order")]
    [TestCase(97531, 97513, TestName = "descending order with common difference two")]
    [TestCase(986532, 986523, TestName = "descending order with random differences")]
    public void should_return_last_two_digits_swap_for_string_in_descending_order(int descendingInt, int expectedInt)
    {
        var nextSmallerNumber = GetNextSmallerNumber(descendingInt);
        NextSmallerNumberShouldBe(nextSmallerNumber, expectedInt);
    }

    [TestCase(513, 351, TestName = "unsorted three digit number integer")]
    [TestCase(2017, 1720, TestName = "unsorted four digit number integer")]
    [TestCase(218765, 218756, TestName = "unsorted six digit number integer")]
    public void should_return_next_smaller_number_for_unsorted_string(int integer, int expectedInt)
    {
        var nextSmallerNumber = GetNextSmallerNumber(integer);
        NextSmallerNumberShouldBe(nextSmallerNumber, expectedInt);
    }

    [Test]
    public void should_return_negative_one_if_result_has_leading_zero()
    {
        var nextSmallerNumber = GetNextSmallerNumber(1027);
        NextSmallerNumberShouldBe(nextSmallerNumber, -1);
    }

    private static void NextSmallerNumberShouldBe(int calculatedNextSmallerNumber, int expectedNextSmallerNumber)
    {
        calculatedNextSmallerNumber.Should().Be(expectedNextSmallerNumber);
    }
    private static int GetNextSmallerNumber(int integer)
    {
        return NextSmallerNumberSolver.GetNextSmallerNumber(integer);
    }
} 