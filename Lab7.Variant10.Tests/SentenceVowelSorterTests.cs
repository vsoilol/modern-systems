using Lab7.Variant10.Library;
using Xunit;

namespace Lab7.Variant10.Tests;

public class SentenceVowelSorterTests
{
    private readonly SentenceVowelSorter _sentenceVowelSorter = new SentenceVowelSorter();

    [Fact]
    public void SortSentencesByVowelCount_StandardCase_SortsCorrectly()
    {
        string result = _sentenceVowelSorter.SortSentencesByVowelCount("This is a test. Vowels are important.");
        Assert.Equal("This is a test. Vowels are important.", result);
    }

    [Fact]
    public void SortSentencesByVowelCount_SingleSentence_SortsCorrectly()
    {
        string result = _sentenceVowelSorter.SortSentencesByVowelCount("Sorting words in a sentence.");
        Assert.Equal("words in a Sorting sentence.", result);
    }

    [Fact]
    public void SortSentencesByVowelCount_EmptyText_ReturnsEmpty()
    {
        string result = _sentenceVowelSorter.SortSentencesByVowelCount("");
        Assert.Equal("", result);
    }

    [Fact]
    public void SortSentencesByVowelCount_EqualVowelsCount_SortsCorrectly()
    {
        string result = _sentenceVowelSorter.SortSentencesByVowelCount("Gym is fun.");
        Assert.Equal("Gym is fun.", result);
    }

    [Fact]
    public void SortSentencesByVowelCount_AllVowels_SortsCorrectly()
    {
        string result = _sentenceVowelSorter.SortSentencesByVowelCount("I like to eat apples and bananas.");
        Assert.Equal("I to and like eat apples bananas.", result);
    }

    [Fact]
    public void SortSentencesByVowelCount_PunctuationHandling_SortsCorrectly()
    {
        string result = _sentenceVowelSorter.SortSentencesByVowelCount("Hello, world! What a beautiful day.");
        Assert.Equal("world! What a day. Hello, beautiful", result);
    }
}