using System.Text;

namespace Lab7.Variant09.Library;

public class WordInserter
{
    public string InsertWordInText(string text, string wordToFind, string wordToInsert)
    {
        StringBuilder transformedText = new StringBuilder();
        string[] words = text.Split(new[] {' ', '\t', '\n'},
            StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < words.Length; i++)
        {
            transformedText.Append(words[i]);
            if (words[i].Equals(wordToFind, StringComparison.OrdinalIgnoreCase))
            {
                transformedText.Append(" " + wordToInsert);
            }

            if (i < words.Length - 1)
            {
                transformedText.Append(" ");
            }
        }

        return transformedText.ToString();
    }
}