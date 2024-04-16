using System.Text;

namespace Task1.Helpers;

public static class FileHelper
{
    public static string ReadFile(string path)
    {
        // Check if the file exists
        if (!File.Exists(path))
        {
            throw new FileNotFoundException();
        }

        // Read the contents of the file
        var sb = new StringBuilder();
        using (StreamReader reader = new StreamReader(path))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                sb.Append(line);
            }
        }

        return sb.ToString();
    }

    public static void SaveDictionaryToFile(Dictionary<string, int> dictionary, string path)
    {
        using StreamWriter writer = new StreamWriter(path);
        foreach (var kvp in dictionary)
        {
            writer.WriteLine($"{kvp.Key} {kvp.Value}");
        }
    }
}
