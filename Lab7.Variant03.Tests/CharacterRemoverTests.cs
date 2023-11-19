using Lab7.Variant03.Library;
using Xunit;

namespace Lab7.Variant03.Tests;

public class CharacterRemoverTests
{
    private readonly LetterRemover _letterRemover = new LetterRemover();

    [Fact]
    public void RemoveLetterBetween_StandardCase_RemovesCorrectCharacter()
    {
        string result = _letterRemover.RemoveLetterBetween("example axa bxb", 'a', 'a');
        Assert.Equal("example aa bxb", result);
    }

    [Fact]
    public void RemoveLetterBetween_NoOccurrences_NoChange()
    {
        string result = _letterRemover.RemoveLetterBetween("test text", 'x', 'z');
        Assert.Equal("test text", result);
    }

    [Fact]
    public void RemoveLetterBetween_EmptyString_ReturnsEmpty()
    {
        string result = _letterRemover.RemoveLetterBetween("", 'a', 'b');
        Assert.Equal("", result);
    }

    [Fact]
    public void RemoveLetterBetween_SpecialCharacters_RemovesCorrectCharacter()
    {
        string result = _letterRemover.RemoveLetterBetween("he!l?lo w?orld", '!', '?');
        Assert.Equal("he!?lo w?orld", result);
    }

    [Fact]
    public void RemoveLetterBetween_CaseSensitive_RemovesOnlyMatchingCase()
    {
        string result = _letterRemover.RemoveLetterBetween("Hello World", 'H', 'l');
        Assert.Equal("Hllo World", result);
    }

    [Fact]
    public void RemoveLetterBetween_MultipleOccurrences_RemovesAllCorrectCharacters()
    {
        string result = _letterRemover.RemoveLetterBetween("abaracadabra", 'a', 'a');
        Assert.Equal("aaaaabra", result);
    }

    [Fact]
    public void RemoveLetterBetween_AdjacentPatterns_HandlesCorrectly()
    {
        string result = _letterRemover.RemoveLetterBetween("aaxaa", 'a', 'a');
        Assert.Equal("aaaa", result);
    }
}