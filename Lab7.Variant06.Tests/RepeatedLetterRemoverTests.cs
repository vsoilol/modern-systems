using Lab7.Variant06.Library;
using Xunit;

namespace Lab7.Variant06.Tests;

public class RepeatedLetterRemoverTests
{
    private readonly RepeatedLetterRemover _repeatedLetterRemover = new RepeatedLetterRemover();

    [Fact]
    public void RemoveRepeatingCharacters_StandardCase_RemovesDuplicates()
    {
        string result = _repeatedLetterRemover.RemoveRepeatingCharacters("Hello world");
        Assert.Equal("Helo world", result);
    }

    [Fact]
    public void RemoveRepeatingCharacters_MixedCase_RemainsCaseSensitive()
    {
        string result = _repeatedLetterRemover.RemoveRepeatingCharacters("Coffeeee");
        Assert.Equal("Cofe", result);
    }

    [Fact]
    public void RemoveRepeatingCharacters_WithNumbersAndSymbols_RemovesDuplicates()
    {
        string result = _repeatedLetterRemover.RemoveRepeatingCharacters("112233!! hello!!");
        Assert.Equal("123! helo!", result);
    }

    [Fact]
    public void RemoveRepeatingCharacters_EmptyString_ReturnsEmpty()
    {
        string result = _repeatedLetterRemover.RemoveRepeatingCharacters("");
        Assert.Equal("", result);
    }

    [Fact]
    public void RemoveRepeatingCharacters_NoDuplicates_NoChange()
    {
        string result = _repeatedLetterRemover.RemoveRepeatingCharacters("Unique");
        Assert.Equal("Unique", result);
    }

    [Fact]
    public void RemoveRepeatingCharacters_SingleCharacterStrings_NoChange()
    {
        string result = _repeatedLetterRemover.RemoveRepeatingCharacters("a b c d e");
        Assert.Equal("a b c d e", result);
    }
}