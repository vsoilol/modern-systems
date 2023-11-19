namespace Lab7.Variant10.Library;

public class SentenceVowelSorter
{
    public string SortSentencesByVowelCount(string text)
    {
        char[] vowelChars = {'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U'};
        char[] wordDelimiters = {' ', '\t', '\n'};

        var words = text.Split(wordDelimiters, StringSplitOptions.RemoveEmptyEntries);
        var sortedSentences = new List<string>();
        
        Array.Sort(words, (w1, w2) => CountVowels(w1, vowelChars).CompareTo(CountVowels(w2, vowelChars)));

        sortedSentences.Add(string.Join(" ", words));

        return string.Join(" ", sortedSentences);
    }

    private int CountVowels(string word, char[] vowels)
    {
        int vowelCount = 0;
        foreach (char c in word)
        {
            if (Array.IndexOf(vowels, c) >= 0)
            {
                vowelCount++;
            }
        }

        return vowelCount;
    }
}