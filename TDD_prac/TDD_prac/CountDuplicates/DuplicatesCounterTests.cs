using FluentAssertions;

namespace TDD_prac.CountDuplicates;

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
        var duplicates = CountDuplicates("abc");
        duplicates.Should().Be(0);
    }


    [TestCase("aabbcde", 2, TestName = "all lower case with adjacent duplicates")]
    [TestCase("indivisibility", 1, TestName = "all lower case with non-adjacent duplicates")]
    [TestCase("ABAB", 2, TestName = "all upper case with non-adjacent duplicates")]
    [TestCase("ABBA", 2, TestName = "all upper case with adjacent duplicates")]
    
    public void should_return_number_of_duplicate_same_case_characters_for_repeating_character_string(string input, int expectedCount)
    {
        var duplicates = _duplicatesCounter.CountDuplicates(input);
        duplicates.Should().Be(expectedCount);
    }

    [TestCase("aabBcde", 2, TestName = "mixed case with adjacent duplicates")]
    [TestCase("aA11", 2, TestName = "mixed case with letters and digits")]
    [TestCase("Indivisibilities", 2, TestName = "mixed case with non-adjacent duplicates")]
    public void should_return_number_of_duplicate_different_case_characters_for_repeating_character_string(string input, int expectedCount)
    {
        var duplicates = _duplicatesCounter.CountDuplicates(input);
        duplicates.Should().Be(expectedCount);
    }
    private int CountDuplicates(string input)
    {
        return _duplicatesCounter.CountDuplicates(input);
    }
}