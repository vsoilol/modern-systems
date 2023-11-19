using Lab7.Variant02.Library;
using Xunit;

namespace Lab7.Variant02.Tests;

public class TextReplacerTests
{
    private readonly TextReplacer _textReplacer = new TextReplacer();

    [Fact]
    public void ReplaceLetterInText_SingleOccurrence_ReplacesCorrectly()
    {
        var result = _textReplacer.ReplaceLetterInText("test", 't', "tt");
        Assert.Equal("ttestt", result);
    }

    [Fact]
    public void ReplaceLetterInText_MultipleOccurrences_ReplacesAll()
    {
        var result = _textReplacer.ReplaceLetterInText("test text", 't', "tt");
        Assert.Equal("ttestt ttextt", result);
    }

    [Fact]
    public void ReplaceLetterInText_NoOccurrences_NoChange()
    {
        var result = _textReplacer.ReplaceLetterInText("hello world", 'x', "XX");
        Assert.Equal("hello world", result);
    }

    [Fact]
    public void ReplaceLetterInText_EmptyString_ReturnsEmpty()
    {
        var result = _textReplacer.ReplaceLetterInText("", 'a', "b");
        Assert.Equal("", result);
    }

    [Fact]
    public void ReplaceLetterInText_SpecialCharacters_ReplacesCorrectly()
    {
        var result = _textReplacer.ReplaceLetterInText("hello! world?", 'o', "OO");
        Assert.Equal("hellOO! wOOrld?", result);
    }

    [Fact]
    public void ReplaceLetterInText_CaseSensitive_ReplacesOnlyMatchingCase()
    {
        var result = _textReplacer.ReplaceLetterInText("Hello World", 'o', "OO");
        Assert.Equal("HellOO WOOrld", result);
    }
}