namespace BibleAnalyzer;

public class BibleIndex(Dictionary<string, IEnumerable<string>> wordsReferences)
{
    public Dictionary<string, IEnumerable<string>> WordsReferences { get; set; } = wordsReferences;
}