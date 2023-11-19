using System.Text;

namespace Lab7.Variant06.Library;

public class RepeatedLetterRemover
{
    public string RemoveRepeatingCharacters(string text)
    {
        // Разделяем строки на подстроки по следующим символам [' ', '\t', '\n']
        // StringSplitOptions.RemoveEmptyEntries - удаляеn пустые элементы нового массива
        var words = text.Split(new[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);
       
        // Проходим по всем элементам массива
        for (var i = 0; i < words.Length; i++)
        {
            words[i] = RemoveRepeatingCharactersFromWord(words[i]);
        }

        // Объединяем все подстроки
        return string.Join(" ", words);
    }

    private string RemoveRepeatingCharactersFromWord(string word)
    {
        if (string.IsNullOrEmpty(word))
        {
            return word;
        }

        StringBuilder sb = new StringBuilder();
        
        // '\0' - Null character, представляет собой конец строки
        char lastChar = '\0';
        
        // Проходим по всем символам строки и создаём новую строку без дублирующихся символов
        foreach (char c in word)
        {
            if (c != lastChar)
            {
                sb.Append(c);
                lastChar = c;
            }
        }

        return sb.ToString();
    }
}