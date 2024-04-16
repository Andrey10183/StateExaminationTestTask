using System.Text.RegularExpressions;

namespace Task1.Helpers;

public static class WordHelper
{
    public static string RemovePunctuationAndFormatting(string text)
    {
        string pattern = @"[^\w\s]|[\t\n\r]";

        return Regex.Replace(text, pattern, "");
    }

    public static List<string> SplitToWordsInLowerFormat(string text) =>
        text
            .Trim()
            .ToLower()
            .Split(' ')
            .ToList();
}
