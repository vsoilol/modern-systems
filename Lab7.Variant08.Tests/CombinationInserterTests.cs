using Lab7.Variant08.Library;
using Xunit;

namespace Lab7.Variant08.Tests;

public class CombinationInserterTests
{
    private readonly CombinationInserter _combinationInserter = new CombinationInserter();

    [Fact]
    public void InsertCombinationInText_StandardCase_InsertsCorrectly()
    {
        string result = _combinationInserter.InsertCombinationInText("The quick brown fox", "qui", "ck");
        Assert.Equal("The quickck brown fox", result);
    }

    [Fact]
    public void InsertCombinationInText_MultipleOccurrences_InsertsInAll()
    {
        string result = _combinationInserter.InsertCombinationInText("Abracadabra abra cadabra", "abr", "ka");
        Assert.Equal("Abracadabrkaa abrkaa cadabrkaa", result);
    }

    [Fact]
    public void InsertCombinationInText_NoMatchingCombination_NoChange()
    {
        string result = _combinationInserter.InsertCombinationInText("Hello world", "xyz", "ab");
        Assert.Equal("Hello world", result);
    }

    [Fact]
    public void InsertCombinationInText_EmptyString_ReturnsEmpty()
    {
        string result = _combinationInserter.InsertCombinationInText("", "any", "th");
        Assert.Equal("", result);
    }

    [Fact]
    public void InsertCombinationInText_CaseSensitive_DoesNotInsert()
    {
        string result = _combinationInserter.InsertCombinationInText("Sensitive Case", "cas", "XX");
        Assert.Equal("Sensitive Case", result);
    }

    [Fact]
    public void InsertCombinationInText_WithPunctuation_HandlesCorrectly()
    {
        string result = _combinationInserter.InsertCombinationInText("Hello, world! Wonderful world.", "wor", "ly");
        Assert.Equal("Hello, worlyld! Wonderful worlyld.", result);
    }
}