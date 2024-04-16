using System.Collections.Concurrent;
using Task1.Helpers;
using Task1.Interfaces;

namespace Task1.Services;

public class WordStatisticsParallel : IWordStatistics
{
    private readonly int _splitPieces;
    private ConcurrentDictionary<string, int> _statistics = new ConcurrentDictionary<string, int>();

    public WordStatisticsParallel()
    {
        _splitPieces = Environment.ProcessorCount;
    }

    public void GetTextStatisticFile(string text, string path = "WordStatistics.txt")
    {
        var textParts = SplitTextIntoParts(text, _splitPieces);

        Parallel.For(0, _splitPieces, i =>
        {
            ParseText(textParts[i]);
        });

        //sort in descending order
        var sortedStatistic = _statistics
            .OrderByDescending(x => x.Value)
            .ToDictionary(x => x.Key, x => x.Value);

        FileHelper.SaveDictionaryToFile(sortedStatistic, path);
    }

    private void ParseText(string textPart)
    {
        //remove punctuation and formatting
        textPart = WordHelper.RemovePunctuationAndFormatting(textPart);

        //prepare input text for parsing
        var words = WordHelper.SplitToWordsInLowerFormat(textPart);

        foreach (var word in words)
        {
            if (string.IsNullOrEmpty(word)) continue;

            _statistics.AddOrUpdate(word, 1, (key, oldValue) => oldValue + 1);
        }
    }
    
    private List<string> SplitTextIntoParts(string text, int partsQty)
    {
        var step = text.Length / partsQty;

        if (string.IsNullOrEmpty(text)) return new List<string>();
        if (step == 0) return new List<string>() { text };

        var parts = new List<string>();

        int startPos = 0;
        int endPos = 0;

        for (int i = 0; i < partsQty; i++)
        {
            if (endPos >= text.Length) break;
            if (i == partsQty - 1)
            {
                var part = text.Substring(endPos);
                if (!string.IsNullOrEmpty(part))
                    parts.Add(part);
            }
            else
            {
                startPos = endPos;
                endPos = startPos + step + GetNextValidIndexForTextSeparation(text, startPos + step);
                var part = text.Substring(startPos, endPos - startPos);
                if (!string.IsNullOrEmpty(part))
                parts.Add(part);
            }
        }

        return parts;
    }


    /// <summary>
    /// Search next space or end of the text for correct text separation handling
    /// </summary>
    /// <param name="text"></param>
    /// <param name="pos"></param>
    /// <returns></returns>
    private int GetNextValidIndexForTextSeparation(string text, int pos)
    {
        var count = 0;
        if (pos >= text.Length) return 0;
        if (text[pos] == ' ') return count;
        
        while (pos + count < text.Length && text[pos + count] != ' ') 
        {
            count++;
        }

        return count;
    }
}
