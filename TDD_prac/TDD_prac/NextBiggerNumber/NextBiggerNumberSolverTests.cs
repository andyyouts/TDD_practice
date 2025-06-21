using FluentAssertions;

namespace TDD_prac.NextBiggerNumber;

public class NextBiggerNumberSolverTests
{
    [Test]
    public void should_return_negative_one_for_string_with_single_digit()
    {
        var nextBiggerNumber = GetNextBiggerNumber(4);
        NextBiggerNumberShouldBe(nextBiggerNumber, -1);
    }


    [TestCase(444, TestName = "three digit number with same digits")]
    [TestCase(44444444, TestName = "eight digit number with same digits")]
    public void should_return_negative_one_for_string_with_all_same_digits(int sameDigitInt)
    {
        var nextBiggerNumber = GetNextBiggerNumber(sameDigitInt);
        NextBiggerNumberShouldBe(nextBiggerNumber, -1);
    }

    [TestCase(987654321, TestName = "consecutive sequence in descending order")]
    [TestCase(97531, TestName = "descending order with common difference two")]
    [TestCase(986532, TestName = "descending order with random differences")]
    public void should_return_negative_one_for_string_in_descending_order(int descendingInt)
    {
        var nextBiggerNumber = GetNextBiggerNumber(descendingInt);

        NextBiggerNumberShouldBe(nextBiggerNumber, -1);
    }

    [TestCase(123456789, 123456798, TestName = "consecutive sequence in ascending order")]
    [TestCase(13579, 13597, TestName = "ascending order with common difference two")]
    [TestCase(235689, 235698, TestName = "ascending order with random differences")]
    public void should_return_last_two_digits_swap_for_string_in_ascending_order(int ascendingInt, int expectedInt)
    {
        var nextBiggerNumber = GetNextBiggerNumber(ascendingInt);
        
        NextBiggerNumberShouldBe(nextBiggerNumber, expectedInt);
    }

    [TestCase(513, 531, TestName = "unsorted three digit number integer")]
    [TestCase(2017, 2071, TestName = "unsorted four digit number integer")]
    [TestCase(218765, 251678, TestName = "unsorted six digit number integer")]
    public void should_return_next_bigger_number_for_unsorted_string(int integer, int expectedInt)
    {
        var nextBiggerNumber = GetNextBiggerNumber(integer);
        
        NextBiggerNumberShouldBe(nextBiggerNumber, expectedInt);
    }

    [Test]
    public void should_return_negative_one_if_result_overflows()
    {
        var nextBiggerNumber = GetNextBiggerNumber(2147483641);
        
        NextBiggerNumberShouldBe(nextBiggerNumber, -1);
    }
    private static void NextBiggerNumberShouldBe(int calculatedNextBiggerNumber, int expectedNextBiggerNumber)
    {
        calculatedNextBiggerNumber.Should().Be(expectedNextBiggerNumber);
    }
    private static int GetNextBiggerNumber(int integer)
    {
        return NextBiggerNumberSolver.GetNextBiggerNumber(integer);
    }
}
