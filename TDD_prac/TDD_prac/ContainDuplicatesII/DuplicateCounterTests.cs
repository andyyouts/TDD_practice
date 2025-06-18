using FluentAssertions;

namespace TDD_prac.ContainDuplicatesII;

public class DuplicateCounterTests
{
    private DuplicateChecker _duplicateChecker;

    [SetUp]
    public void SetUp()
    {
        _duplicateChecker = new DuplicateChecker();
    }

    [TestCase(new int[] {}, 3)]
    [TestCase(new[] {1, 2, 3}, -3)]
    public void invalid_input_should_throw_exception(int[] nums, int k)
    {
        var exception = Assert.Throws<ArgumentException>(() => _duplicateChecker.CheckForDuplicates(nums, k));
        exception.Message.Should().Be("invalid input");
    }
    
    [TestCase(new[] { 1 }, TestName = "one element with k = 0")]
    [TestCase(new[] { 1, 2, 3 }, TestName = "three distinct elements with k = 0")]
    [TestCase(new[] { 1, 2, 3, 5, 2, 7, 2 }, TestName = "duplicate elements with k = 0")]
    public void should_return_false_when_k_is_zero(int[] nums)
    {
        _duplicateChecker.CheckForDuplicates(nums, 0).Should().Be(false);
    }


    [TestCase(new[] { 1, 1, 2 }, 1, TestName = "short list with same adjacent elements with k = 1")]
    [TestCase(new[] { 1, 2, 4, 4, 5, 7, 3 }, 1, TestName = "longer list with same adjacent elements with k = 1")]
    [TestCase(new[] { 1, 2, 4, 4, 5, 7, 3 }, 10, TestName = "longer list with same adjacent elements with k = 10")]
    public void should_return_true_when_containing_same_adjacent_elements_when_k_over_zero(int[] nums, int k)
    {
       _duplicateChecker.CheckForDuplicates(nums, k).Should().Be(true);
    }
    
    [TestCase(new[] { 1, 2 }, 1, TestName = "short list with all distinct elements with k = 1")]
    [TestCase(new[] { 1, 2, 4, 5, 7, 3 }, 1, TestName = "longer list with all distinct elements with k = 1")]
    [TestCase(new[] { 1, 2, 4, 5, 7, 3 }, 10, TestName = "longer list with all distinct elements with k = 10")]
    public void should_return_false_when_containing_all_distinct_elements_when_k_over_zero(int[] nums, int k)
    {
       _duplicateChecker.CheckForDuplicates(nums, k).Should().Be(false);
    }

    [TestCase(new [] { 1, 2, 3, 4, 5, 6, 2 }, 2, false, TestName = "5 elements away with k = 2")]
    [TestCase(new [] { 1, 2, 3, 4, 5, 6, 2 }, 5, true, TestName = "5 elements away with k = 5")]
    [TestCase(new [] { 10, 100, 30, 50, 7, 30 }, 1, false, TestName = "3 elements away with k = 1")]
    [TestCase(new [] { 10, 100, 30, 50, 7, 30 }, 10, true, TestName = "3 elements away with k = 10")]
    public void should_return_correct_value_when_containing_same_elements_over_range_k(int[] nums, int k, bool expectedValue)
    {
       _duplicateChecker.CheckForDuplicates(nums, k).Should().Be(expectedValue);
    }
    
}