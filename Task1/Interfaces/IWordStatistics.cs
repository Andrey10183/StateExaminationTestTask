namespace Task1.Interfaces;

public interface IWordStatistics
{
    void GetTextStatisticFile(string text, string path = "WordStatistics.txt");
}

