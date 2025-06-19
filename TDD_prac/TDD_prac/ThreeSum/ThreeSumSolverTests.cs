using FluentAssertions;

namespace TDD_prac.ThreeSum;

public class ThreeSumSolverTests
{
    private readonly List<List<IList<int>>> _possibleSolutions =
    [
        new()
        {
            new List<int> { -1, -1, 2 },
            new List<int> { -1, 0, 1 }
        },

        new()
        {
            new List<int> { -1, 0, 1 },
            new List<int> { -1, -1, 2 }
        },

        new()
        {
            new List<int> { 2, -1, -1 },
            new List<int> { 1, 0, -1 }
        },

        new()
        {
            new List<int> { 1, 0, -1 },
            new List<int> { 2, -1, -1 }
        },

        new()
        {
            new List<int> { 2, -1, -1 },
            new List<int> { -1, 0, 1 }
        },

        new()
        {
            new List<int> { -1, 0, 1 },
            new List<int> { 2, -1, -1 }
        },

        new()
        {
            new List<int> { -1, -1, 2 },
            new List<int> { 1, 0, -1 }
        },

        new()
        {
            new List<int> { 1, 0, -1 },
            new List<int> { -1, -1, 2 }
        }
    ];

    private ThreeSumSolver _threeSumSolver;

    [SetUp]
    public void SetUp()
    {
        _threeSumSolver = new ThreeSumSolver();
    }

    [Test]
    public void should_throw_exception_when_input_list_is_null()
    {
        Assert.Throws<ArgumentNullException>(() => _threeSumSolver.SolveThreeSum(null));
    }

    [Test]
    public void should_return_empty_list_when_no_three_sum_solution()
    {
        var threeSum = _threeSumSolver.SolveThreeSum([1, 2, 3]);
        threeSum.Should().BeEquivalentTo(new List<IList<int>>());
    }

    [Test]
    public void should_return_solution_when_there_is_only_one_solution()
    {
        var threeSum = _threeSumSolver.SolveThreeSum([0, 0, 0]);
        threeSum.Should().BeEquivalentTo(new List<IList<int>> { new List<int> { 0, 0, 0 } });
    }

    [TestCase(new[] { -1, 0, 1, 2, -1, -4 }, true)]
    [TestCase(new[] { -1, 0, 1, 2, -1, -4 }, false)]
    public void should_return_solution_regardless_of_order_if_there_are_many(int[] ints, bool ascending)
    {
        var threeSum = _threeSumSolver.SolveThreeSum(ints, ascending);
        _possibleSolutions.Should().ContainEquivalentOf(threeSum);
    }
}