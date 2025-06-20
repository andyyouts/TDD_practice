﻿using FluentAssertions;

namespace TDD_prac.BandGenerator;

public class BandNameGeneratorTests
{
    private BandNameGenerator _bandNameGenerator;

    [SetUp]
    public void SetUp()
    {
        _bandNameGenerator = new BandNameGenerator();
    }

    [Test]
    public void should_throw_exception_if_band_name_has_multiple_words()
    {
        var exception = Assert.Throws<Exception>(() => _bandNameGenerator.GenerateBandName("the beatles"));
        exception.Message.Should().Be("Band name should not contain multiple words.");
    }

    [Test]
    public void should_return_the_capitalized_name_for_band_has_different_first_and_last_character()
    {
        var bandName = GenerateBandName("beatles");
        bandName.Should().Be("The Beatles");
    }

    [Test]
    public void should_return_the_repeated_band_for_band_has_same_first_and_last_character()
    {
        var bandName = _bandNameGenerator.GenerateBandName("abba");
        bandName.Should().Be("Abbabba");
    }

    private string GenerateBandName(string bandName)
    {
        return _bandNameGenerator.GenerateBandName(bandName);
    }
}