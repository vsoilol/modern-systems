namespace Lab7.Variant03.Library;

public class LetterRemover
{
    public string RemoveLetterBetween(string text, char firstLetter, char secondLetter)
    {
        // Разделяем строки на подстроки по следующим символам [' ', '\t', '\n']
        // StringSplitOptions.RemoveEmptyEntries - удаляеn пустые элементы нового массива
        var words = text.Split(new char[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);
        
        // Проходим по всем элементам массива
        for (int i = 0; i < words.Length; i++)
        {
            words[i] = RemoveLetterInWord(words[i], firstLetter, secondLetter);
        }

        // Объединяем все подстроки
        return string.Join(" ", words);
    }

    private string RemoveLetterInWord(string word, char firstChar, char secondChar)
    {
        // Находим индекс первого вхождения символа firstChar
        int firstIndex = word.IndexOf(firstChar);
        
        // Пока мы не дойдём до конца массива
        while (firstIndex != -1 && firstIndex + 2 < word.Length)
        {
            // Если символ который находиться на две поизиции больше чем firstChar равняется secondChar
            // Тогда удаляем символ находящийся между первым вхождением firstChar и secondChar
            if (word[firstIndex + 2] == secondChar)
            {
                word = word.Remove(firstIndex + 1, 1);
            }

            // Находим новое вхождение firstChar в строке word начиная с индекса firstIndex + 1
            firstIndex = word.IndexOf(firstChar, firstIndex + 1);
        }
        
        return word;
    }
}