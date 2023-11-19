namespace Lab7.Variant02.Library;

public class TextReplacer
{
    public string ReplaceLetterInText(string text, char oldLetter, string newCombination)
    {
        // Разделяем строки на подстроки по следующим символам [' ', '\t', '\n']
        // StringSplitOptions.RemoveEmptyEntries - удаляеn пустые элементы нового массива
        var words = text.Split(new [] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);
        
        // Проходим по всем элементам массива и заменяем все значения oldLetter на newCombination
        for (var i = 0; i < words.Length; i++)
        {
            words[i] = words[i].Replace(oldLetter.ToString(), newCombination);
        }

        // Объединяем все подстроки
        return string.Join(" ", words);
    }
}