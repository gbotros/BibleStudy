using System.Text.Json.Serialization;

namespace Shared;

public class BibleVerse(string bookName, int chapter, int verse, string text)
{
    public string BookName { get; } = bookName;
    public int Chapter { get; } = chapter;
    public int Verse { get; } = verse;
    public string Text { get; } = text;

    /// <summary>
    /// Numbers are excluded
    /// </summary>
    private IEnumerable<string>? words = null;
    [JsonIgnore]
    public IEnumerable<string> Words
    {
        get
        {
            return words ??= Text.RemoveNonAlphanumericCharacters().Split(' ').Where(w => !string.IsNullOrWhiteSpace(w));
        }
    }

    public string Reference { get { return $"{BookName} {Chapter}:{Verse}"; } }

}