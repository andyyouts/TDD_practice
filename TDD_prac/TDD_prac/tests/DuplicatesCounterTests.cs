using FluentAssertions;

namespace TDD_prac.tests;

public class DuplicatesCounterTests
{
    private DuplicatesCounter _duplicatesCounter;

    [SetUp]
    public void SetUp()
    {
        _duplicatesCounter = new DuplicatesCounter();
    }

    [Test]
    public void should_return_zero_for_non_repeating_character_string()
    {
        _duplicatesCounter.CountDuplicates("abc").Should().Be(0);
    }

    [TestCase("aabbcde", 2)]
    [TestCase("indivisibility", 1)]
    [TestCase("Indivisibilities", 2)]
    [TestCase("ABBA", 2)]
    
    public void should_return_number_of_duplicate_same_case_characters_for_repeating_character_string(string input, int expectedCount)
    {
        _duplicatesCounter.CountDuplicates(input).Should().Be(expectedCount);
    }

    [TestCase("aabBcde", 2)]
    [TestCase("aA11", 2)]
    public void should_return_number_of_duplicate_different_case_characters_for_repeating_character_string(string input, int expectedCount)
    {
        _duplicatesCounter.CountDuplicates(input).Should().Be(expectedCount);
    }
    
}