using FluentAssertions;

namespace TDD_prac.TwoSum;

public class TwoSumSolverTests
{
    private TwoSumSolver _twoSumSolver;

    [SetUp]
    public void SetUp()
    {
        _twoSumSolver = new TwoSumSolver();
    }

    [TestCase(new[] { 2, 7, 3, 10 }, 9, new[] { 0, 1 }, TestName = "two sum for four elements")]
    [TestCase(new[] { 1, 2, 3, 7, 10, 12, 44, 29, 78, 1000 }, 88, new[] { 4, 8 }, TestName = "two sum for multiple elements")]
    public void should_return_indexes_for_two_sum(int[] ints, int sum, IEnumerable<int> expectation)
    {
        var result = _twoSumSolver.GetIndexesForTwoSum(ints, sum);

        result.Should().BeEquivalentTo(expectation);
    }

    [Test]
    public void should_throw_exception_if_no_two_sum_can_be_formed()
    {
        var exception = Assert.Throws<ArgumentException>(() => _twoSumSolver.GetIndexesForTwoSum([1, 2, 3, 4, 5], 10));
        exception.Message.Should().Be("No two sum solution");
    }
}