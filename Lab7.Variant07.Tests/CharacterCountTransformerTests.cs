using Lab7.Variant07.Library;
using Xunit;

namespace Lab7.Variant07.Tests;

public class CharacterCountTransformerTests
{
    private readonly CharacterCountTransformer _characterCountTransformer = new CharacterCountTransformer();

    [Fact]
    public void TransformRepeatingCharacters_StandardCase_TransformsCorrectly()
    {
        string result = _characterCountTransformer.TransformRepeatingCharacters("aaabb ccccddd eeefggg hhkl");
        Assert.Equal("a3b2 c4d3 e3fg3 h2kl", result);
    }

    [Fact]
    public void TransformRepeatingCharacters_MixedCase_RemainsCaseSensitive()
    {
        string result = _characterCountTransformer.TransformRepeatingCharacters("Coffeeee");
        Assert.Equal("Cof2e4", result);
    }

    [Fact]
    public void TransformRepeatingCharacters_WithPunctuation_HandlesCorrectly()
    {
        string result = _characterCountTransformer.TransformRepeatingCharacters("Hello, world! WWooorld!!!");
        Assert.Equal("Hel2o, world! W2o3rld!3", result);
    }

    [Fact]
    public void TransformRepeatingCharacters_EmptyString_ReturnsEmpty()
    {
        string result = _characterCountTransformer.TransformRepeatingCharacters("");
        Assert.Equal("", result);
    }

    [Fact]
    public void TransformRepeatingCharacters_NoDuplicates_NoChange()
    {
        string result = _characterCountTransformer.TransformRepeatingCharacters("Unique");
        Assert.Equal("Unique", result);
    }

    [Fact]
    public void TransformRepeatingCharacters_SingleCharacterStrings_NoChange()
    {
        string result = _characterCountTransformer.TransformRepeatingCharacters("a b c d e");
        Assert.Equal("a b c d e", result);
    }
}