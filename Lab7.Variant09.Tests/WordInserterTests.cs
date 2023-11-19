using Lab7.Variant09.Library;
using Xunit;

namespace Lab7.Variant09.Tests;

public class WordInserterTests
{
    private readonly WordInserter _wordInserter = new WordInserter();

    [Fact]
    public void InsertWordInText_SingleOccurrence_InsertsCorrectly()
    {
        string result = _wordInserter.InsertWordInText("The quick brown fox", "fox", "jumps");
        Assert.Equal("The quick brown fox jumps", result);
    }

    [Fact]
    public void InsertWordInText_MultipleOccurrences_InsertsInAll()
    {
        string result = _wordInserter.InsertWordInText("Hello world world hello", "world", "wide");
        Assert.Equal("Hello world wide world wide hello", result);
    }

    [Fact]
    public void InsertWordInText_NoMatchingWord_NoChange()
    {
        string result = _wordInserter.InsertWordInText("Hello world", "planet", "earth");
        Assert.Equal("Hello world", result);
    }

    [Fact]
    public void InsertWordInText_EmptyString_ReturnsEmpty()
    {
        string result = _wordInserter.InsertWordInText("", "hello", "hi");
        Assert.Equal("", result);
    }

    [Fact]
    public void InsertWordInText_CaseInsensitive_MatchesAndInserts()
    {
        string result = _wordInserter.InsertWordInText("Hello World", "world", "wide");
        Assert.Equal("Hello World wide", result);
    }
}