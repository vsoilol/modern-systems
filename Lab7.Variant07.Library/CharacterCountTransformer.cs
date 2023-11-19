using System.Text;

namespace Lab7.Variant07.Library;

public class CharacterCountTransformer
{
    public string TransformRepeatingCharacters(string text)
    {
        // Разделяем строки на подстроки по следующим символам [' ', '\t', '\n']
        // StringSplitOptions.RemoveEmptyEntries - удаляеn пустые элементы нового массива
        var words = text.Split(new char[] {' ', '\t', '\n'},
            StringSplitOptions.RemoveEmptyEntries);
        
        var transformedWords = new List<string>();

        // Проходим по всем элементам массива и добавляем их в массив преобразованных строк
        foreach (var word in words)
        {
            transformedWords.Add(TransformWord(word));
        }

        // Объединяем все подстроки
        return string.Join(" ", transformedWords);
    }

    private string TransformWord(string word)
    {
        if (string.IsNullOrEmpty(word))
        {
            return word;
        }

        StringBuilder transformedWord = new StringBuilder();
        int count = 1;
        char lastChar = word[0];

        // Проходим по всем символам строки
        for (int i = 1; i < word.Length; i++)
        {
            if (word[i] == lastChar)
            {
                count++;
            }
            else
            {
                AppendTransformedCharacter(transformedWord, lastChar, count);
                lastChar = word[i];
                count = 1;
            }
        }
        
        AppendTransformedCharacter(transformedWord, lastChar, count);

        return transformedWord.ToString();
    }

    private void AppendTransformedCharacter(StringBuilder sb, char character, int count)
    {
        sb.Append(character);
        if (count > 1)
        {
            sb.Append(count);
        }
    }
}