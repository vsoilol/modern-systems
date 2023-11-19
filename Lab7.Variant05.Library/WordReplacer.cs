using System.Text.RegularExpressions;

namespace Lab7.Variant05.Library;

public class WordReplacer
{
    public string ReplaceWordInText(string text, string oldWord, string newWord)
    {
        // /b - Например, если oldWord - "cat", \bcat\b будет соответствовать "cat" в "a cat sat", но не в "category".
        // Regex.Escape(oldWord) - Это необходимо, потому что, если old world содержит
        // специальные символы (например, . или *), они должны рассматриваться как
        // буквальные символы в контексте этого регулярного выражения.
        // Например, если oldWord равно "c.at", без экранирования, оно
        // будет соответствовать любому символу между c и t
        // (из-за . и * являются метасимволами регулярного выражения), но при
        // экранировании это соответствовало бы только буквальной строке "c.at".
        string pattern = $@"\b{Regex.Escape(oldWord)}\b";
        
        // Заменить все соответсвия с pattern на newWord в text 
        return Regex.Replace(text, pattern, newWord);
    }
}