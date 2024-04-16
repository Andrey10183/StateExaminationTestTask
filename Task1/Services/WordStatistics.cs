using Task1.Helpers;
using Task1.Interfaces;

namespace Task1.Services;


public class WordStatistics : IWordStatistics
{
    public void GetTextStatisticFile(string text, string path = "WordStatistics.txt")
    {
        var statistics = ParseText(text);

        FileHelper.SaveDictionaryToFile(statistics, path);
    }

    private Dictionary<string, int> ParseText(string text)
    {
        var result = new Dictionary<string, int>();

        //remove punctuation and formatting
        text = WordHelper.RemovePunctuationAndFormatting(text);

        //prepare input text for parsing
        var words = WordHelper.SplitToWordsInLowerFormat(text);


        //parse words
        foreach (var word in words)
        {
            if (string.IsNullOrEmpty(word)) continue;

            if (result.ContainsKey(word)) result[word]++;
            else result.Add(word, 1);
        }

        //sort in descending order
        result = result
            .OrderByDescending(x => x.Value)
            .ToDictionary(x => x.Key, x => x.Value);

        return result;
    }
}
