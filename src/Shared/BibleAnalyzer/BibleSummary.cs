namespace BibleAnalyzer;

public interface ISerializableSummary
{
    public string Name { get; }
    IDictionary<string, int> Words { get; }
}

public class BibleSummary() : ISerializableSummary
{
    public IDictionary<string, int> Words { get; } = new Dictionary<string, int>();

    public TestamentSummary OldTestamentSummary { get; } = new TestamentSummary(Testament.OldTestament);
    public TestamentSummary NewTestamentSummary { get; } = new TestamentSummary(Testament.NewTestament);

    public string Name => "bibleSummary";
}

public class TestamentSummary(Testament testament) : ISerializableSummary
{
    public string Name => Testament.ToString();
    public Testament Testament { get; } = testament;
    public IDictionary<string, int> Words { get; } = new Dictionary<string, int>();
    public IDictionary<string, BookSummary> Books { get; } = new Dictionary<string, BookSummary>();
}

public class BookSummary(string bookName) : ISerializableSummary
{
    public string Name => bookName;
    public IDictionary<string, int> Words { get; } = new Dictionary<string, int>();
}

