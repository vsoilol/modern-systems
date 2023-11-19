using Lab7.Variant05.Library;
using Xunit;

namespace Lab7.Variant05.Tests;

public class WordReplacerTests
{
    private readonly WordReplacer _wordReplacer = new WordReplacer();

    [Fact]
    public void ReplaceWordInText_StandardCase_ReplacesCorrectly()
    {
        string result = _wordReplacer.ReplaceWordInText("The cat sat on the mat", "cat", "dog");
        Assert.Equal("The dog sat on the mat", result);
    }

    [Fact]
    public void ReplaceWordInText_WithPunctuation_ReplacesCorrectly()
    {
        string result = _wordReplacer.ReplaceWordInText("Hello, world!", "world", "earth");
        Assert.Equal("Hello, earth!", result);
    }

    [Fact]
    public void ReplaceWordInText_RegexSpecialCharacters_HandlesCorrectly()
    {
        string result = _wordReplacer.ReplaceWordInText("Find c.at here, not scat or concat.", "c.at", "cat");
        Assert.Equal("Find cat here, not scat or concat.", result);
    }

    [Fact]
    public void ReplaceWordInText_WordNotPresent_NoChange()
    {
        string result = _wordReplacer.ReplaceWordInText("A quick brown fox jumps", "dog", "wolf");
        Assert.Equal("A quick brown fox jumps", result);
    }

    [Fact]
    public void ReplaceWordInText_CaseSensitive_ReplacesOnlyMatchingCase()
    {
        string result = _wordReplacer.ReplaceWordInText("Cat and cat are different", "Cat", "Dog");
        Assert.Equal("Dog and cat are different", result);
    }

    [Fact]
    public void ReplaceWordInText_EmptyString_ReturnsEmpty()
    {
        string result = _wordReplacer.ReplaceWordInText("", "hello", "hi");
        Assert.Equal("", result);
    }

    [Fact]
    public void ReplaceWordInText_MultipleOccurrences_ReplacesAll()
    {
        string result = _wordReplacer.ReplaceWordInText("cat cat cat", "cat", "dog");
        Assert.Equal("dog dog dog", result);
    }
}