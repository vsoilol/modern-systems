namespace Lab7.Variant08.Library;

public class CombinationInserter
{
    public string InsertCombinationInText(string text, string threeLetterCombo, string twoLetterCombo)
    {
        // Разделяем строки на подстроки по следующим символам [' ', '\t', '\n']
        // StringSplitOptions.RemoveEmptyEntries - удаляеn пустые элементы нового массива
        var words = text.Split(new[] {' ', '\t', '\n'},
            StringSplitOptions.RemoveEmptyEntries);
        
        var transformedWords = new List<string>();

        // Проходим по всем элементам массива и добавляем их в массив преобразованных строк
        foreach (var word in words)
        {
            transformedWords.Add(InsertCombinationInWord(word, threeLetterCombo, twoLetterCombo));
        }

        // Объединяем все подстроки
        return string.Join(" ", transformedWords);
    }

    private string InsertCombinationInWord(string word, string threeLetterCombo, string twoLetterCombo)
    {
        // Находим индекс первого вхождения threeLetterCombo в строке word
        int index = word.IndexOf(threeLetterCombo);
        
        // Проходимся по всей строке и добавляем после всех threeLetterCombo twoLetterCombo
        while (index != -1)
        {
            // вставляем twoLetterCombo после threeLetterCombo
            word = word.Insert(index + threeLetterCombo.Length, twoLetterCombo);

            // Находим индекс следующего вхождения threeLetterCombo
            index = word.IndexOf(threeLetterCombo, index + threeLetterCombo.Length + twoLetterCombo.Length);
        }

        return word;
    }
}