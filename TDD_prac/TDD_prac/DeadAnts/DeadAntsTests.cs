using FluentAssertions;

namespace TDD_prac.DeadAnts;

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
        var countDeadAnts = CountDeadAnts(" ");
        DeadAntsShouldBe(countDeadAnts, 0);
    }

    [Test]
    public void should_return_zero_for_no_scattered_bits()
    {
        var countDeadAnts = CountDeadAnts("ant...ant");
        DeadAntsShouldBe(countDeadAnts, 0);
    }

    [TestCase("...ant...ant..nat.ant.t..ant...ant..ant..ant.anant..t", 3, TestName = "longer than five sections")]
    [TestCase("....ant...a.ant..ana..tt.tt", 4, TestName = "leading dots")]
    [TestCase("ant...a.ant..anatttt....", 4, TestName = "training dots")]
    public void should_return_numbers_of_scattered_bits(string antsStrings, int expectedCount)
    {
        var countDeadAnts = CountDeadAnts(antsStrings);
        DeadAntsShouldBe(countDeadAnts, expectedCount);
    }

    [Test]
    public void should_throw_exception_if_contain_other_characters_than_ant()
    {
        var exception = Assert.Throws<Exception>(() => CountDeadAnts("ant...ant..nat.ant.t..satn"));
        exception.Message.Should().Be("Only 'ant' characters are allowed.");
    }

    private static void DeadAntsShouldBe(int countDeadAnts, int expected)
    {
        countDeadAnts.Should().Be(expected);
    }

    private int CountDeadAnts(string antsString)
    {
        return _deadAntsSolver.CountDeadAnts(antsString);
    }
}