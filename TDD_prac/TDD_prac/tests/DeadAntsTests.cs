using FluentAssertions;

namespace TDD_prac.tests;

public class DeadAntsTests
{
    private DeadAntsSolver _deadAntsSolver;

    [SetUp]
    public void SetUp()
    {
        _deadAntsSolver = new DeadAntsSolver();
    }

    [Test]
    public void should_return_zero_for_empty_string()
    {
        _deadAntsSolver.CountDeadAnts(" ").Should().Be(0);
    }

    [Test]
    public void should_return_zero_for_no_scattered_bits()
    {
        _deadAntsSolver.CountDeadAnts("ant...ant").Should().Be(0);
    }

    [TestCase("...ant...ant..nat.ant.t..ant...ant..ant..ant.anant..t", 3)]
    [TestCase("....ant...a.ant..anatttt.", 4)]
    public void should_return_numbers_of_scattered_bits_(string antsStrings, int expectedCount)
    {
        _deadAntsSolver.CountDeadAnts(antsStrings).Should().Be(expectedCount);
    }
    
}